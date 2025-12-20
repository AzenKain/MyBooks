namespace MyBooks
{
    partial class MainLayout
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLayout));
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            postToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            uploadToolStripMenuItem = new ToolStripMenuItem();
            contentPanel = new Panel();
            label3 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panelSidebar = new Panel();
            iconButtonBookmark = new FontAwesome.Sharp.IconButton();
            iconButtonTags = new FontAwesome.Sharp.IconButton();
            iconButtonSeries = new FontAwesome.Sharp.IconButton();
            iconButtonLanguage = new FontAwesome.Sharp.IconButton();
            iconButtonPublisher = new FontAwesome.Sharp.IconButton();
            iconButtonAuthor = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(45, 45, 48);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, searchToolStripMenuItem, postToolStripMenuItem, settingToolStripMenuItem, uploadToolStripMenuItem });
            menuStrip1.Location = new Point(220, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.Size = new Size(1362, 72);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.BackColor = Color.Transparent;
            homeToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            homeToolStripMenuItem.ForeColor = Color.Gainsboro;
            homeToolStripMenuItem.Image = (Image)resources.GetObject("homeToolStripMenuItem.Image");
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(127, 72);
            homeToolStripMenuItem.Text = "Trang chủ";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.BackColor = Color.Transparent;
            searchToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            searchToolStripMenuItem.ForeColor = Color.Gainsboro;
            searchToolStripMenuItem.Image = (Image)resources.GetObject("searchToolStripMenuItem.Image");
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(148, 72);
            searchToolStripMenuItem.Text = "Quản lý sách";
            // 
            // postToolStripMenuItem
            // 
            postToolStripMenuItem.BackColor = Color.Transparent;
            postToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            postToolStripMenuItem.ForeColor = Color.Gainsboro;
            postToolStripMenuItem.Image = (Image)resources.GetObject("postToolStripMenuItem.Image");
            postToolStripMenuItem.Name = "postToolStripMenuItem";
            postToolStripMenuItem.Size = new Size(124, 72);
            postToolStripMenuItem.Text = "Cửa hàng";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.BackColor = Color.Transparent;
            settingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem, accountToolStripMenuItem });
            settingToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            settingToolStripMenuItem.ForeColor = Color.Gainsboro;
            settingToolStripMenuItem.Image = (Image)resources.GetObject("settingToolStripMenuItem.Image");
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(105, 72);
            settingToolStripMenuItem.Text = "Cài đặt";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(159, 28);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(159, 28);
            accountToolStripMenuItem.Text = "Account";
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.BackColor = Color.Transparent;
            uploadToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            uploadToolStripMenuItem.ForeColor = Color.Gainsboro;
            uploadToolStripMenuItem.Image = (Image)resources.GetObject("uploadToolStripMenuItem.Image");
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new Size(101, 72);
            uploadToolStripMenuItem.Text = "Tải lên";
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.AutoSize = true;
            contentPanel.BackColor = Color.Transparent;
            contentPanel.Location = new Point(220, 72);
            contentPanel.Margin = new Padding(0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1362, 881);
            contentPanel.TabIndex = 0;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(0, 824);
            label3.Name = "label3";
            label3.Size = new Size(217, 129);
            label3.TabIndex = 7;
            label3.Text = "© 2025 MyBooks. All rights reserved.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(32, 32, 32);
            panelSidebar.Controls.Add(label3);
            panelSidebar.Controls.Add(iconButtonBookmark);
            panelSidebar.Controls.Add(iconButtonTags);
            panelSidebar.Controls.Add(iconButtonSeries);
            panelSidebar.Controls.Add(iconButtonLanguage);
            panelSidebar.Controls.Add(iconButtonPublisher);
            panelSidebar.Controls.Add(iconButtonAuthor);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 953);
            panelSidebar.TabIndex = 1;
            // 
            // iconButtonBookmark
            // 
            iconButtonBookmark.Dock = DockStyle.Top;
            iconButtonBookmark.FlatAppearance.BorderSize = 0;
            iconButtonBookmark.FlatStyle = FlatStyle.Flat;
            iconButtonBookmark.ForeColor = Color.Gainsboro;
            iconButtonBookmark.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            iconButtonBookmark.IconColor = Color.Gainsboro;
            iconButtonBookmark.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonBookmark.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonBookmark.Location = new Point(0, 450);
            iconButtonBookmark.Name = "iconButtonBookmark";
            iconButtonBookmark.Padding = new Padding(10, 0, 20, 0);
            iconButtonBookmark.Size = new Size(220, 60);
            iconButtonBookmark.TabIndex = 6;
            iconButtonBookmark.Text = "Đánh dấu";
            iconButtonBookmark.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonBookmark.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonBookmark.UseVisualStyleBackColor = true;
            iconButtonBookmark.Click += iconButtonBookmark_Click;
            // 
            // iconButtonTags
            // 
            iconButtonTags.Dock = DockStyle.Top;
            iconButtonTags.FlatAppearance.BorderSize = 0;
            iconButtonTags.FlatStyle = FlatStyle.Flat;
            iconButtonTags.ForeColor = Color.Gainsboro;
            iconButtonTags.IconChar = FontAwesome.Sharp.IconChar.Tags;
            iconButtonTags.IconColor = Color.Gainsboro;
            iconButtonTags.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonTags.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonTags.Location = new Point(0, 390);
            iconButtonTags.Name = "iconButtonTags";
            iconButtonTags.Padding = new Padding(10, 0, 20, 0);
            iconButtonTags.Size = new Size(220, 60);
            iconButtonTags.TabIndex = 5;
            iconButtonTags.Text = "Chủ đề";
            iconButtonTags.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonTags.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonTags.UseVisualStyleBackColor = true;
            iconButtonTags.Click += iconButtonTags_Click;
            // 
            // iconButtonSeries
            // 
            iconButtonSeries.Dock = DockStyle.Top;
            iconButtonSeries.FlatAppearance.BorderSize = 0;
            iconButtonSeries.FlatStyle = FlatStyle.Flat;
            iconButtonSeries.ForeColor = Color.Gainsboro;
            iconButtonSeries.IconChar = FontAwesome.Sharp.IconChar.Chain;
            iconButtonSeries.IconColor = Color.Gainsboro;
            iconButtonSeries.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSeries.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSeries.Location = new Point(0, 330);
            iconButtonSeries.Name = "iconButtonSeries";
            iconButtonSeries.Padding = new Padding(10, 0, 20, 0);
            iconButtonSeries.Size = new Size(220, 60);
            iconButtonSeries.TabIndex = 4;
            iconButtonSeries.Text = "Series";
            iconButtonSeries.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonSeries.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonSeries.UseVisualStyleBackColor = true;
            iconButtonSeries.Click += iconButtonSeries_Click;
            // 
            // iconButtonLanguage
            // 
            iconButtonLanguage.Dock = DockStyle.Top;
            iconButtonLanguage.FlatAppearance.BorderSize = 0;
            iconButtonLanguage.FlatStyle = FlatStyle.Flat;
            iconButtonLanguage.ForeColor = Color.Gainsboro;
            iconButtonLanguage.IconChar = FontAwesome.Sharp.IconChar.Language;
            iconButtonLanguage.IconColor = Color.Gainsboro;
            iconButtonLanguage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonLanguage.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonLanguage.Location = new Point(0, 270);
            iconButtonLanguage.Name = "iconButtonLanguage";
            iconButtonLanguage.Padding = new Padding(10, 0, 20, 0);
            iconButtonLanguage.Size = new Size(220, 60);
            iconButtonLanguage.TabIndex = 3;
            iconButtonLanguage.Text = "Ngôn ngữ";
            iconButtonLanguage.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonLanguage.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonLanguage.UseVisualStyleBackColor = true;
            iconButtonLanguage.Click += iconButtonLanguage_Click;
            // 
            // iconButtonPublisher
            // 
            iconButtonPublisher.Dock = DockStyle.Top;
            iconButtonPublisher.FlatAppearance.BorderSize = 0;
            iconButtonPublisher.FlatStyle = FlatStyle.Flat;
            iconButtonPublisher.ForeColor = Color.Gainsboro;
            iconButtonPublisher.IconChar = FontAwesome.Sharp.IconChar.Store;
            iconButtonPublisher.IconColor = Color.Gainsboro;
            iconButtonPublisher.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonPublisher.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonPublisher.Location = new Point(0, 210);
            iconButtonPublisher.Name = "iconButtonPublisher";
            iconButtonPublisher.Padding = new Padding(10, 0, 20, 0);
            iconButtonPublisher.Size = new Size(220, 60);
            iconButtonPublisher.TabIndex = 2;
            iconButtonPublisher.Text = "Nhà phát hành";
            iconButtonPublisher.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonPublisher.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonPublisher.UseVisualStyleBackColor = true;
            iconButtonPublisher.Click += iconButtonPublisher_Click;
            // 
            // iconButtonAuthor
            // 
            iconButtonAuthor.Dock = DockStyle.Top;
            iconButtonAuthor.FlatAppearance.BorderSize = 0;
            iconButtonAuthor.FlatStyle = FlatStyle.Flat;
            iconButtonAuthor.ForeColor = Color.Gainsboro;
            iconButtonAuthor.IconChar = FontAwesome.Sharp.IconChar.PeopleLine;
            iconButtonAuthor.IconColor = Color.Gainsboro;
            iconButtonAuthor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonAuthor.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonAuthor.Location = new Point(0, 150);
            iconButtonAuthor.Name = "iconButtonAuthor";
            iconButtonAuthor.Padding = new Padding(10, 0, 20, 0);
            iconButtonAuthor.Size = new Size(220, 60);
            iconButtonAuthor.TabIndex = 1;
            iconButtonAuthor.Text = "Tác giả";
            iconButtonAuthor.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonAuthor.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonAuthor.UseVisualStyleBackColor = true;
            iconButtonAuthor.Click += iconButtonAuthor_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 150);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // MainLayout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1582, 953);
            Controls.Add(menuStrip1);
            Controls.Add(panelSidebar);
            Controls.Add(contentPanel);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainLayout";
            Text = "MainLayout";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelSidebar.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Panel contentPanel;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem postToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private Label label3;
        private Panel panelSidebar;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton iconButtonAuthor;
        private FontAwesome.Sharp.IconButton iconButtonBookmark;
        private FontAwesome.Sharp.IconButton iconButtonTags;
        private FontAwesome.Sharp.IconButton iconButtonSeries;
        private FontAwesome.Sharp.IconButton iconButtonLanguage;
        private FontAwesome.Sharp.IconButton iconButtonPublisher;
        private PictureBox pictureBox1;
    }
}