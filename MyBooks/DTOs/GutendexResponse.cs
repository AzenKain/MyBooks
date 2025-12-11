using MyBooks.Models;

namespace MyBooks.DTOs
{
    public class GutendexResponse
    {
        public int count { get; set; } = 1;
        public string? next { get; set; } = null;
        public string? previous { get; set; } = null;
        public List<GutendexBook> results { get; set; } = new List<GutendexBook>();
    }
}
