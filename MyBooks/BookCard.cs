

namespace MyBooks
{
    public partial class BookCard : UserControl
    {
        public BookCard()
        {
            InitializeComponent();
        }

        private string bookName = "";
        public string BookName
        {
            get => bookName;
            set
            {
                bookName = value;
                label1.Text = bookName;
            }
        }

        private Image? bookCover;
        public Image? BookCover
        {
            get => bookCover;
            set
            {
                bookCover = value;
                pictureBox1.Image = bookCover;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private Action? buttonAction;
        public Action? ButtonClickAction
        {
            get => buttonAction;
            set => buttonAction = value;
        }

        private void pictureBox1_Click(object? sender, EventArgs e)
        {
            buttonAction?.Invoke();
        }
        private void label1_Click(object sender, EventArgs e) { }

    }
}
