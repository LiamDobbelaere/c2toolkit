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
                        string fileExtension = Path.GetExtension(file).ToLower();

                        switch (fileExtension)
                        {
                            case ".twt":
                                ExtractTWT(file);
                                break;
                            case ".p16":
                            case ".p08":
                                UnpackPixies(file);
                                break;
                            default:
                                CreateTWT(file);
                                break;
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

        private void UnpackPixies(string file)
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
            catch (Exception)
            {
                MessageBox.Show("tiffrgb folder probably already exists!", "C2 Toolkit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCarRenameDropzone_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        if (Directory.Exists(file))
                        {
                            string prefix = "";
                            DialogResult dlr = ShowInputDialog("Enter prefix for " + Path.GetFileNameWithoutExtension(file), ref prefix);
                            prefix = prefix.Trim();
                            if (dlr != DialogResult.OK || prefix == string.Empty)
                            {
                                continue;
                            }

                            string tiffFolder = Path.Combine(file, "tiffrgb");
                            string[] textureFiles = Directory.GetFiles(tiffFolder);
                            foreach (string textureFile in textureFiles)
                            {
                                string textureFileName = Path.GetFileName(textureFile);
                                string newName = Path.Combine(tiffFolder, prefix.ToUpper() + textureFileName);
                                File.Move(textureFile, newName);
                            }

                            string[] carFiles = Directory.GetFiles(file);
                            foreach (string carFile in carFiles)
                            {
                                string carFileExtension = Path.GetExtension(carFile).ToLower();
                                switch (carFileExtension)
                                {
                                    case ".mat":
                                        MAT carMaterial = MAT.Load(carFile);
                                        foreach (MATMaterial m in carMaterial.Materials)
                                        {
                                            if (m.HasTexture)
                                            {
                                                m.Texture = prefix + m.Texture;
                                            }
                                        }

                                        carMaterial.Save(carFile);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "C2 Toolkit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCarRenameDropzone_DragOver(object sender, DragEventArgs e)
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

        private DialogResult ShowInputDialog(string title, ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(512, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.Fixed3D;
            inputBox.ClientSize = size;
            inputBox.Text = title;
            inputBox.StartPosition = FormStartPosition.CenterParent;

            TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}
