using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.Services;

namespace MyBooks
{
    public partial class SavePage : UserControl
    {
        private readonly List<DataField> allAuthors = new();
        private readonly List<DataField> allLanguages = new();
        private readonly List<DataField> allPublisher = new();

        private List<DataField> selectedAuthors = new();
        private List<DataField> selectedLanguages = new();
        private List<DataField> selectedPublisher = new();

        private readonly BookService bookService = new BookService();


        public SavePage()
        {
            InitializeComponent();
            var dateFieldService = new DateFieldService();
            var rspAuthors = dateFieldService.GetAuthors();
            if (rspAuthors is { Success: true, Data: not null })
            {
                allAuthors = rspAuthors.Data;
            }
            var rspLanguages = dateFieldService.GetLanguages();
            if (rspLanguages is { Success: true, Data: not null })
            {

                allLanguages = rspLanguages.Data;
            }
            var rspPublisher = dateFieldService.GetPublishers();
            if (rspPublisher is { Success: true, Data: not null })
            {
                allPublisher = rspPublisher.Data;
            }

            HandlerSearch();

        }

        private void HandlerSearch()
        {
            flowLayoutPanelSearch.Controls.Clear();
            var dto = new FilterDto
            {
                Book = new BookDetail
                {
                    Title = searchBar.Text
                },
                Authors = selectedAuthors,
                Languages = selectedLanguages,
                Publisher = selectedPublisher
            };

            var rsp = bookService.SearchBook(dto);
            if (!rsp.Success || rsp.Data == null)
            {
                MessageBox.Show($@"Lỗi: {rsp.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var books = rsp.Data;
            foreach (var card in books.Select(bookService.CreateCard))
            {
                flowLayoutPanelSearch.Controls.Add(card);
            }
        }

        private void iconButtonAuthor_Click(object sender, EventArgs e)
        {
            var popup = new PopupMultiSelect(allAuthors, selectedAuthors);

            popup.Selected += (_, items) =>
            {
                selectedAuthors = items;
                iconButtonAuthor.Text =
                    selectedAuthors.Count == 0
                    ? "Tác giả (chưa chọn)"
                    : $"Tác giả ({selectedAuthors.Count})";
                HandlerSearch();
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

            popup1.Selected += (_, items) =>
            {
                selectedPublisher = items;
                iconButtonPublishers.Text =
                    selectedPublisher.Count == 0
                    ? "Nhà phát hành (chưa chọn)"
                    : $"Nhà phát hành ({selectedPublisher.Count})";
                HandlerSearch();
            };

            popup1.Show(iconButtonPublishers);
        }

        private void iconButtonLanguages_Click(object sender, EventArgs e)
        {
            var popup2 = new PopupMultiSelect(allLanguages, selectedLanguages);

            popup2.Selected += (_, items) =>
            {
                selectedLanguages = items;
                iconButtonLanguages.Text =
                    selectedLanguages.Count == 0
                    ? "Ngôn ngữ (chưa chọn)"
                    : $"Ngôn ngữ ({selectedLanguages.Count})";
                HandlerSearch();
            };

            popup2.Show(iconButtonLanguages);
        }
        private void searchBar_TextContentChanged(object sender, EventArgs e)
        {
            HandlerSearch();
        }
    }
}
