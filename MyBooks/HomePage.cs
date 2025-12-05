using MyBooks.DTOs;
using MyBooks.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class HomePage : UserControl
    {
        private readonly ViewService viewService = new ViewService();
        private readonly BookService bookService = new BookService();
        public HomePage()
        {
            InitializeComponent();
            LoadFakeBooks();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void bookCard1_Load(object sender, EventArgs e) { }

        private BookCard CreateCard(BookDto dto)
        {
            Image cover = null;

            if (!string.IsNullOrEmpty(dto.book.CoverPath))
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(dto.book.CoverPath);
                    using var ms = new MemoryStream(bytes);
                    cover = Image.FromStream(ms);
                }
                catch
                {
                    cover = null;
                }
            }
            var path = dto.metadatas?.FirstOrDefault()?.FilePath;

            return new BookCard
            {
                BookName = dto.book.Title,
                BookCover = cover,
                ButtonText = "Đọc ngay",
                ButtonClickAction = async () =>
                {
                    var rsp = await viewService.ViewFileAsync(path ?? "");
                    if (rsp.Success == false)
                    {
                        MessageBox.Show($"Lỗi: {rsp.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                Margin = new Padding(10)
            };
        }

        private void LoadFakeBooks()
        {
            flowLayoutPanelTopTreding.Controls.Clear();
            flowLayoutPanelRecommend.Controls.Clear();
            flowLayoutPanelLastReading.Controls.Clear();
            var rsp = bookService.GetAllBook();
            if (rsp.Success == false || rsp.Data == null)
            {
                MessageBox.Show($"Lỗi: {rsp.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var books = rsp.Data;

            foreach (var book in books)
            {
                BookCard card = CreateCard(book);
                flowLayoutPanelTopTreding.Controls.Add(card);
            }

            foreach (var book in books)
            {
                BookCard card = CreateCard(book);
                flowLayoutPanelRecommend.Controls.Add(card);
            }
            foreach (var book in books)
            {
                BookCard card = CreateCard(book);
                flowLayoutPanelLastReading.Controls.Add(card);
            }
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bookCard2_Load(object sender, EventArgs e)
        {

        }
    }
}
