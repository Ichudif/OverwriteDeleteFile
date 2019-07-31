namespace OverwriteDeleteFiles
{
    partial class ProgressBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Filepb = new System.Windows.Forms.ProgressBar();
            this.OverwriteProgresspb = new System.Windows.Forms.ProgressBar();
            this.Fileslbl = new System.Windows.Forms.Label();
            this.OverwriteProgresslbl = new System.Windows.Forms.Label();
            this.FileOverwriteProgresslbl = new System.Windows.Forms.Label();
            this.FileOverwriteProgresspb = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Filepb
            // 
            this.Filepb.Location = new System.Drawing.Point(3, 21);
            this.Filepb.Name = "Filepb";
            this.Filepb.Size = new System.Drawing.Size(322, 23);
            this.Filepb.TabIndex = 1;
            // 
            // OverwriteProgresspb
            // 
            this.OverwriteProgresspb.Location = new System.Drawing.Point(3, 67);
            this.OverwriteProgresspb.Name = "OverwriteProgresspb";
            this.OverwriteProgresspb.Size = new System.Drawing.Size(322, 23);
            this.OverwriteProgresspb.TabIndex = 2;
            // 
            // Fileslbl
            // 
            this.Fileslbl.AutoSize = true;
            this.Fileslbl.Location = new System.Drawing.Point(3, 3);
            this.Fileslbl.Name = "Fileslbl";
            this.Fileslbl.Size = new System.Drawing.Size(34, 13);
            this.Fileslbl.TabIndex = 3;
            this.Fileslbl.Text = "Files: ";
            // 
            // OverwriteProgresslbl
            // 
            this.OverwriteProgresslbl.AutoSize = true;
            this.OverwriteProgresslbl.Location = new System.Drawing.Point(3, 49);
            this.OverwriteProgresslbl.Name = "OverwriteProgresslbl";
            this.OverwriteProgresslbl.Size = new System.Drawing.Size(99, 13);
            this.OverwriteProgresslbl.TabIndex = 4;
            this.OverwriteProgresslbl.Text = "Overwrite Progress:";
            // 
            // FileOverwriteProgresslbl
            // 
            this.FileOverwriteProgresslbl.AutoSize = true;
            this.FileOverwriteProgresslbl.Location = new System.Drawing.Point(3, 95);
            this.FileOverwriteProgresslbl.Name = "FileOverwriteProgresslbl";
            this.FileOverwriteProgresslbl.Size = new System.Drawing.Size(118, 13);
            this.FileOverwriteProgresslbl.TabIndex = 6;
            this.FileOverwriteProgresslbl.Text = "File Overwrite Progress:";
            // 
            // FileOverwriteProgresspb
            // 
            this.FileOverwriteProgresspb.Location = new System.Drawing.Point(3, 113);
            this.FileOverwriteProgresspb.Name = "FileOverwriteProgresspb";
            this.FileOverwriteProgresspb.Size = new System.Drawing.Size(322, 23);
            this.FileOverwriteProgresspb.TabIndex = 5;
            // 
            // ProgressBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.FileOverwriteProgresslbl);
            this.Controls.Add(this.FileOverwriteProgresspb);
            this.Controls.Add(this.OverwriteProgresslbl);
            this.Controls.Add(this.Fileslbl);
            this.Controls.Add(this.OverwriteProgresspb);
            this.Controls.Add(this.Filepb);
            this.Name = "ProgressBox";
            this.Size = new System.Drawing.Size(330, 143);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Fileslbl;
        private System.Windows.Forms.Label OverwriteProgresslbl;
        private System.Windows.Forms.Label FileOverwriteProgresslbl;
        public System.Windows.Forms.ProgressBar Filepb;
        public System.Windows.Forms.ProgressBar OverwriteProgresspb;
        public System.Windows.Forms.ProgressBar FileOverwriteProgresspb;
    }
}
