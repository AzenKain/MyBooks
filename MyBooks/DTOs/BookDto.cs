using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyBooks.DTOs
{
    public class BookDto
    {
        public BookDetail Book { get; set; } = new BookDetail();

        public  List<DataField> Authors { get; set; } = new List<DataField>();

        public List<DataField> Tags { get; set; } = new List<DataField>();

        public List<DataField> Publisher { get; set; } = new List<DataField>();

        public List<DataField> Series { get; set; } = new List<DataField>();

        public List<DataField> Languages { get; set; } = new List<DataField>();

        public List<BookMetadata> Metadatas { get; set; } = new List<BookMetadata>();

        public Bookmark Bookmarks { get; set; } = new Bookmark();

    }
}
