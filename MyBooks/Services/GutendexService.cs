using MyBooks.DTOs;
using MyBooks.Models;

namespace MyBooks.Services
{
    public class GutendexService
    {
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
