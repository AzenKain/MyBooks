using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class MainLayout : Form
    {
        private SearchPage searchPage;

        public MainLayout()
        {
            InitializeComponent();

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
        }

        private void LoadPage(UserControl page)
        {
            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
        }

        private void HighlightMenu(ToolStripMenuItem selectedItem)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = SystemColors.Control;
                item.Font = new Font(item.Font, FontStyle.Regular);
            }

            selectedItem.BackColor = Color.LightBlue;
            selectedItem.Font = new Font(selectedItem.Font, FontStyle.Bold);
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

    }
}
