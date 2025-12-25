namespace MyBooks
{
    partial class HomePage
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
            labelTopTrending = new Label();
            flowLayoutPanelTopTreding = new FlowLayoutPanel();
            labelRecommend = new Label();
            flowLayoutPanelRecommend = new FlowLayoutPanel();
            flowLayoutPanelLastReading = new FlowLayoutPanel();
            labelLastReading = new Label();
            SuspendLayout();
            // 
            // labelTopTrending
            // 
            labelTopTrending.Anchor = AnchorStyles.None;
            labelTopTrending.BackColor = SystemColors.Control;
            labelTopTrending.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTopTrending.Location = new Point(3, 4);
            labelTopTrending.Name = "labelTopTrending";
            labelTopTrending.Size = new Size(1356, 32);
            labelTopTrending.TabIndex = 0;
            labelTopTrending.Text = "Top xu hướng";
            labelTopTrending.TextAlign = ContentAlignment.BottomLeft;
            labelTopTrending.Click += label1_Click;
            // 
            // flowLayoutPanelTopTreding
            // 
            flowLayoutPanelTopTreding.Anchor = AnchorStyles.None;
            flowLayoutPanelTopTreding.AutoScroll = true;
            flowLayoutPanelTopTreding.AutoSize = true;
            flowLayoutPanelTopTreding.Location = new Point(3, 40);
            flowLayoutPanelTopTreding.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelTopTreding.Name = "flowLayoutPanelTopTreding";
            flowLayoutPanelTopTreding.Size = new Size(1356, 270);
            flowLayoutPanelTopTreding.TabIndex = 3;
            flowLayoutPanelTopTreding.WrapContents = false;
            flowLayoutPanelTopTreding.Paint += flowLayoutPanel1_Paint;
            // 
            // labelRecommend
            // 
            labelRecommend.Anchor = AnchorStyles.None;
            labelRecommend.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRecommend.Location = new Point(0, 314);
            labelRecommend.Name = "labelRecommend";
            labelRecommend.Size = new Size(1359, 32);
            labelRecommend.TabIndex = 4;
            labelRecommend.Text = "Sách gợi ý cho bạn";
            labelRecommend.TextAlign = ContentAlignment.BottomLeft;
            labelRecommend.Click += label2_Click;
            // 
            // flowLayoutPanelRecommend
            // 
            flowLayoutPanelRecommend.Anchor = AnchorStyles.None;
            flowLayoutPanelRecommend.Location = new Point(3, 351);
            flowLayoutPanelRecommend.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelRecommend.Name = "flowLayoutPanelRecommend";
            flowLayoutPanelRecommend.Size = new Size(1356, 260);
            flowLayoutPanelRecommend.TabIndex = 5;
            flowLayoutPanelRecommend.WrapContents = false;
            flowLayoutPanelRecommend.Paint += flowLayoutPanel2_Paint;
            // 
            // flowLayoutPanelLastReading
            // 
            flowLayoutPanelLastReading.Anchor = AnchorStyles.None;
            flowLayoutPanelLastReading.Location = new Point(3, 652);
            flowLayoutPanelLastReading.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelLastReading.Name = "flowLayoutPanelLastReading";
            flowLayoutPanelLastReading.Size = new Size(1356, 265);
            flowLayoutPanelLastReading.TabIndex = 6;
            flowLayoutPanelLastReading.WrapContents = false;
            // 
            // labelLastReading
            // 
            labelLastReading.Anchor = AnchorStyles.None;
            labelLastReading.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLastReading.Location = new Point(0, 615);
            labelLastReading.Name = "labelLastReading";
            labelLastReading.Size = new Size(1359, 32);
            labelLastReading.TabIndex = 7;
            labelLastReading.Text = "Đọc gần nhất";
            labelLastReading.TextAlign = ContentAlignment.BottomLeft;
            labelLastReading.Click += label3_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(labelLastReading);
            Controls.Add(flowLayoutPanelRecommend);
            Controls.Add(flowLayoutPanelLastReading);
            Controls.Add(labelRecommend);
            Controls.Add(flowLayoutPanelTopTreding);
            Controls.Add(labelTopTrending);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HomePage";
            Size = new Size(1362, 921);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTopTrending;
        private FlowLayoutPanel flowLayoutPanelTopTreding;
        private Label labelRecommend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRecommend;
        private FlowLayoutPanel flowLayoutPanelLastReading;
        private Label labelLastReading;
    }
}