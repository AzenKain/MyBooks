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
    public partial class PostPage : UserControl
    {
        private GutendexService gutendexService = new GutendexService();
        private int currentPage = 1;
        public PostPage()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();
            labelLoading.Visible = false;
            SearchData();
        }

        private async void SearchData()
        {
            labelLoading.Visible = true;
            labelLoading.BringToFront();

            var rsp = await gutendexService.SearchBooksAsync(textBoxSearch.Text, currentPage);

            labelLoading.Visible = false;

            if (rsp.Success && rsp.Data != null)
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var book in rsp.Data)
                {
                    var bookCard = gutendexService.CreateCard(book);
                    flowLayoutPanel1.Controls.Add(bookCard);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            labelIndexPage.Text = currentPage.ToString();
            SearchData();
        }

        private void iconButtonPageLeft_Click(object sender, EventArgs e)
        {
            if (currentPage <= 1)
            {
                return;
            }
            currentPage--;
            labelIndexPage.Text = currentPage.ToString();
            SearchData();
        }

        private void PostPage_Load(object sender, EventArgs e)
        {

        }

        private void bookCard1_Load(object sender, EventArgs e)
        {

        }

        private void labelLoading_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonPageRight_Click(object sender, EventArgs e)
        {
            if (currentPage >= 2371)
            {
                return;
            }
            currentPage++;
            labelIndexPage.Text = currentPage.ToString();
            SearchData();
        }
    }
}
