
namespace c2toolkit
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTWTDropzone = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMulti = new System.Windows.Forms.TabPage();
            this.tpRename = new System.Windows.Forms.TabPage();
            this.lblCarRenameDropzone = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpMulti.SuspendLayout();
            this.tpRename.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTWTDropzone
            // 
            this.lblTWTDropzone.AllowDrop = true;
            this.lblTWTDropzone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.lblTWTDropzone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTWTDropzone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTWTDropzone.ForeColor = System.Drawing.Color.White;
            this.lblTWTDropzone.Location = new System.Drawing.Point(0, 0);
            this.lblTWTDropzone.Name = "lblTWTDropzone";
            this.lblTWTDropzone.Size = new System.Drawing.Size(776, 423);
            this.lblTWTDropzone.TabIndex = 1;
            this.lblTWTDropzone.Text = resources.GetString("lblTWTDropzone.Text");
            this.lblTWTDropzone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTWTDropzone.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTWTDropzone_DragDrop);
            this.lblTWTDropzone.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTWTDropzone_DragOver);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMulti);
            this.tabControl1.Controls.Add(this.tpRename);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 457);
            this.tabControl1.TabIndex = 2;
            // 
            // tpMulti
            // 
            this.tpMulti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.tpMulti.Controls.Add(this.lblTWTDropzone);
            this.tpMulti.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpMulti.ForeColor = System.Drawing.Color.White;
            this.tpMulti.Location = new System.Drawing.Point(4, 30);
            this.tpMulti.Margin = new System.Windows.Forms.Padding(0);
            this.tpMulti.Name = "tpMulti";
            this.tpMulti.Size = new System.Drawing.Size(776, 423);
            this.tpMulti.TabIndex = 0;
            this.tpMulti.Text = "Multitool";
            // 
            // tpRename
            // 
            this.tpRename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.tpRename.Controls.Add(this.lblCarRenameDropzone);
            this.tpRename.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tpRename.ForeColor = System.Drawing.Color.White;
            this.tpRename.Location = new System.Drawing.Point(4, 30);
            this.tpRename.Name = "tpRename";
            this.tpRename.Padding = new System.Windows.Forms.Padding(3);
            this.tpRename.Size = new System.Drawing.Size(776, 423);
            this.tpRename.TabIndex = 1;
            this.tpRename.Text = "Car texture renaming";
            // 
            // lblCarRenameDropzone
            // 
            this.lblCarRenameDropzone.AllowDrop = true;
            this.lblCarRenameDropzone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(20)))));
            this.lblCarRenameDropzone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCarRenameDropzone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarRenameDropzone.ForeColor = System.Drawing.Color.White;
            this.lblCarRenameDropzone.Location = new System.Drawing.Point(3, 3);
            this.lblCarRenameDropzone.Name = "lblCarRenameDropzone";
            this.lblCarRenameDropzone.Size = new System.Drawing.Size(770, 417);
            this.lblCarRenameDropzone.TabIndex = 2;
            this.lblCarRenameDropzone.Text = "Drop a car folder to add a prefix to the textures";
            this.lblCarRenameDropzone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCarRenameDropzone.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblCarRenameDropzone_DragDrop);
            this.lblCarRenameDropzone.DragOver += new System.Windows.Forms.DragEventHandler(this.lblCarRenameDropzone_DragOver);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(512, 512);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "C2 Toolkit";
            this.tabControl1.ResumeLayout(false);
            this.tpMulti.ResumeLayout(false);
            this.tpRename.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTWTDropzone;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMulti;
        private System.Windows.Forms.TabPage tpRename;
        private System.Windows.Forms.Label lblCarRenameDropzone;
    }
}
