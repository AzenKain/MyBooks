namespace MyBooks
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTopTrending = new Label();
            flowLayoutPanelTopTrending = new FlowLayoutPanel();

            labelRecommend = new Label();
            flowLayoutPanelRecommend = new FlowLayoutPanel();

            labelLastReading = new Label();
            flowLayoutPanelLastReading = new FlowLayoutPanel();

            SuspendLayout();

            // HomePage
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.Control;
            Name = "HomePage";
            Size = new Size(1360, 900);

            // ===== Top Trending =====
            labelTopTrending.Dock = DockStyle.Top;
            labelTopTrending.Height = 36;
            labelTopTrending.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            labelTopTrending.Text = "Top xu hướng";
            labelTopTrending.TextAlign = ContentAlignment.BottomLeft;
            labelTopTrending.Padding = new Padding(8, 0, 0, 0);

            flowLayoutPanelTopTrending.Dock = DockStyle.Top;
            flowLayoutPanelTopTrending.Height = 270;
            flowLayoutPanelTopTrending.AutoScroll = true;
            flowLayoutPanelTopTrending.AutoSize = false;
            flowLayoutPanelTopTrending.WrapContents = false;
            flowLayoutPanelTopTrending.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelTopTrending.Padding = new Padding(8, 4, 8, 4);

            // ===== Recommend =====
            labelRecommend.Dock = DockStyle.Top;
            labelRecommend.Height = 36;
            labelRecommend.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            labelRecommend.Text = "Sách gợi ý cho bạn";
            labelRecommend.TextAlign = ContentAlignment.BottomLeft;
            labelRecommend.Padding = new Padding(8, 0, 0, 0);

            flowLayoutPanelRecommend.Dock = DockStyle.Top;
            flowLayoutPanelRecommend.Height = 260;
            flowLayoutPanelRecommend.AutoScroll = true;
            flowLayoutPanelRecommend.AutoSize = false;
            flowLayoutPanelRecommend.WrapContents = false;
            flowLayoutPanelRecommend.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelRecommend.Padding = new Padding(8, 4, 8, 4);

            // ===== Last Reading =====
            labelLastReading.Dock = DockStyle.Top;
            labelLastReading.Height = 36;
            labelLastReading.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            labelLastReading.Text = "Đọc gần nhất";
            labelLastReading.TextAlign = ContentAlignment.BottomLeft;
            labelLastReading.Padding = new Padding(8, 0, 0, 0);

            flowLayoutPanelLastReading.Dock = DockStyle.Top;
            flowLayoutPanelLastReading.Height = 265;
            flowLayoutPanelLastReading.AutoScroll = true;
            flowLayoutPanelLastReading.AutoSize = false;
            flowLayoutPanelLastReading.WrapContents = false;
            flowLayoutPanelLastReading.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelLastReading.Padding = new Padding(8, 4, 8, 4);

            Controls.Add(flowLayoutPanelLastReading);
            Controls.Add(labelLastReading);

            Controls.Add(flowLayoutPanelRecommend);
            Controls.Add(labelRecommend);

            Controls.Add(flowLayoutPanelTopTrending);
            Controls.Add(labelTopTrending);

            ResumeLayout(false);
        }

        #endregion

        private Label labelTopTrending;
        private FlowLayoutPanel flowLayoutPanelTopTrending;

        private Label labelRecommend;
        private FlowLayoutPanel flowLayoutPanelRecommend;

        private Label labelLastReading;
        private FlowLayoutPanel flowLayoutPanelLastReading;
    }
}
