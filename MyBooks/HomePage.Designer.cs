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
            labelTopTrending = new System.Windows.Forms.Label();
            flowLayoutPanelTopTreding = new System.Windows.Forms.FlowLayoutPanel();
            bookCard1 = new MyBooks.BookCard();
            labelRecommend = new System.Windows.Forms.Label();
            flowLayoutPanelRecommend = new System.Windows.Forms.FlowLayoutPanel();
            bookCard2 = new MyBooks.BookCard();
            flowLayoutPanelLastReading = new System.Windows.Forms.FlowLayoutPanel();
            bookCard3 = new MyBooks.BookCard();
            labelLastReading = new System.Windows.Forms.Label();
            flowLayoutPanelTopTreding.SuspendLayout();
            flowLayoutPanelRecommend.SuspendLayout();
            flowLayoutPanelLastReading.SuspendLayout();
            SuspendLayout();
            // 
            // labelTopTrending
            // 
            labelTopTrending.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            labelTopTrending.Location = new System.Drawing.Point(3, 0);
            labelTopTrending.Name = "labelTopTrending";
            labelTopTrending.Size = new System.Drawing.Size(1373, 32);
            labelTopTrending.TabIndex = 0;
            labelTopTrending.Text = "Top xu hướng";
            labelTopTrending.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            labelTopTrending.Click += label1_Click;
            // 
            // flowLayoutPanelTopTreding
            // 
            flowLayoutPanelTopTreding.AutoScroll = true;
            flowLayoutPanelTopTreding.AutoSize = true;
            flowLayoutPanelTopTreding.Controls.Add(bookCard1);
            flowLayoutPanelTopTreding.Location = new System.Drawing.Point(3, 36);
            flowLayoutPanelTopTreding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowLayoutPanelTopTreding.Name = "flowLayoutPanelTopTreding";
            flowLayoutPanelTopTreding.Size = new System.Drawing.Size(1582, 270);
            flowLayoutPanelTopTreding.TabIndex = 3;
            flowLayoutPanelTopTreding.WrapContents = false;
            flowLayoutPanelTopTreding.Paint += flowLayoutPanel1_Paint;
            // 
            // bookCard1
            // 
            bookCard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            bookCard1.BookCover = null;
            bookCard1.BookName = null;
            bookCard1.ButtonClickAction = null;
            bookCard1.Location = new System.Drawing.Point(3, 5);
            bookCard1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new System.Drawing.Size(171, 260);
            bookCard1.TabIndex = 0;
            bookCard1.Load += bookCard1_Load;
            // 
            // labelRecommend
            // 
            labelRecommend.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            labelRecommend.Location = new System.Drawing.Point(3, 306);
            labelRecommend.Name = "labelRecommend";
            labelRecommend.Size = new System.Drawing.Size(1370, 32);
            labelRecommend.TabIndex = 4;
            labelRecommend.Text = "Sách gợi ý cho bạn";
            labelRecommend.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            labelRecommend.Click += label2_Click;
            // 
            // flowLayoutPanelRecommend
            // 
            flowLayoutPanelRecommend.Controls.Add(bookCard2);
            flowLayoutPanelRecommend.Location = new System.Drawing.Point(3, 342);
            flowLayoutPanelRecommend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowLayoutPanelRecommend.Name = "flowLayoutPanelRecommend";
            flowLayoutPanelRecommend.Size = new System.Drawing.Size(1582, 269);
            flowLayoutPanelRecommend.TabIndex = 5;
            flowLayoutPanelRecommend.WrapContents = false;
            flowLayoutPanelRecommend.Paint += flowLayoutPanel2_Paint;
            // 
            // bookCard2
            // 
            bookCard2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            bookCard2.BookCover = null;
            bookCard2.BookName = null;
            bookCard2.ButtonClickAction = null;
            bookCard2.Location = new System.Drawing.Point(3, 5);
            bookCard2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            bookCard2.Name = "bookCard2";
            bookCard2.Size = new System.Drawing.Size(171, 260);
            bookCard2.TabIndex = 0;
            bookCard2.Load += bookCard2_Load;
            // 
            // flowLayoutPanelLastReading
            // 
            flowLayoutPanelLastReading.Controls.Add(bookCard3);
            flowLayoutPanelLastReading.Location = new System.Drawing.Point(3, 648);
            flowLayoutPanelLastReading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowLayoutPanelLastReading.Name = "flowLayoutPanelLastReading";
            flowLayoutPanelLastReading.Size = new System.Drawing.Size(1582, 269);
            flowLayoutPanelLastReading.TabIndex = 6;
            flowLayoutPanelLastReading.WrapContents = false;
            // 
            // bookCard3
            // 
            bookCard3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            bookCard3.BookCover = null;
            bookCard3.BookName = null;
            bookCard3.ButtonClickAction = null;
            bookCard3.Location = new System.Drawing.Point(3, 5);
            bookCard3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            bookCard3.Name = "bookCard3";
            bookCard3.Size = new System.Drawing.Size(171, 260);
            bookCard3.TabIndex = 0;
            // 
            // labelLastReading
            // 
            labelLastReading.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            labelLastReading.Location = new System.Drawing.Point(3, 612);
            labelLastReading.Name = "labelLastReading";
            labelLastReading.Size = new System.Drawing.Size(1370, 32);
            labelLastReading.TabIndex = 7;
            labelLastReading.Text = "Đọc gần nhất";
            labelLastReading.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            labelLastReading.Click += label3_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(labelLastReading);
            Controls.Add(flowLayoutPanelRecommend);
            Controls.Add(flowLayoutPanelLastReading);
            Controls.Add(labelRecommend);
            Controls.Add(flowLayoutPanelTopTreding);
            Controls.Add(labelTopTrending);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Size = new System.Drawing.Size(1588, 921);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRecommend;
        private BookCard bookCard1;
        private BookCard bookCard2;
        private FlowLayoutPanel flowLayoutPanelLastReading;
        private BookCard bookCard3;
        private Label labelLastReading;
    }
}