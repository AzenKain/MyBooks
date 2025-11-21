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
        public BookDetail book { get; set; } = new BookDetail();

        public  List<DataField> authors { get; set; } = new List<DataField>();

        public List<DataField> tags { get; set; } = new List<DataField>();

        public List<DataField> publisher { get; set; } = new List<DataField>();

        public List<DataField> series { get; set; } = new List<DataField>();

        public List<DataField> languages { get; set; } = new List<DataField>();

        public List<BookMetadata> metadatas { get; set; } = new List<BookMetadata>();

        public List<Bookmark> bookmarks { get; set; } = new List<Bookmark>();

    }
}
