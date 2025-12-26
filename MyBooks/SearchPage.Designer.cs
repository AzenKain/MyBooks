namespace MyBooks
{
    partial class SearchPage
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
            bookCard1 = new BookCard();
            iconButtonAuthor = new FontAwesome.Sharp.IconButton();
            iconButtonPublishers = new FontAwesome.Sharp.IconButton();
            iconButtonTags = new FontAwesome.Sharp.IconButton();
            iconButtonLanguages = new FontAwesome.Sharp.IconButton();
            iconButtonSeries = new FontAwesome.Sharp.IconButton();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            bookCard2 = new BookCard();
            searchBar = new TextBox();
            iconButtonSearch = new FontAwesome.Sharp.IconButton();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(bookCard1);
            flowLayoutPanel1.Location = new Point(3, 2289);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1359, 661);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // bookCard1
            // 
            bookCard1.BackColor = SystemColors.ActiveBorder;
            bookCard1.BookCover = null;
            bookCard1.BookName = null;
            bookCard1.ButtonClickAction = null;
            bookCard1.Location = new Point(3, 5);
            bookCard1.Margin = new Padding(3, 5, 3, 5);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new Size(171, 259);
            bookCard1.TabIndex = 0;
            // 
            // iconButtonAuthor
            // 
            iconButtonAuthor.Anchor = AnchorStyles.None;
            iconButtonAuthor.IconChar = FontAwesome.Sharp.IconChar.PeopleLine;
            iconButtonAuthor.IconColor = Color.Black;
            iconButtonAuthor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonAuthor.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonAuthor.Location = new Point(47, 61);
            iconButtonAuthor.Name = "iconButtonAuthor";
            iconButtonAuthor.Size = new Size(274, 50);
            iconButtonAuthor.TabIndex = 2;
            iconButtonAuthor.Text = "Tấc giả (chưa chọn)";
            iconButtonAuthor.TextAlign = ContentAlignment.MiddleRight;
            iconButtonAuthor.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonAuthor.UseVisualStyleBackColor = true;
            iconButtonAuthor.Click += iconButtonAuthor_Click;
            // 
            // iconButtonPublishers
            // 
            iconButtonPublishers.Anchor = AnchorStyles.None;
            iconButtonPublishers.IconChar = FontAwesome.Sharp.IconChar.Store;
            iconButtonPublishers.IconColor = Color.Black;
            iconButtonPublishers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPublishers.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonPublishers.Location = new Point(303, 117);
            iconButtonPublishers.Name = "iconButtonPublishers";
            iconButtonPublishers.Size = new Size(274, 50);
            iconButtonPublishers.TabIndex = 3;
            iconButtonPublishers.Text = "Nhà phát hành (chưa chọn)";
            iconButtonPublishers.TextAlign = ContentAlignment.MiddleRight;
            iconButtonPublishers.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonPublishers.UseVisualStyleBackColor = true;
            iconButtonPublishers.Click += iconButtonPublishers_Click;
            // 
            // iconButtonTags
            // 
            iconButtonTags.Anchor = AnchorStyles.None;
            iconButtonTags.IconChar = FontAwesome.Sharp.IconChar.Tags;
            iconButtonTags.IconColor = Color.Black;
            iconButtonTags.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonTags.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonTags.Location = new Point(545, 61);
            iconButtonTags.Name = "iconButtonTags";
            iconButtonTags.Size = new Size(274, 50);
            iconButtonTags.TabIndex = 4;
            iconButtonTags.Text = "Chủ đề (chưa chọn)";
            iconButtonTags.TextAlign = ContentAlignment.MiddleRight;
            iconButtonTags.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonTags.UseVisualStyleBackColor = true;
            iconButtonTags.Click += iconButtonTags_Click;
            // 
            // iconButtonLanguages
            // 
            iconButtonLanguages.Anchor = AnchorStyles.None;
            iconButtonLanguages.IconChar = FontAwesome.Sharp.IconChar.Language;
            iconButtonLanguages.IconColor = Color.Black;
            iconButtonLanguages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonLanguages.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonLanguages.Location = new Point(791, 117);
            iconButtonLanguages.Name = "iconButtonLanguages";
            iconButtonLanguages.Size = new Size(274, 50);
            iconButtonLanguages.TabIndex = 5;
            iconButtonLanguages.Text = "Ngôn ngữ (chưa chọn)";
            iconButtonLanguages.TextAlign = ContentAlignment.MiddleRight;
            iconButtonLanguages.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonLanguages.UseVisualStyleBackColor = true;
            iconButtonLanguages.Click += iconButtonLanguages_Click;
            // 
            // iconButtonSeries
            // 
            iconButtonSeries.Anchor = AnchorStyles.None;
            iconButtonSeries.IconChar = FontAwesome.Sharp.IconChar.Chain;
            iconButtonSeries.IconColor = Color.Black;
            iconButtonSeries.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSeries.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSeries.Location = new Point(1028, 61);
            iconButtonSeries.Name = "iconButtonSeries";
            iconButtonSeries.Size = new Size(274, 50);
            iconButtonSeries.TabIndex = 6;
            iconButtonSeries.Text = "Series (chưa chọn)";
            iconButtonSeries.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSeries.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonSeries.UseVisualStyleBackColor = true;
            iconButtonSeries.Click += iconButtonSeries_Click;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelSearch.AutoScroll = true;
            flowLayoutPanelSearch.Controls.Add(bookCard2);
            flowLayoutPanelSearch.Location = new Point(47, 190);
            flowLayoutPanelSearch.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            flowLayoutPanelSearch.Padding = new Padding(10);
            flowLayoutPanelSearch.Size = new Size(1264, 656);
            flowLayoutPanelSearch.TabIndex = 7;
            // 
            // bookCard2
            // 
            bookCard2.BackColor = SystemColors.ActiveBorder;
            bookCard2.BookCover = null;
            bookCard2.BookName = null;
            bookCard2.ButtonClickAction = null;
            bookCard2.Location = new Point(13, 15);
            bookCard2.Margin = new Padding(3, 5, 3, 5);
            bookCard2.Name = "bookCard2";
            bookCard2.Size = new Size(171, 260);
            bookCard2.TabIndex = 0;
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.None;
            searchBar.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchBar.Location = new Point(47, 17);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(1139, 38);
            searchBar.TabIndex = 9;
            searchBar.TextChanged += searchBar_TextContentChanged;
            // 
            // iconButtonSearch
            // 
            iconButtonSearch.Anchor = AnchorStyles.None;
            iconButtonSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButtonSearch.IconColor = Color.Black;
            iconButtonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSearch.IconSize = 32;
            iconButtonSearch.Location = new Point(1208, 17);
            iconButtonSearch.Name = "iconButtonSearch";
            iconButtonSearch.Size = new Size(94, 38);
            iconButtonSearch.TabIndex = 8;
            iconButtonSearch.UseVisualStyleBackColor = true;
            // 
            // SearchPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(searchBar);
            Controls.Add(iconButtonSearch);
            Controls.Add(flowLayoutPanelSearch);
            Controls.Add(iconButtonSeries);
            Controls.Add(iconButtonLanguages);
            Controls.Add(iconButtonTags);
            Controls.Add(iconButtonPublishers);
            Controls.Add(iconButtonAuthor);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SearchPage";
            Size = new Size(1362, 850);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private BookCard bookCard1;
        private FontAwesome.Sharp.IconButton iconButtonAuthor;
        private FontAwesome.Sharp.IconButton iconButtonPublishers;
        private FontAwesome.Sharp.IconButton iconButtonTags;
        private FontAwesome.Sharp.IconButton iconButtonLanguages;
        private FontAwesome.Sharp.IconButton iconButtonSeries;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private BookCard bookCard2;
        private TextBox searchBar;
        private FontAwesome.Sharp.IconButton iconButtonSearch;
    }
}