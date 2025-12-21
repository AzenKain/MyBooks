using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.Services;
using SiticoneNetCoreUI;
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
    public partial class UpdatePage : Form
    {
        private readonly BookService bookService = new BookService();
        private BookDto? bookDto = null;
        public UpdatePage()
        {
            InitializeComponent();
        }
        public UpdatePage(BookDto dto)
        {
            InitializeComponent();
            UpdateData(dto);
        }

        private void UpdateData(BookDto dto)
        {
            bookDto = dto;
            textBoxTitle.Text = dto.Book.Title ?? "";
            textBoxSubTitle.Text = dto.Book.Subtitle ?? "";
            textBoxISBN.Text = dto.Book.ISBN ?? "";
            textBoxPublisher.Text = string.Join(", ", dto.Publisher.Select(p => p.Name)) ?? "";
            textBoxTags.Text = string.Join(", ", dto.Tags.Select(p => p.Name)) ?? "";
            textBoxAuthor.Text = string.Join(", ", dto.Authors.Select(a => a.Name)) ?? "";
            textBoxLanguage.Text = string.Join(", ", dto.Languages.Select(a => a.Name)) ?? "";
            textBoxSeries.Text = string.Join(", ", dto.Series.Select(a => a.Name)) ?? "";
            richTextBoxDescription.Text = dto.Book.Description ?? "";
            dateTimePickerYearPublic.Value = dto.Book.PublishedYear ?? DateTime.Now;
            byte[] bytes = Convert.FromBase64String(dto.Book.CoverPath);
            using var ms = new MemoryStream(bytes);
            pictureBoxPreview.Image = Image.FromStream(ms);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void labelTitlePage_Click(object sender, EventArgs e)
        {

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

            var rsp = bookService.UpdateABook(bookDto);
            if (!rsp.Success)
            {
                RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
            RJMessageBox.Show(@"Lưu sách thành công!", @"Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
