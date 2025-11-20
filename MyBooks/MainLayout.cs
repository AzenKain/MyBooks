using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class MainLayout : Form
    {
        // Lưu trữ instance SearchPage để không tạo mới mỗi lần
        private SearchPage searchPage;

        public MainLayout()
        {
            InitializeComponent();

            // Click menu load page
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

            // Khởi tạo SearchPage một lần
            searchPage = new SearchPage();
            searchPage.Dock = DockStyle.Fill;

            // Bắt sự kiện Enter
            toolStripTextBox1.KeyDown += ToolStripTextBox1_KeyDown;
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

        private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = toolStripTextBox1.Text.Trim();
                if (string.IsNullOrEmpty(keyword)) return;

                // Load SearchPage lên contentPanel
                SearchPage searchPage = new SearchPage();
                searchPage.Dock = DockStyle.Fill;
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(searchPage);

                // Thực hiện search
                searchPage.PerformSearch(keyword);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

    }
}
