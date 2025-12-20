using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.Services;
using MyBooks.State;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyBooks
{
    public partial class SearchPage : UserControl
    {
        private List<DataField> selectedAuthors = new();
        private List<DataField> selectedLanguages = new();
        private List<DataField> selectedPublisher = new();
        private List<DataField> selectedTags = new();
        private List<DataField> selectedSeries = new();

        private readonly BookService bookService = new BookService();


        public SearchPage()
        {
            InitializeComponent();
            AppStore.Changed += OnAppStateChanged;
            LoadInitData();

            HandlerSearch();

        }

        private void LoadInitData()
        {
            var dateFieldService = new DateFieldService();
            var rspAuthors = dateFieldService.GetAuthors();
            if (rspAuthors is { Success: true, Data: not null })
            {
                AppStore.Update(state =>
                {
                    var search = state.Search;

                    return state with
                    {
                        Search = new SearchState(search)
                        {
                            AllAuthors = rspAuthors.Data
                        }
                    };
                });
            }
            var rspLanguages = dateFieldService.GetLanguages();
            if (rspLanguages is { Success: true, Data: not null })
            {
                AppStore.Update(state =>
                {
                    var search = state.Search;

                    return state with
                    {
                        Search = new SearchState(search)
                        {
                            AllLanguages = rspLanguages.Data
                        }
                    };
                });
            }
            var rspPublisher = dateFieldService.GetPublishers();
            if (rspPublisher is { Success: true, Data: not null })
            {
                AppStore.Update(state =>
                {
                    var search = state.Search;

                    return state with
                    {
                        Search = new SearchState(search)
                        {
                            AllPublisher = rspPublisher.Data
                        }
                    };
                });
            }
            var rspTags = dateFieldService.GetTags();
            if (rspTags is { Success: true, Data: not null })
            {
                AppStore.Update(state =>
                {
                    var search = state.Search;

                    return state with
                    {
                        Search = new SearchState(search)
                        {
                            AllTags = rspTags.Data
                        }
                    };
                });
            }
            var rspSeries = dateFieldService.GetSeries();
            if (rspSeries is { Success: true, Data: not null })
            {
                AppStore.Update(state =>
                {
                    var search = state.Search;

                    return state with
                    {
                        Search = new SearchState(search)
                        {
                            AllSeries = rspSeries.Data
                        }
                    };
                });
            }
        }


        private void OnAppStateChanged(AppState state)
        {
            flowLayoutPanelSearch.Controls.Clear();
            foreach (var card in AppStore.States.Search.Items.Select(bookService.CreateCard))
            {
                flowLayoutPanelSearch.Controls.Add(card);
            }
        }
        private void HandlerSearch()
        {
            
            var dto = new FilterDto
            {
                Book = new BookDetail
                {
                    Title = searchBar.Text
                },
                Authors = selectedAuthors,
                Languages = selectedLanguages,
                Publisher = selectedPublisher,
                Tags = selectedTags,
                Series = selectedSeries,
            };

            var rsp = bookService.SearchBook(dto);
            if (!rsp.Success || rsp.Data == null)
            {
                RJMessageBox.Show($@"Lỗi: {rsp.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppStore.Update(state =>
            {
                var search = state.Search;
                return state with
                {
                    Search = new SearchState(search)
                    {
                        Items = rsp.Data
                    }
                };
            });

        }

        private void iconButtonAuthor_Click(object sender, EventArgs e)
        {
            var popup = new PopupMultiSelect(AppStore.States.Search.AllAuthors, selectedAuthors);

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
            var popup = new PopupMultiSelect(AppStore.States.Search.AllTags, selectedTags);

            popup.Selected += (_, items) =>
            {
                selectedTags = items;
                iconButtonTags.Text =
                    selectedTags.Count == 0
                    ? "Chủ đề (chưa chọn)"
                    : $"Chủ đề ({selectedTags.Count})";
                HandlerSearch();
            };

            popup.Show(iconButtonTags);
        }

        private void iconButtonSeries_Click(object sender, EventArgs e)
        {
            var popup = new PopupMultiSelect(AppStore.States.Search.AllSeries, selectedSeries);

            popup.Selected += (_, items) =>
            {
                selectedSeries = items;
                iconButtonSeries.Text =
                    selectedSeries.Count == 0
                    ? "Series (chưa chọn)"
                    : $"Series ({selectedSeries.Count})";
                HandlerSearch();
            };

            popup.Show(iconButtonSeries);
        }

        private void iconButtonPublishers_Click(object sender, EventArgs e)
        {
            var popup = new PopupMultiSelect(AppStore.States.Search.AllPublisher, selectedPublisher);

            popup.Selected += (_, items) =>
            {
                selectedPublisher = items;
                iconButtonPublishers.Text =
                    selectedPublisher.Count == 0
                    ? "Nhà phát hành (chưa chọn)"
                    : $"Nhà phát hành ({selectedPublisher.Count})";
                HandlerSearch();
            };

            popup.Show(iconButtonPublishers);
        }

        private void iconButtonLanguages_Click(object sender, EventArgs e)
        {
            var popup = new PopupMultiSelect(AppStore.States.Search.AllLanguages, selectedLanguages);

            popup.Selected += (_, items) =>
            {
                selectedLanguages = items;
                iconButtonLanguages.Text =
                    selectedLanguages.Count == 0
                    ? "Ngôn ngữ (chưa chọn)"
                    : $"Ngôn ngữ ({selectedLanguages.Count})";
                HandlerSearch();
            };

            popup.Show(iconButtonLanguages);
        }
        private void searchBar_TextContentChanged(object sender, EventArgs e)
        {
            HandlerSearch();
        }
    }
}
