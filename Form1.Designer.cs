
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
            this.lblTWTDropzone.Size = new System.Drawing.Size(800, 473);
            this.lblTWTDropzone.TabIndex = 1;
            this.lblTWTDropzone.Text = resources.GetString("lblTWTDropzone.Text");
            this.lblTWTDropzone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTWTDropzone.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTWTDropzone_DragDrop);
            this.lblTWTDropzone.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTWTDropzone_DragOver);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.lblTWTDropzone);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(512, 512);
            this.Name = "frmMain";
            this.Text = "C2 Toolkit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTWTDropzone;
    }
}
