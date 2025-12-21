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

                textBoxTitle.Text = metadata.Book.Title ?? "";
                textBoxSubTitle.Text = metadata.Book.Subtitle ?? "";
                textBoxISBN.Text = metadata.Book.ISBN ?? "";
                textBoxPublisher.Text = string.Join(", ", metadata.Publisher.Select(p => p.Name)) ?? "";
                textBoxTags.Text = string.Join(", ", metadata.Tags.Select(p => p.Name)) ?? "";
                textBoxAuthor.Text = string.Join(", ", metadata.Authors.Select(a => a.Name)) ?? "";
                textBoxLanguage.Text = string.Join(", ", metadata.Languages.Select(a => a.Name)) ?? "";
                textBoxSeries.Text = string.Join(", ", metadata.Series.Select(a => a.Name)) ?? "";
                richTextBoxDescription.Text = metadata.Book.Description ?? "";
                dateTimePickerYearPublic.Value = metadata.Book.PublishedYear ?? DateTime.Now;
                byte[] bytes = Convert.FromBase64String(metadata.Book.CoverPath);
                using var ms = new MemoryStream(bytes);
                pictureBoxPreview.Image = Image.FromStream(ms);
                pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bookDto == null)
            {
                RJMessageBox.Show(@"Vui lòng tải lên một file sách trước khi lưu.", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bookDto.Book.Title = textBoxTitle.Text;
            bookDto.Book.Subtitle = textBoxSubTitle.Text;
            bookDto.Book.ISBN = textBoxISBN.Text;
            bookDto.Book.Description = richTextBoxDescription.Text;
            bookDto.Book.PublishedYear = dateTimePickerYearPublic.Value;
            bookDto.Book.UpdatedAt = DateTime.Now;
            bookDto.Book.CreatedAt = DateTime.Now;

            bookDto.Publisher = textBoxPublisher.Text.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).Select(p => new DataField { Name = p, DataType = DataFieldType.Publishers.ToDbValue() }).ToList();
            bookDto.Tags = textBoxTags.Text.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).Select(p => new DataField { Name = p, DataType = DataFieldType.Tags.ToDbValue() }).ToList();
            bookDto.Authors = textBoxAuthor.Text.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).Select(p => new DataField { Name = p, DataType = DataFieldType.Authors.ToDbValue() }).ToList();
            bookDto.Languages = textBoxLanguage.Text.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).Select(p => new DataField { Name = p, DataType = DataFieldType.Languages.ToDbValue() }).ToList();
            bookDto.Series = textBoxSeries.Text.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).Select(p => new DataField { Name = p, DataType = DataFieldType.Series.ToDbValue() }).ToList();

            var rsp = bookService.AddABook(bookDto);
            if (!rsp.Success)
            {
                RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ResetForm();
            RJMessageBox.Show(@"Lưu sách thành công!", @"Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetForm()
        {
            bookDto = null;
            textBoxTitle.Text = "";
            textBoxSubTitle.Text = "";
            textBoxISBN.Text = "";
            textBoxPublisher.Text = "";
            textBoxTags.Text = "";
            textBoxAuthor.Text = "";
            textBoxLanguage.Text = "";
            textBoxSeries.Text = "";
            richTextBoxDescription.Text = "";
            dateTimePickerYearPublic.Value = DateTime.Now;
            pictureBoxPreview.Image = null;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
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
