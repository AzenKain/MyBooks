using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class MainLayout : Form
    {
        private SearchPage searchPage;

        private IconButton? currentBtn;
        private Panel leftBorderBtn;
        private List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();

        public MainLayout()
        {
            InitializeComponent();
            menuItems.Add(homeToolStripMenuItem);
            menuItems.Add(saveToolStripMenuItem);
            menuItems.Add(postToolStripMenuItem);
            menuItems.Add(uploadToolStripMenuItem);


            homeToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(homeToolStripMenuItem);
                LoadPage(new HomePage());
            };

            saveToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(saveToolStripMenuItem);
                LoadPage(new SavePage());
            };

            postToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(postToolStripMenuItem);
                LoadPage(new PostPage());
            };

            uploadToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(uploadToolStripMenuItem);
                LoadPage(new UploadPage());
            };

            searchPage = new SearchPage();
            searchPage.Dock = DockStyle.Fill;

            toolStripTextBox1.KeyDown += ToolStripTextBox1_KeyDown;

            LoadPage(new HomePage());
            HighlightMenu(homeToolStripMenuItem);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            this.leftBorderBtn = new Panel();
            this.leftBorderBtn.Size = new Size(7, 60);
            panelSidebar.Controls.Add(leftBorderBtn);
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);

            public static Color bluePastel = Color.FromArgb(120, 170, 255);   // Blue pastel
            public static Color redPastel = Color.FromArgb(255, 150, 150);   // Red pastel
            public static Color yellowPastel = Color.FromArgb(255, 215, 120);   // Yellow pastel
            public static Color greenPastel = Color.FromArgb(120, 240, 180);   // Green pastel
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(32, 32, 32);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(32, 32, 32);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void LoadPage(UserControl page)
        {
            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
        }

        private void HighlightMenu(ToolStripMenuItem selectedItem)
        {
            ResetMenuHighlight();
            selectedItem.BackColor = RGBColors.bluePastel;
        }

        private void ResetMenuHighlight()
        {
            foreach (var item in menuItems)
            {
                item.BackColor = Color.Transparent;
            }
        }

        private void ToolStripTextBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = toolStripTextBox1.Text.Trim();
                if (string.IsNullOrEmpty(keyword)) return;

                SearchPage searchPage = new SearchPage();
                searchPage.Dock = DockStyle.Fill;
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(searchPage);
                searchPage.PerformSearch(keyword);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonAuthor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void iconButtonPublisher_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void iconButtonLanguage_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void iconButtonSeries_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void iconButtonTags_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void iconButtonBookmark_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
