using MyBooks.DTOs;
using MyBooks.Models;
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
    public partial class UploadPage : UserControl
    {
        private readonly MetadataService metadataService = new MetadataService();
        private readonly BookService bookService = new BookService();
        private BookDto? bookDto = null;
        public UploadPage()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn file sách";
            ofd.Filter = "Sách (*.pdf;*.epub)|*.pdf;*.epub";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                var rsp = await metadataService.ReadMetadataAsync(path);

                if (!rsp.Success || rsp.Data == null)
                {
                    RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var metadata = rsp.Data;
                var metadataDB = new BookMetadata
                {
                    BookId = 0,
                    FilePath = path,
                    FileType = System.IO.Path.GetExtension(path),
                    FileSize = new System.IO.FileInfo(path).Length,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                metadata.Metadatas.Add(metadataDB);
                bookDto = metadata;

                textBox1.Text = metadata.Book.Title ?? "";
                textBox4.Text = metadata.Book.Subtitle ?? "";
                textBox6.Text = string.Join(", ", metadata.Publisher.Select(p => p.Name)) ?? "";
                textBox7.Text = string.Join(", ", metadata.Tags.Select(p => p.Name)) ?? "";
                textBox8.Text = string.Join(", ", metadata.Authors.Select(a => a.Name)) ?? "";
                textBox2.Text = string.Join(", ", metadata.Languages.Select(a => a.Name)) ?? "";
                textBox5.Text = string.Join(", ", metadata.Series.Select(a => a.Name)) ?? "";
                richTextBox1.Text = metadata.Book.Description ?? "";
                dateTimePicker1.Value = metadata.Book.PublishedYear ?? DateTime.Now;
                byte[] bytes = Convert.FromBase64String(metadata.Book.CoverPath);
                using var ms = new MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bookDto == null)
            {
                RJMessageBox.Show(@"Vui lòng tải lên một file sách trước khi lưu.", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bookService.AddABook(bookDto);
            ResetForm();
            RJMessageBox.Show(@"Lưu sách thành công!", @"Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetForm()
        {
            bookDto = null;
            textBox1.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void UploadPage_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
