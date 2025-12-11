using MyBooks.Models;


namespace MyBooks.DTOs
{
    public class FilterDto
    {
        public BookDetail Book { get; set; } = new BookDetail();
        public List<DataField> Authors { get; set; } = new List<DataField>();

        public List<DataField> Tags { get; set; } = new List<DataField>();

        public List<DataField> Publisher { get; set; } = new List<DataField>();

        public List<DataField> Series { get; set; } = new List<DataField>();

        public List<DataField> Languages { get; set; } = new List<DataField>();
    }
}
