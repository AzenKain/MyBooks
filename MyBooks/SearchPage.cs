using System;
using System.Windows.Forms;
using System.Drawing;
using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.Services;

namespace MyBooks
{
    public partial class SearchPage : UserControl
    {
        private readonly BookService bookService = new BookService();
        private readonly ViewService viewService = new ViewService();
        public SearchPage()
        {
            InitializeComponent();
        }

        public void PerformSearch(string keyword)
        {
            // Xóa hết card cũ
            flowLayoutPanel1.Controls.Clear();


            var dto = new FilterDto
            {
                Book = new BookDetail
                {
                    Title = keyword
                }
            };

            var rsp = bookService.SearchBook(dto);
            
            var books = rsp.Data;

            for (int i = 0; i < books?.Count; i++)
            {
                Image cover = null;

                if (!string.IsNullOrEmpty(books[i].Book.CoverPath))
                {
                    try
                    {
                        byte[] bytes = Convert.FromBase64String(books[i].Book.CoverPath);
                        using var ms = new MemoryStream(bytes);
                        cover = Image.FromStream(ms);
                    }
                    catch
                    {
                        cover = null;
                    }
                }
                if (cover == null)
                {
                    continue;
                }
                var path = books[i].Metadatas?.FirstOrDefault()?.FilePath;
                BookCard card = new BookCard
                {
                    BookName = books[i].Book.Title,
                    BookCover = cover,
                    ButtonText = "Read",
                    ButtonClickAction = async () => {
                        var rsp = await viewService.ViewFileAsync(path ?? "");
                        if (rsp.Success == false)
                        {
                            MessageBox.Show($@"Lỗi: {rsp.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    },
                    Margin = new Padding(10)
                };

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
