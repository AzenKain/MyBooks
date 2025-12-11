using MyBooks.DTOs;
using MyBooks.Models;

namespace MyBooks.Services
{
    public class GutendexService
    {
        public ServiceResponse<List<GutendexBook>> SearchBooks(string query, int page = 1)
        {
            try
            {
                var url = $"https://gutendex.com/books/?search={Uri.EscapeDataString(query)}&page={page}";
                using var client = new HttpClient();
                var response = client.GetAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return new ServiceResponse<List<GutendexBook>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}"
                    };
                }
                var content = response.Content.ReadAsStringAsync().Result;
                var gutendexResponse = System.Text.Json.JsonSerializer.Deserialize<GutendexResponse>(content);
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
    }
}
