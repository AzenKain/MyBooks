using MyBooks.Services;
using MyBooks.State;
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
    public partial class BookmarkPage : UserControl
    {
        private readonly BookService bookService = new BookService();
        public BookmarkPage()
        {
            InitializeComponent();
            AppStore.Changed += OnAppStateChanged;
            var rsp = bookService.GetAllBookHasBookmark();
            if (!rsp.Success || rsp.Data == null)
            {
                RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppStore.Update(state => state with
            {
                Bookmark = state.Bookmark with
                {
                    Items = rsp.Data
                }
            });
        }
        private void OnAppStateChanged(AppState state)
        {
            flowLayoutPanelBookmark.Controls.Clear();

            foreach (var card in state.Bookmark.Items.Select(bookService.CreateCard2))
            {
                flowLayoutPanelBookmark.Controls.Add(card);

            }

        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
