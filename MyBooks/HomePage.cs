using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class HomePage : UserControl
    {
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
        private BookCard CreateCard(string name)
        {
            return new BookCard
            {
                BookName = name,
                BookCover = CreatePlaceholderCover(),
                ButtonText = "Read",
                ButtonClickAction = () => MessageBox.Show($"Opening: {name}"),
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

            for (int i = 1; i <= 10; i++)
            {
                BookCard card = CreateCard($"Book {i}");
                flowLayoutPanel1.Controls.Add(card);
            }

            // List thứ hai cũng làm tương tự (nếu bạn muốn)
            for (int i = 1; i <= 3; i++)
            {
                BookCard card = CreateCard($"Last Read {i}");
                flowLayoutPanel2.Controls.Add(card);
            }
        }
    }
}
