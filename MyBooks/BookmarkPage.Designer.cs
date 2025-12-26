namespace MyBooks
{
    partial class BookmarkPage
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
            flowLayoutPanelBookmark = new FlowLayoutPanel();
            lblTitle = new Label();
            flowLayoutPanel1.SuspendLayout();
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
            bookCard1.BookCover = null;
            bookCard1.BookName = "";
            bookCard1.ButtonClickAction = null;
            bookCard1.Location = new Point(3, 4);
            bookCard1.Margin = new Padding(3, 4, 3, 4);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new Size(135, 223);
            bookCard1.TabIndex = 0;
            // 
            // flowLayoutPanelBookmark
            // 
            flowLayoutPanelBookmark.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelBookmark.AutoScroll = true;
            flowLayoutPanelBookmark.Location = new Point(6, 77);
            flowLayoutPanelBookmark.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelBookmark.Name = "flowLayoutPanelBookmark";
            flowLayoutPanelBookmark.Padding = new Padding(10);
            flowLayoutPanelBookmark.Size = new Size(1305, 737);
            flowLayoutPanelBookmark.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(6, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(239, 41);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Trang đánh dấu";
            lblTitle.Click += lblTitle_Click;
            // 
            // BookmarkPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitle);
            Controls.Add(flowLayoutPanelBookmark);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BookmarkPage";
            Size = new Size(1362, 850);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private BookCard bookCard1;
        private FlowLayoutPanel flowLayoutPanelBookmark;
        private Label lblTitle;
    }
}
