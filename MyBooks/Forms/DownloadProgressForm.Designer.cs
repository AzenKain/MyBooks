namespace MyBooks.Forms
{
    partial class DownloadProgressForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSpeed;
        private MyBooks.Forms.ModernProgressBar modernProgressBar1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.modernProgressBar1 = new MyBooks.Forms.ModernProgressBar();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 19);
            this.lblTitle.Text = "Downloading";
            // 
            // modernProgressBar1
            // 
            this.modernProgressBar1.Location = new System.Drawing.Point(24, 45);
            this.modernProgressBar1.Maximum = 100;
            this.modernProgressBar1.Name = "modernProgressBar1";
            this.modernProgressBar1.Size = new System.Drawing.Size(360, 12);
            this.modernProgressBar1.Value = 0;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPercent.Location = new System.Drawing.Point(390, 41);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(28, 15);
            this.lblPercent.Text = "0%";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSize.Location = new System.Drawing.Point(21, 70);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(80, 15);
            this.lblSize.Text = "0 / 0 MB";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSpeed.Location = new System.Drawing.Point(300, 70);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(60, 15);
            this.lblSpeed.Text = "0 KB/s";
            // 
            // DownloadProgressForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(440, 115);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.modernProgressBar1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloading";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
