using MyBooks.DTOs;
using MyBooks.Services;
using MyBooks.State;
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
    public partial class BookControl : Form
    {
        private BookDto? _dto = null;
        private readonly ViewService viewService = new ViewService();
        private readonly BookService bookService = new BookService();
        public BookControl(BookDto dto)
        {
            InitializeComponent();
            UpdateData(dto);
        }


        private async Task LoadCoverAsync(string? base64)
        {
            pictureBoxImage.Image = null;

            if (string.IsNullOrEmpty(base64))
                return;

            try
            {
                var img = await Task.Run(() =>
                {
                    byte[] bytes = Convert.FromBase64String(base64);
                    using var ms = new MemoryStream(bytes);
                    return Image.FromStream(ms);
                });

                if (pictureBoxImage.InvokeRequired)
                    pictureBoxImage.Invoke(() => pictureBoxImage.Image = img);
                else
                    pictureBoxImage.Image = img;

                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                pictureBoxImage.Image = null;
            }
        }

        private async void UpdateData(BookDto dto)
        {
            _dto = dto;
            labelTitle.Text = string.Join(" ", dto.Book.Title.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            await LoadCoverAsync(dto.Book.CoverPath);

            StringBuilder detail = new();

            if (!string.IsNullOrWhiteSpace(dto.Book.ISBN))
                detail.AppendLine($"ISBN: {dto.Book.ISBN}");

            if (dto.Authors?.Any() == true)
                detail.AppendLine($"Tác giả: {string.Join(", ", dto.Authors.Select(a => a.Name))}");

            if (dto.Tags?.Any() == true)
                detail.AppendLine($"Chủ đề: {string.Join(", ", dto.Tags.Select(a => a.Name))}");

            if (dto.Languages?.Any() == true)
                detail.AppendLine($"Ngôn ngữ: {string.Join(", ", dto.Languages.Select(a => a.Name))}");

            if (dto.Series?.Any() == true)
                detail.AppendLine($"Series: {string.Join(", ", dto.Series.Select(a => a.Name))}");

            if (dto.Publisher?.Any() == true)
                detail.AppendLine($"Nhà phát hành: {string.Join(", ", dto.Publisher.Select(a => a.Name))}");

            if (!string.IsNullOrWhiteSpace(dto.Book.Description))
                detail.AppendLine($"Mô tả: {dto.Book.Description}");

            siticoneTextAreaOther.Text = detail.ToString();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private async void iconButtonView_Click(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                return;
            }
            var rsp = await viewService.ViewFileAsync(_dto);
            if (!rsp.Success)
            {
                RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void iconButtonOpenPath_Click(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                return;
            }
            var rsp1 = viewService.OpenFilePath(_dto.Metadatas[0].FilePath);
            if (!rsp1.Success)
            {
                RJMessageBox.Show(this, rsp1.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private async void iconButtonEdit_Click(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                return;
            }
            UpdatePage updatePage = new UpdatePage(_dto);
            updatePage.ShowDialog();

            var rsp = bookService.GetBookById(_dto.Book.Id);
            if (rsp == null)
            {
                return;
            }

            UpdateData(rsp);

            AppStore.Update(state =>
            {
                return state with
                {
                    Search = new SearchState(state.Search)
                    {
                        Items = state.Search.Items
                            .Select(b => b.Book.Id == _dto.Book.Id ? _dto : b)
                            .ToList()
                    },
                    Home = state.Home with
                    {
                        Items = state.Home.Items
                            .Select(b => b.Book.Id == _dto.Book.Id ? _dto : b)
                            .ToList()
                    }
                };

            });

 

        }

        private void iconButtonDelete_Click(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                return;
            }
            var rsp2 = bookService.DeleteABook(_dto.Book.Id);
            if (!rsp2.Success)
            {
                RJMessageBox.Show(this, rsp2.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rsp = bookService.GetAllBook();
            if (!rsp.Success || rsp.Data == null)
            {
                RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppStore.Update(state => state with
            {
                Home = state.Home with
                {
                    Items = rsp.Data
                }
            });
            AppStore.Update(state =>
            {
                return state with
                {
                    Search = new SearchState(state.Search)
                    {
                        Items = state.Search.Items.Where(b => b.Book.Id != _dto.Book.Id).ToList()
                    }
                };
            });
            RJMessageBox.Show(this, "Đã xóa sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private async void iconButtonBookmark_Click(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                return;
            }
            var rsp1 = await viewService.GetCurrentPosition();
            if (rsp1.Data == null || !rsp1.Success)
            {
                RJMessageBox.Show(this, rsp1.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dto.Bookmarks.ElementIndex = rsp1.Data.ElementIndex;
            _dto.Bookmarks.Percentage = rsp1.Data.Percentage;
            var rsp2 = bookService.UpdateABook(_dto);
            if (rsp2.Data == null || !rsp2.Success)
            {
                RJMessageBox.Show(this, rsp2.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
   
            RJMessageBox.Show(this, "Đã đánh dấu trang thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
