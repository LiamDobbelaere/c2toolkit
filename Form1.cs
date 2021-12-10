using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ToxicRagers.Carmageddon2.Formats;

namespace c2toolkit
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void lblTWTDropzone_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lblTWTDropzone_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        string fileExtension = Path.GetExtension(file);

                        if (fileExtension.ToLower() == ".twt")
                        {
                            ExtractTWT(file);
                        }
                        else if (fileExtension.ToLower() == ".p16" || fileExtension.ToLower() == ".p08")
                        {
                            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            string srcDir = Path.GetDirectoryName(file);

                            ProcessStartInfo startInfo = new ProcessStartInfo
                            {
                                FileName = Path.Combine(exeDirectory, "Resources\\TRixx.exe"),
                                Arguments = "\"" + file + "\"",
                                WorkingDirectory = srcDir,
                                RedirectStandardInput = true,
                                RedirectStandardOutput = true,
                                UseShellExecute = false
                            };
                            Process p = Process.Start(startInfo);
                            while (!p.StandardOutput.EndOfStream)
                            {
                                string line = p.StandardOutput.ReadLine();
                                if (line != null && line.Contains("any key"))
                                {
                                    p.StandardInput.Write('y');
                                    break;
                                }
                            }
                            p.WaitForExit();

                            try
                            {
                                Directory.Move(Path.Combine(srcDir, "pixies"), Path.Combine(srcDir, "tiffrgb"));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("tiffrgb folder probably already exists!", "C2 Toolkit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            CreateTWT(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "C2 Toolkit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtractTWT(string file)
        {
            string destinationDirectory = Path.GetDirectoryName(file);
            string actualName = Path.GetFileNameWithoutExtension(file);
            string targetPath = Path.Combine(destinationDirectory, actualName);

            Directory.CreateDirectory(targetPath);

            TWT twtFile = TWT.Load(file);

            foreach (TWTEntry entry in twtFile.Contents)
            {
                twtFile.Extract(entry, targetPath);
            }
        }

        private void CreateTWT(string file)
        {
            string targetPath = Path.ChangeExtension(file, ".TWT");

            TWT newTWT = TWT.Create(targetPath);

            foreach (string fileName in Directory.GetFiles(file))
            {
                newTWT.Add(fileName);
            }

            newTWT.Save();
        }
    }
}
