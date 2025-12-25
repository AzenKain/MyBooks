using FontAwesome.Sharp;
using MyBooks.Constants;
using MyBooks.Models;
using MyBooks.Services;
using System;
using System.Drawing;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class MainLayout : Form
    {
        private IconButton? currentBtn;
        private Panel leftBorderBtn;
        private List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();

        public MainLayout()
        {
            InitializeComponent();
            
            menuItems.Add(homeToolStripMenuItem);
            menuItems.Add(searchToolStripMenuItem);
            menuItems.Add(postToolStripMenuItem);
            menuItems.Add(uploadToolStripMenuItem);
            menuItems.Add(settingToolStripMenuItem);


            homeToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(homeToolStripMenuItem);
                LoadPage(new HomePage());
            };

            searchToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(searchToolStripMenuItem);
                LoadPage(new SearchPage());
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

            settingToolStripMenuItem.Click += (s, e) =>
            {
                HighlightMenu(settingToolStripMenuItem);
                LoadPage(new SettingPage());
            };

            LoadPage(new HomePage());
            HighlightMenu(homeToolStripMenuItem);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            this.leftBorderBtn = new Panel();
            this.leftBorderBtn.Size = new Size(7, 60);
            panelSidebar.Controls.Add(leftBorderBtn);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            ResetMenuHighlight();
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
        private void LoadPageCustom(UserControl page)
        {
            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
            ResetMenuHighlight();
            DisableButton();
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
            if (currentBtn == (IconButton)sender)
            {
                return;
            }
            ActivateButton(sender, RGBColors.color1);
            LoadPage(new SimpleDataPage(DataFieldType.Authors, LoadPageCustom));
        }

        private void iconButtonPublisher_Click(object sender, EventArgs e)
        {
            if (currentBtn == (IconButton)sender)
            {
                return;
            }
            ActivateButton(sender, RGBColors.color2);
            LoadPage(new SimpleDataPage(DataFieldType.Publishers, LoadPageCustom));

        }

        private void iconButtonLanguage_Click(object sender, EventArgs e)
        {
            if (currentBtn == (IconButton)sender)
            {
                return;
            }
            ActivateButton(sender, RGBColors.color3);
            LoadPage(new SimpleDataPage(DataFieldType.Languages, LoadPageCustom));

        }

        private void iconButtonSeries_Click(object sender, EventArgs e)
        {
            if (currentBtn == (IconButton)sender)
            {
                return;
            }
            ActivateButton(sender, RGBColors.color4);
            LoadPage(new SimpleDataPage(DataFieldType.Series, LoadPageCustom));

        }

        private void iconButtonTags_Click(object sender, EventArgs e)
        {
            if (currentBtn == (IconButton)sender)
            {
                return;
            }
            ActivateButton(sender, RGBColors.color5);
            LoadPage(new SimpleDataPage(DataFieldType.Tags, LoadPageCustom));

        }

        private void iconButtonBookmark_Click(object sender, EventArgs e)
        {
            if (currentBtn == (IconButton)sender)
            {
                return;
            }
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
