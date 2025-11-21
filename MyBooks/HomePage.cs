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

        // ===========================
        //  TẠO ẢNH GIẢ (PLACEHOLDER)
        // ===========================
        private Image CreatePlaceholderCover()
        {
            Bitmap bmp = new Bitmap(120, 160);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);

                using (Font f = new Font("Arial", 10, FontStyle.Bold))
                using (Brush b = new SolidBrush(Color.DimGray))
                using (StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString("No Cover", f, b, new Rectangle(0, 0, bmp.Width, bmp.Height), sf);
                }
            }
            return bmp;
        }

        // ===========================
        //  TẠO BOOK CARD
        // ===========================
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
                ButtonText = "Read",
                ButtonClickAction = async () => {
                    var rsp = await viewService.ViewFileAsync(path ?? "");
                    if (rsp.Success == false)
                    {
                        MessageBox.Show($"Lỗi: {rsp.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                Margin = new Padding(10)
            };
        }

        // ===========================
        //  LOAD 10 CARD
        // ===========================
        private void LoadFakeBooks()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
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
                flowLayoutPanel1.Controls.Add(card);
            }

            foreach (var book in books)
            {
                BookCard card = CreateCard(book);
                flowLayoutPanel2.Controls.Add(card);
            }
        }
    }
}
