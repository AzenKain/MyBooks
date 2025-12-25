using MyBooks.DTOs;
using MyBooks.Forms;
using MyBooks.Models;

namespace MyBooks.Services
{
    public class GutendexService
    {
        private readonly MetadataService metadataService = new ();
        private readonly BookService bookService = new ();
        public async Task<ServiceResponse<List<GutendexBook>>> SearchBooksAsync(string query, int page = 1)
        {
            try
            {
                var url = $"https://gutendex.com/books/?search={Uri.EscapeDataString(query)}&mime_type=application%2Fepub%2Bzip&page={page}";
                using var client = new HttpClient();
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new ServiceResponse<List<GutendexBook>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}"
                    };
                }

                var content = await response.Content.ReadAsStringAsync();
                var gutendexResponse =
                    System.Text.Json.JsonSerializer.Deserialize<GutendexResponse>(content);

                return new ServiceResponse<List<GutendexBook>>
                {
                    Success = true,
                    Data = gutendexResponse?.results ?? new List<GutendexBook>()
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<GutendexBook>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public BookCard CreateCard(GutendexBook dto)
        {
            var card = new BookCard
            {
                BookName = dto.title,
                BookCover = null,
                ButtonClickAction = async void () =>
                {
                    try
                    {
                        if (!dto.formats.TryGetValue("application/epub+zip", out var url))
                            return;

                        var rspConfirm = RJMessageBox.Show(
                            $@"Bạn có muốn tải sách '{dto.title}' không?",
                            @"Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (rspConfirm != DialogResult.Yes)
                            return;

                        var baseDir = AppContext.BaseDirectory;
                        var tempDir = Path.Combine(baseDir, "temp");

                        if (!Directory.Exists(tempDir))
                            Directory.CreateDirectory(tempDir);

                        var fileName = $"{Guid.NewGuid()}.epub";
                        var filePath = Path.Combine(tempDir, fileName);
                        try
                        {
                            using var f = new DownloadProgressForm(url, filePath);

                            if (f.ShowDialog() != DialogResult.OK)
                                return;

                            var metaRsp = await metadataService.ReadMetadataAsync(filePath);

                            if (!metaRsp.Success || metaRsp.Data == null)
                            {
                                RJMessageBox.Show(
                                    metaRsp.Message,
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            var metadataDB = new BookMetadata
                            {
                                BookId = 0,
                                FilePath = filePath,
                                FileType = System.IO.Path.GetExtension(filePath),
                                FileSize = new System.IO.FileInfo(filePath).Length,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };
                            metaRsp.Data.Metadatas.Add(metadataDB);

                            var addRsp = bookService.AddABook(metaRsp.Data);

                            if (!addRsp.Success || addRsp.Data == null)
                            {
                                RJMessageBox.Show(
                                    addRsp.Message,
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            using var updatePage = new UpdatePage(addRsp.Data);
                            updatePage.ShowDialog();
                        }
                        finally
                        {
                            if (File.Exists(filePath))
                                File.Delete(filePath);
                        }
                    }
                    catch (Exception e)
                    {
                        RJMessageBox.Show($@"Lỗi: {e}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                Margin = new Padding(10)
            };

            _ = LoadCoverAsync(dto, card);

            return card;
        }


        private async Task LoadCoverAsync(GutendexBook dto, BookCard card)
        {
            if (!dto.formats.TryGetValue("image/jpeg", out var url))
                return;

            try
            {
                using var http = new HttpClient();
                var bytes = await http.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);
                var img = Image.FromStream(ms);

                if (card.InvokeRequired)
                {
                    card.Invoke(() => card.BookCover = img);
                }
                else
                {
                    card.BookCover = img;
                }
            }
            catch
            {
            }
        }


    }
}
