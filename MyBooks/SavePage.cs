using MyBooks.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class SavePage : UserControl
    {
        private List<string> allAuthors = new() { "A", "B", "C", "D" };
        private List<string> allLanguages = new() { "Tiếng Anh", "Tiếng Việt", "Tiếng Nhật" };
        private List<string> allPublisher = new() { "NXB Trẻ", "NXB Kim Đồng" };

        private List<string> selectedAuthors = new();
        private List<string> selectedLanguages = new();
        private List<string> selectedPublisher = new();



        public SavePage()
        {
            InitializeComponent();
        }

        private void iconButtonAuthor_Click(object sender, EventArgs e)
        {
            var popup = new PopupMultiSelect(allAuthors, selectedAuthors);

            popup.Selected += (s, items) =>
            {
                selectedAuthors = items;
                iconButtonAuthor.Text =
                    selectedAuthors.Count == 0
                    ? "Tác giả (chưa chọn)"
                    : $"Tác giả ({selectedAuthors.Count})";
            };

            popup.Show(iconButtonAuthor);
        }

        private void iconButtonTags_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonSeries_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonPublishers_Click(object sender, EventArgs e)
        {
            var popup1 = new PopupMultiSelect(allPublisher, selectedPublisher);

            popup1.Selected += (s, items) =>
            {
                selectedPublisher = items;
                iconButtonPublishers.Text =
                    selectedPublisher.Count == 0
                    ? "Nhà phát hành (chưa chọn)"
                    : $"Nhà phát hành ({selectedPublisher.Count})";
            };

            popup1.Show(iconButtonPublishers);
        }

        private void iconButtonLanguages_Click(object sender, EventArgs e)
        {
            var popup2 = new PopupMultiSelect(allLanguages, selectedLanguages);

            popup2.Selected += (s, items) =>
            {
                selectedLanguages = items;
                iconButtonLanguages.Text =
                    selectedLanguages.Count == 0
                    ? "Ngôn ngữ (chưa chọn)"
                    : $"Ngôn ngữ ({selectedLanguages.Count})";
            };

            popup2.Show(iconButtonLanguages);
        }
    }
}
