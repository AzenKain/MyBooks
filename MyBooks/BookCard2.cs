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
    public partial class BookCard2 : UserControl
    {
        public BookCard2()
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

        public int ReadPercent
        {
            get => progressBar1.Value;
            set
            {
                if (value < 0) value = 0;
                if (value > 100) value = 100;
                progressBar1.Value = value;
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
