using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyBooks
{
    public partial class SearchPage : UserControl
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        public void PerformSearch(string keyword)
        {
            // Xóa hết card cũ
            flowLayoutPanel1.Controls.Clear();

            // Giả lập tìm được 10 kết quả
            for (int i = 1; i <= 10; i++)
            {
                BookCard card = new BookCard
                {
                    BookName = $"Result {i} for '{keyword}'",
                    BookCover = null, // Nếu có ảnh thì set Image
                    ButtonText = "Read",
                    ButtonClickAction = () => MessageBox.Show($"Opening: Result {i}"),
                    Margin = new Padding(10)
                };

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
