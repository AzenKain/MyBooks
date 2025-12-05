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
            siticoneButtonTextbox1 = new SiticoneNetCoreUI.SiticoneButtonTextbox();
            iconButtonAuthor = new FontAwesome.Sharp.IconButton();
            iconButtonPublishers = new FontAwesome.Sharp.IconButton();
            iconButtonTags = new FontAwesome.Sharp.IconButton();
            iconButtonLanguages = new FontAwesome.Sharp.IconButton();
            iconButtonSeries = new FontAwesome.Sharp.IconButton();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(bookCard1);
            flowLayoutPanel1.Location = new Point(3, 189);
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
            // siticoneButtonTextbox1
            // 
            siticoneButtonTextbox1.BackColor = Color.Transparent;
            siticoneButtonTextbox1.BackgroundColor = Color.White;
            siticoneButtonTextbox1.BorderColor = Color.DarkGray;
            siticoneButtonTextbox1.BottomLeftCornerRadius = 20;
            siticoneButtonTextbox1.BottomRightCornerRadius = 20;
            siticoneButtonTextbox1.ButtonColor = Color.FromArgb(224, 224, 224);
            siticoneButtonTextbox1.ButtonCornerRadius = 15;
            siticoneButtonTextbox1.ButtonHoverColor = Color.FromArgb(211, 211, 211);
            siticoneButtonTextbox1.ButtonImageHover = null;
            siticoneButtonTextbox1.ButtonImageIdle = (Image)resources.GetObject("siticoneButtonTextbox1.ButtonImageIdle");
            siticoneButtonTextbox1.ButtonImagePress = null;
            siticoneButtonTextbox1.ButtonPlaceholderColor = Color.Black;
            siticoneButtonTextbox1.ButtonPlaceholderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            siticoneButtonTextbox1.ButtonPressColor = Color.FromArgb(224, 224, 224);
            siticoneButtonTextbox1.FocusBorderColor = Color.DodgerBlue;
            siticoneButtonTextbox1.FocusImage = null;
            siticoneButtonTextbox1.HoverBorderColor = Color.Gray;
            siticoneButtonTextbox1.HoverImage = null;
            siticoneButtonTextbox1.IdleImage = null;
            siticoneButtonTextbox1.Location = new Point(79, 3);
            siticoneButtonTextbox1.Name = "siticoneButtonTextbox1";
            siticoneButtonTextbox1.PlaceholderColor = Color.Gray;
            siticoneButtonTextbox1.PlaceholderFocusColor = Color.DodgerBlue;
            siticoneButtonTextbox1.PlaceholderFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            siticoneButtonTextbox1.PlaceholderText = "Tìm kiếm";
            siticoneButtonTextbox1.ReadOnlyColors.BackgroundColor = Color.FromArgb(245, 245, 245);
            siticoneButtonTextbox1.ReadOnlyColors.BorderColor = Color.FromArgb(200, 200, 200);
            siticoneButtonTextbox1.ReadOnlyColors.ButtonColor = Color.FromArgb(224, 224, 224);
            siticoneButtonTextbox1.ReadOnlyColors.ButtonPlaceholderColor = Color.Gray;
            siticoneButtonTextbox1.ReadOnlyColors.PlaceholderColor = Color.FromArgb(150, 150, 150);
            siticoneButtonTextbox1.ReadOnlyColors.TextColor = Color.FromArgb(100, 100, 100);
            siticoneButtonTextbox1.RippleColor = Color.White;
            siticoneButtonTextbox1.Size = new Size(1188, 52);
            siticoneButtonTextbox1.TabIndex = 1;
            siticoneButtonTextbox1.TextColor = SystemColors.WindowText;
            siticoneButtonTextbox1.TextContent = "";
            siticoneButtonTextbox1.TextLeftMargin = 0;
            siticoneButtonTextbox1.TopLeftCornerRadius = 20;
            siticoneButtonTextbox1.TopRightCornerRadius = 20;
            siticoneButtonTextbox1.ValidationEnabled = false;
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
            // SavePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(iconButtonSeries);
            Controls.Add(iconButtonLanguages);
            Controls.Add(iconButtonTags);
            Controls.Add(iconButtonPublishers);
            Controls.Add(iconButtonAuthor);
            Controls.Add(siticoneButtonTextbox1);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SavePage";
            Size = new Size(1362, 850);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private BookCard bookCard1;
        private SiticoneNetCoreUI.SiticoneButtonTextbox siticoneButtonTextbox1;
        private FontAwesome.Sharp.IconButton iconButtonAuthor;
        private FontAwesome.Sharp.IconButton iconButtonPublishers;
        private FontAwesome.Sharp.IconButton iconButtonTags;
        private FontAwesome.Sharp.IconButton iconButtonLanguages;
        private FontAwesome.Sharp.IconButton iconButtonSeries;
    }
}