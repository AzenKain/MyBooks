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
            bookCard1 = new BookCard();
            labelRecommend = new Label();
            flowLayoutPanelRecommend = new FlowLayoutPanel();
            bookCard2 = new BookCard();
            flowLayoutPanelLastReading = new FlowLayoutPanel();
            bookCard3 = new BookCard();
            labelLastReading = new Label();
            flowLayoutPanelTopTreding.SuspendLayout();
            flowLayoutPanelRecommend.SuspendLayout();
            flowLayoutPanelLastReading.SuspendLayout();
            SuspendLayout();
            // 
            // labelTopTrending
            // 
            labelTopTrending.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTopTrending.Location = new Point(3, 0);
            labelTopTrending.Name = "labelTopTrending";
            labelTopTrending.Size = new Size(1373, 32);
            labelTopTrending.TabIndex = 0;
            labelTopTrending.Text = "Top xu hướng";
            labelTopTrending.TextAlign = ContentAlignment.BottomLeft;
            labelTopTrending.Click += label1_Click;
            // 
            // flowLayoutPanelTopTreding
            // 
            flowLayoutPanelTopTreding.AutoScroll = true;
            flowLayoutPanelTopTreding.AutoSize = true;
            flowLayoutPanelTopTreding.Controls.Add(bookCard1);
            flowLayoutPanelTopTreding.Location = new Point(3, 36);
            flowLayoutPanelTopTreding.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelTopTreding.Name = "flowLayoutPanelTopTreding";
            flowLayoutPanelTopTreding.Size = new Size(1582, 270);
            flowLayoutPanelTopTreding.TabIndex = 3;
            flowLayoutPanelTopTreding.WrapContents = false;
            flowLayoutPanelTopTreding.Paint += flowLayoutPanel1_Paint;
            // 
            // bookCard1
            // 
            bookCard1.BackColor = SystemColors.ActiveBorder;
            bookCard1.BookCover = null;
            bookCard1.BookName = null;
            bookCard1.ButtonClickAction = null;
            bookCard1.ButtonText = "button1";
            bookCard1.Location = new Point(3, 5);
            bookCard1.Margin = new Padding(3, 5, 3, 5);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new Size(171, 260);
            bookCard1.TabIndex = 0;
            bookCard1.Load += bookCard1_Load;
            // 
            // labelRecommend
            // 
            labelRecommend.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRecommend.Location = new Point(3, 306);
            labelRecommend.Name = "labelRecommend";
            labelRecommend.Size = new Size(1370, 32);
            labelRecommend.TabIndex = 4;
            labelRecommend.Text = "Sách gợi ý cho bạn";
            labelRecommend.TextAlign = ContentAlignment.BottomLeft;
            labelRecommend.Click += label2_Click;
            // 
            // flowLayoutPanelRecommend
            // 
            flowLayoutPanelRecommend.Controls.Add(bookCard2);
            flowLayoutPanelRecommend.Location = new Point(3, 342);
            flowLayoutPanelRecommend.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelRecommend.Name = "flowLayoutPanelRecommend";
            flowLayoutPanelRecommend.Size = new Size(1582, 269);
            flowLayoutPanelRecommend.TabIndex = 5;
            flowLayoutPanelRecommend.WrapContents = false;
            flowLayoutPanelRecommend.Paint += flowLayoutPanel2_Paint;
            // 
            // bookCard2
            // 
            bookCard2.BackColor = SystemColors.ActiveBorder;
            bookCard2.BookCover = null;
            bookCard2.BookName = null;
            bookCard2.ButtonClickAction = null;
            bookCard2.ButtonText = "button1";
            bookCard2.Location = new Point(3, 5);
            bookCard2.Margin = new Padding(3, 5, 3, 5);
            bookCard2.Name = "bookCard2";
            bookCard2.Size = new Size(171, 260);
            bookCard2.TabIndex = 0;
            bookCard2.Load += bookCard2_Load;
            // 
            // flowLayoutPanelLastReading
            // 
            flowLayoutPanelLastReading.Controls.Add(bookCard3);
            flowLayoutPanelLastReading.Location = new Point(3, 648);
            flowLayoutPanelLastReading.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelLastReading.Name = "flowLayoutPanelLastReading";
            flowLayoutPanelLastReading.Size = new Size(1582, 269);
            flowLayoutPanelLastReading.TabIndex = 6;
            flowLayoutPanelLastReading.WrapContents = false;
            // 
            // bookCard3
            // 
            bookCard3.BackColor = SystemColors.ActiveBorder;
            bookCard3.BookCover = null;
            bookCard3.BookName = null;
            bookCard3.ButtonClickAction = null;
            bookCard3.ButtonText = "button1";
            bookCard3.Location = new Point(3, 5);
            bookCard3.Margin = new Padding(3, 5, 3, 5);
            bookCard3.Name = "bookCard3";
            bookCard3.Size = new Size(171, 260);
            bookCard3.TabIndex = 0;
            // 
            // labelLastReading
            // 
            labelLastReading.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLastReading.Location = new Point(3, 612);
            labelLastReading.Name = "labelLastReading";
            labelLastReading.Size = new Size(1370, 32);
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
            Size = new Size(1588, 921);
            flowLayoutPanelTopTreding.ResumeLayout(false);
            flowLayoutPanelRecommend.ResumeLayout(false);
            flowLayoutPanelLastReading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTopTrending;
        private FlowLayoutPanel flowLayoutPanelTopTreding;
        private Label labelRecommend;
        private FlowLayoutPanel flowLayoutPanelRecommend;
        private BookCard bookCard1;
        private BookCard bookCard2;
        private FlowLayoutPanel flowLayoutPanelLastReading;
        private BookCard bookCard3;
        private Label labelLastReading;
    }
}