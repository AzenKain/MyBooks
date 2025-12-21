

namespace MyBooks.Models
{
    public enum DataFieldType
    {
        Authors,
        Tags,
        Publishers,
        Series,
        Languages
    }
    public static class DataFieldTypeExtensions
    {
        public static string ToDbValue(this DataFieldType type)
        {
            return type switch
            {
                DataFieldType.Authors => "authors",
                DataFieldType.Tags => "tags",
                DataFieldType.Publishers => "publishers",
                DataFieldType.Series => "series",
                DataFieldType.Languages => "languages",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static DataFieldType FromDbValue(string value)
        {
            return value.ToLower() switch
            {
                "authors" => DataFieldType.Authors,
                "tags" => DataFieldType.Tags,
                "publishers" => DataFieldType.Publishers,
                "series" => DataFieldType.Series,
                "languages" => DataFieldType.Languages,
                _ => throw new ArgumentException($"Unknown DataType: {value}")
            };
        }
    }
    public class DataField
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
