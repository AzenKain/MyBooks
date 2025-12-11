namespace MyBooks
{
    partial class SavePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavePage));
            flowLayoutPanel1 = new FlowLayoutPanel();
            bookCard1 = new BookCard();
            searchBar = new SiticoneNetCoreUI.SiticoneButtonTextbox();
            iconButtonAuthor = new FontAwesome.Sharp.IconButton();
            iconButtonPublishers = new FontAwesome.Sharp.IconButton();
            iconButtonTags = new FontAwesome.Sharp.IconButton();
            iconButtonLanguages = new FontAwesome.Sharp.IconButton();
            iconButtonSeries = new FontAwesome.Sharp.IconButton();
            flowLayoutPanelSearch = new FlowLayoutPanel();
            bookCard2 = new BookCard();
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
            bookCard1.ButtonText = "button1";
            bookCard1.Location = new Point(3, 5);
            bookCard1.Margin = new Padding(3, 5, 3, 5);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new Size(171, 259);
            bookCard1.TabIndex = 0;
            // 
            // searchBar
            // 
            searchBar.BackColor = Color.Transparent;
            searchBar.BackgroundColor = Color.White;
            searchBar.BorderColor = Color.DarkGray;
            searchBar.BottomLeftCornerRadius = 20;
            searchBar.BottomRightCornerRadius = 20;
            searchBar.ButtonColor = Color.FromArgb(224, 224, 224);
            searchBar.ButtonCornerRadius = 15;
            searchBar.ButtonHoverColor = Color.FromArgb(211, 211, 211);
            searchBar.ButtonImageHover = null;
            searchBar.ButtonImageIdle = (Image)resources.GetObject("searchBar.ButtonImageIdle");
            searchBar.ButtonImagePress = null;
            searchBar.ButtonPlaceholderColor = Color.Black;
            searchBar.ButtonPlaceholderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            searchBar.ButtonPressColor = Color.FromArgb(224, 224, 224);
            searchBar.Cursor = Cursors.IBeam;
            searchBar.FocusBorderColor = Color.DodgerBlue;
            searchBar.FocusImage = null;
            searchBar.HoverBorderColor = Color.Gray;
            searchBar.HoverImage = null;
            searchBar.IdleImage = null;
            searchBar.Location = new Point(79, 3);
            searchBar.Name = "searchBar";
            searchBar.PlaceholderColor = Color.Gray;
            searchBar.PlaceholderFocusColor = Color.DodgerBlue;
            searchBar.PlaceholderFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            searchBar.PlaceholderText = "Tìm kiếm";
            searchBar.ReadOnlyColors.BackgroundColor = Color.FromArgb(245, 245, 245);
            searchBar.ReadOnlyColors.BorderColor = Color.FromArgb(200, 200, 200);
            searchBar.ReadOnlyColors.ButtonColor = Color.FromArgb(224, 224, 224);
            searchBar.ReadOnlyColors.ButtonPlaceholderColor = Color.Gray;
            searchBar.ReadOnlyColors.PlaceholderColor = Color.FromArgb(150, 150, 150);
            searchBar.ReadOnlyColors.TextColor = Color.FromArgb(100, 100, 100);
            searchBar.RippleColor = Color.White;
            searchBar.Size = new Size(1188, 52);
            searchBar.TabIndex = 1;
            searchBar.TextColor = SystemColors.WindowText;
            searchBar.TextContent = "";
            searchBar.TextLeftMargin = 0;
            searchBar.TopLeftCornerRadius = 20;
            searchBar.TopRightCornerRadius = 20;
            searchBar.ValidationEnabled = false;
            searchBar.TextContentChanged += searchBar_TextContentChanged;
            // 
            // iconButtonAuthor
            // 
            iconButtonAuthor.IconChar = FontAwesome.Sharp.IconChar.PeopleLine;
            iconButtonAuthor.IconColor = Color.Black;
            iconButtonAuthor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonAuthor.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonAuthor.Location = new Point(79, 61);
            iconButtonAuthor.Name = "iconButtonAuthor";
            iconButtonAuthor.Size = new Size(274, 50);
            iconButtonAuthor.TabIndex = 2;
            iconButtonAuthor.Text = "Tấc giả: Chưa chọn";
            iconButtonAuthor.TextAlign = ContentAlignment.MiddleRight;
            iconButtonAuthor.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonAuthor.UseVisualStyleBackColor = true;
            iconButtonAuthor.Click += iconButtonAuthor_Click;
            // 
            // iconButtonPublishers
            // 
            iconButtonPublishers.IconChar = FontAwesome.Sharp.IconChar.Store;
            iconButtonPublishers.IconColor = Color.Black;
            iconButtonPublishers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPublishers.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonPublishers.Location = new Point(305, 117);
            iconButtonPublishers.Name = "iconButtonPublishers";
            iconButtonPublishers.Size = new Size(274, 50);
            iconButtonPublishers.TabIndex = 3;
            iconButtonPublishers.Text = "Nhà phát hành: Chưa chọn";
            iconButtonPublishers.TextAlign = ContentAlignment.MiddleRight;
            iconButtonPublishers.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonPublishers.UseVisualStyleBackColor = true;
            iconButtonPublishers.Click += iconButtonPublishers_Click;
            // 
            // iconButtonTags
            // 
            iconButtonTags.IconChar = FontAwesome.Sharp.IconChar.Tags;
            iconButtonTags.IconColor = Color.Black;
            iconButtonTags.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonTags.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonTags.Location = new Point(545, 61);
            iconButtonTags.Name = "iconButtonTags";
            iconButtonTags.Size = new Size(274, 50);
            iconButtonTags.TabIndex = 4;
            iconButtonTags.Text = "Chủ đề: Chưa chọn";
            iconButtonTags.TextAlign = ContentAlignment.MiddleRight;
            iconButtonTags.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonTags.UseVisualStyleBackColor = true;
            iconButtonTags.Click += iconButtonTags_Click;
            // 
            // iconButtonLanguages
            // 
            iconButtonLanguages.IconChar = FontAwesome.Sharp.IconChar.Language;
            iconButtonLanguages.IconColor = Color.Black;
            iconButtonLanguages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonLanguages.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonLanguages.Location = new Point(772, 117);
            iconButtonLanguages.Name = "iconButtonLanguages";
            iconButtonLanguages.Size = new Size(274, 50);
            iconButtonLanguages.TabIndex = 5;
            iconButtonLanguages.Text = "Ngôn ngữ: Chưa chọn";
            iconButtonLanguages.TextAlign = ContentAlignment.MiddleRight;
            iconButtonLanguages.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonLanguages.UseVisualStyleBackColor = true;
            iconButtonLanguages.Click += iconButtonLanguages_Click;
            // 
            // iconButtonSeries
            // 
            iconButtonSeries.IconChar = FontAwesome.Sharp.IconChar.Chain;
            iconButtonSeries.IconColor = Color.Black;
            iconButtonSeries.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSeries.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSeries.Location = new Point(993, 61);
            iconButtonSeries.Name = "iconButtonSeries";
            iconButtonSeries.Size = new Size(274, 50);
            iconButtonSeries.TabIndex = 6;
            iconButtonSeries.Text = "Series: Chưa chọn";
            iconButtonSeries.TextAlign = ContentAlignment.MiddleRight;
            iconButtonSeries.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButtonSeries.UseVisualStyleBackColor = true;
            iconButtonSeries.Click += iconButtonSeries_Click;
            // 
            // flowLayoutPanelSearch
            // 
            flowLayoutPanelSearch.Controls.Add(bookCard2);
            flowLayoutPanelSearch.Dock = DockStyle.Bottom;
            flowLayoutPanelSearch.Location = new Point(0, 190);
            flowLayoutPanelSearch.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            flowLayoutPanelSearch.Padding = new Padding(10);
            flowLayoutPanelSearch.Size = new Size(1362, 660);
            flowLayoutPanelSearch.TabIndex = 7;
            flowLayoutPanelSearch.WrapContents = false;
            // 
            // bookCard2
            // 
            bookCard2.BackColor = SystemColors.ActiveBorder;
            bookCard2.BookCover = null;
            bookCard2.BookName = null;
            bookCard2.ButtonClickAction = null;
            bookCard2.ButtonText = "button1";
            bookCard2.Location = new Point(13, 15);
            bookCard2.Margin = new Padding(3, 5, 3, 5);
            bookCard2.Name = "bookCard2";
            bookCard2.Size = new Size(171, 260);
            bookCard2.TabIndex = 0;
            // 
            // SavePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanelSearch);
            Controls.Add(iconButtonSeries);
            Controls.Add(iconButtonLanguages);
            Controls.Add(iconButtonTags);
            Controls.Add(iconButtonPublishers);
            Controls.Add(iconButtonAuthor);
            Controls.Add(searchBar);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SavePage";
            Size = new Size(1362, 850);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanelSearch.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private BookCard bookCard1;
        private SiticoneNetCoreUI.SiticoneButtonTextbox searchBar;
        private FontAwesome.Sharp.IconButton iconButtonAuthor;
        private FontAwesome.Sharp.IconButton iconButtonPublishers;
        private FontAwesome.Sharp.IconButton iconButtonTags;
        private FontAwesome.Sharp.IconButton iconButtonLanguages;
        private FontAwesome.Sharp.IconButton iconButtonSeries;
        private FlowLayoutPanel flowLayoutPanelSearch;
        private BookCard bookCard2;
    }
}