namespace MyBooks
{
    partial class BookControl
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
            iconButtonView = new FontAwesome.Sharp.IconButton();
            iconButtonOpenPath = new FontAwesome.Sharp.IconButton();
            iconButtonDelete = new FontAwesome.Sharp.IconButton();
            iconButtonBookmark = new FontAwesome.Sharp.IconButton();
            iconButtonEdit = new FontAwesome.Sharp.IconButton();
            pictureBoxImage = new PictureBox();
            labelTitle = new Label();
            siticoneTextAreaOther = new SiticoneNetCoreUI.SiticoneTextArea();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // iconButtonView
            // 
            iconButtonView.Anchor = AnchorStyles.None;
            iconButtonView.BackColor = Color.LightGreen;
            iconButtonView.FlatAppearance.BorderSize = 0;
            iconButtonView.ForeColor = Color.WhiteSmoke;
            iconButtonView.IconChar = FontAwesome.Sharp.IconChar.Readme;
            iconButtonView.IconColor = Color.Black;
            iconButtonView.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonView.Location = new Point(35, 314);
            iconButtonView.Name = "iconButtonView";
            iconButtonView.Size = new Size(156, 52);
            iconButtonView.TabIndex = 0;
            iconButtonView.Text = "Đọc ngay";
            iconButtonView.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonView.UseVisualStyleBackColor = false;
            iconButtonView.Click += iconButtonView_Click;
            // 
            // iconButtonOpenPath
            // 
            iconButtonOpenPath.Anchor = AnchorStyles.None;
            iconButtonOpenPath.BackColor = Color.LightSalmon;
            iconButtonOpenPath.FlatAppearance.BorderSize = 0;
            iconButtonOpenPath.ForeColor = Color.WhiteSmoke;
            iconButtonOpenPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            iconButtonOpenPath.IconColor = Color.Black;
            iconButtonOpenPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonOpenPath.Location = new Point(215, 314);
            iconButtonOpenPath.Name = "iconButtonOpenPath";
            iconButtonOpenPath.Size = new Size(156, 52);
            iconButtonOpenPath.TabIndex = 1;
            iconButtonOpenPath.Text = "Mở thư mục";
            iconButtonOpenPath.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonOpenPath.UseVisualStyleBackColor = false;
            iconButtonOpenPath.Click += iconButtonOpenPath_Click;
            // 
            // iconButtonDelete
            // 
            iconButtonDelete.Anchor = AnchorStyles.None;
            iconButtonDelete.BackColor = Color.LightCoral;
            iconButtonDelete.FlatAppearance.BorderSize = 0;
            iconButtonDelete.ForeColor = Color.WhiteSmoke;
            iconButtonDelete.IconChar = FontAwesome.Sharp.IconChar.DeleteLeft;
            iconButtonDelete.IconColor = Color.Black;
            iconButtonDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonDelete.Location = new Point(101, 381);
            iconButtonDelete.Name = "iconButtonDelete";
            iconButtonDelete.Size = new Size(156, 52);
            iconButtonDelete.TabIndex = 2;
            iconButtonDelete.Text = "Xóa sách";
            iconButtonDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonDelete.UseVisualStyleBackColor = false;
            iconButtonDelete.Click += iconButtonDelete_Click;
            // 
            // iconButtonBookmark
            // 
            iconButtonBookmark.Anchor = AnchorStyles.None;
            iconButtonBookmark.BackColor = Color.Turquoise;
            iconButtonBookmark.FlatAppearance.BorderSize = 0;
            iconButtonBookmark.ForeColor = Color.WhiteSmoke;
            iconButtonBookmark.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            iconButtonBookmark.IconColor = Color.Black;
            iconButtonBookmark.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonBookmark.Location = new Point(302, 381);
            iconButtonBookmark.Name = "iconButtonBookmark";
            iconButtonBookmark.Size = new Size(156, 52);
            iconButtonBookmark.TabIndex = 3;
            iconButtonBookmark.Text = "Đánh dấu";
            iconButtonBookmark.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonBookmark.UseVisualStyleBackColor = false;
            iconButtonBookmark.Click += iconButtonBookmark_Click;
            // 
            // iconButtonEdit
            // 
            iconButtonEdit.Anchor = AnchorStyles.None;
            iconButtonEdit.BackColor = Color.MediumPurple;
            iconButtonEdit.FlatAppearance.BorderSize = 0;
            iconButtonEdit.ForeColor = Color.WhiteSmoke;
            iconButtonEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            iconButtonEdit.IconColor = Color.Black;
            iconButtonEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonEdit.Location = new Point(397, 314);
            iconButtonEdit.Name = "iconButtonEdit";
            iconButtonEdit.Size = new Size(156, 52);
            iconButtonEdit.TabIndex = 4;
            iconButtonEdit.Text = "Chỉnh sửa";
            iconButtonEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonEdit.UseVisualStyleBackColor = false;
            iconButtonEdit.Click += iconButtonEdit_Click;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Anchor = AnchorStyles.None;
            pictureBoxImage.Location = new Point(198, 58);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(183, 239);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 5;
            pictureBoxImage.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.None;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(35, 18);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(518, 28);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Tiêu đề";
            labelTitle.TextAlign = ContentAlignment.TopCenter;
            labelTitle.Click += labelTitle_Click;
            // 
            // siticoneTextAreaOther
            // 
            siticoneTextAreaOther.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            siticoneTextAreaOther.BorderStyle = BorderStyle.None;
            siticoneTextAreaOther.Font = new Font("Century Gothic", 10F);
            siticoneTextAreaOther.Location = new Point(35, 451);
            siticoneTextAreaOther.Margin = new Padding(5);
            siticoneTextAreaOther.MinimumSize = new Size(100, 100);
            siticoneTextAreaOther.Multiline = true;
            siticoneTextAreaOther.Name = "siticoneTextAreaOther";
            siticoneTextAreaOther.PlaceholderText = "Thông tin khác...";
            siticoneTextAreaOther.ScrollBars = ScrollBars.Vertical;
            siticoneTextAreaOther.Size = new Size(518, 275);
            siticoneTextAreaOther.TabIndex = 8;
            // 
            // BookControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 753);
            Controls.Add(siticoneTextAreaOther);
            Controls.Add(labelTitle);
            Controls.Add(pictureBoxImage);
            Controls.Add(iconButtonEdit);
            Controls.Add(iconButtonBookmark);
            Controls.Add(iconButtonDelete);
            Controls.Add(iconButtonOpenPath);
            Controls.Add(iconButtonView);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "BookControl";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "BookDetail";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButtonView;
        private FontAwesome.Sharp.IconButton iconButtonOpenPath;
        private FontAwesome.Sharp.IconButton iconButtonDelete;
        private FontAwesome.Sharp.IconButton iconButtonBookmark;
        private FontAwesome.Sharp.IconButton iconButtonEdit;
        private PictureBox pictureBoxImage;
        private Label labelTitle;
        private SiticoneNetCoreUI.SiticoneTextArea siticoneTextAreaOther;
    }
}