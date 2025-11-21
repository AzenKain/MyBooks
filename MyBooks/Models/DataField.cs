

namespace MyBooks.Models
{
    public class DataField
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty; // publisher, series, tags, authors
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
