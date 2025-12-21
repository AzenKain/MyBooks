namespace MyBooks
{
    partial class PostPage
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            bookCard = new BookCard();
            iconButtonSearch = new FontAwesome.Sharp.IconButton();
            textBoxSearch = new TextBox();
            iconButtonPageLeft = new FontAwesome.Sharp.IconButton();
            iconButtonPageRight = new FontAwesome.Sharp.IconButton();
            labelIndexPage = new Label();
            labelGutendex = new Label();
            labelLoading = new Label();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(bookCard);
            flowLayoutPanel1.Location = new Point(50, 170);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1260, 576);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // bookCard
            // 
            bookCard.BackColor = SystemColors.ActiveBorder;
            bookCard.BookCover = null;
            bookCard.BookName = "Somename";
            bookCard.ButtonClickAction = null;
            bookCard.Location = new Point(3, 5);
            bookCard.Margin = new Padding(3, 5, 3, 5);
            bookCard.Name = "bookCard";
            bookCard.Size = new Size(171, 259);
            bookCard.TabIndex = 0;
            bookCard.Load += bookCard1_Load;
            // 
            // iconButtonSearch
            // 
            iconButtonSearch.Anchor = AnchorStyles.None;
            iconButtonSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButtonSearch.IconColor = Color.Black;
            iconButtonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSearch.IconSize = 32;
            iconButtonSearch.Location = new Point(1216, 79);
            iconButtonSearch.Name = "iconButtonSearch";
            iconButtonSearch.Size = new Size(94, 38);
            iconButtonSearch.TabIndex = 1;
            iconButtonSearch.UseVisualStyleBackColor = true;
            iconButtonSearch.Click += iconButton1_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.None;
            textBoxSearch.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxSearch.Location = new Point(50, 79);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(1148, 38);
            textBoxSearch.TabIndex = 2;
            // 
            // iconButtonPageLeft
            // 
            iconButtonPageLeft.Anchor = AnchorStyles.None;
            iconButtonPageLeft.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            iconButtonPageLeft.IconChar = FontAwesome.Sharp.IconChar.LeftLong;
            iconButtonPageLeft.IconColor = Color.Black;
            iconButtonPageLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPageLeft.Location = new Point(572, 778);
            iconButtonPageLeft.Name = "iconButtonPageLeft";
            iconButtonPageLeft.Size = new Size(80, 50);
            iconButtonPageLeft.TabIndex = 3;
            iconButtonPageLeft.UseVisualStyleBackColor = true;
            iconButtonPageLeft.Click += iconButtonPageLeft_Click;
            // 
            // iconButtonPageRight
            // 
            iconButtonPageRight.Anchor = AnchorStyles.None;
            iconButtonPageRight.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            iconButtonPageRight.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltRight;
            iconButtonPageRight.IconColor = Color.Black;
            iconButtonPageRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPageRight.Location = new Point(735, 778);
            iconButtonPageRight.Margin = new Padding(0);
            iconButtonPageRight.Name = "iconButtonPageRight";
            iconButtonPageRight.Size = new Size(80, 50);
            iconButtonPageRight.TabIndex = 4;
            iconButtonPageRight.UseVisualStyleBackColor = true;
            iconButtonPageRight.Click += iconButtonPageRight_Click;
            // 
            // labelIndexPage
            // 
            labelIndexPage.Anchor = AnchorStyles.None;
            labelIndexPage.FlatStyle = FlatStyle.Flat;
            labelIndexPage.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelIndexPage.Location = new Point(658, 778);
            labelIndexPage.Name = "labelIndexPage";
            labelIndexPage.Size = new Size(74, 50);
            labelIndexPage.TabIndex = 5;
            labelIndexPage.Text = "1";
            labelIndexPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGutendex
            // 
            labelGutendex.Anchor = AnchorStyles.None;
            labelGutendex.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGutendex.Location = new Point(50, 24);
            labelGutendex.Name = "labelGutendex";
            labelGutendex.Size = new Size(1260, 52);
            labelGutendex.TabIndex = 6;
            labelGutendex.Text = "Gutendex";
            labelGutendex.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelLoading
            // 
            labelLoading.Anchor = AnchorStyles.None;
            labelLoading.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLoading.Location = new Point(583, 126);
            labelLoading.Name = "labelLoading";
            labelLoading.Size = new Size(205, 40);
            labelLoading.TabIndex = 7;
            labelLoading.Text = "Đang tải dữ liệu...";
            labelLoading.Visible = false;
            labelLoading.Click += labelLoading_Click;
            // 
            // PostPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(labelGutendex);
            Controls.Add(labelLoading);
            Controls.Add(labelIndexPage);
            Controls.Add(iconButtonPageRight);
            Controls.Add(iconButtonPageLeft);
            Controls.Add(textBoxSearch);
            Controls.Add(iconButtonSearch);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PostPage";
            Size = new Size(1362, 850);
            Load += PostPage_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private FontAwesome.Sharp.IconButton iconButtonPageLeft;
        private FontAwesome.Sharp.IconButton iconButtonPageRight;

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private BookCard bookCard;
        private FontAwesome.Sharp.IconButton iconButtonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private Label labelIndexPage;
        private Label labelGutendex;
        private Label labelLoading;
    }
}