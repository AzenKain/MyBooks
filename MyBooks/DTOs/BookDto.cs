using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.DTOs
{
    public class BookDto
    {
        public BookDetail Book { get; set; }

        public  List<Author> authors { get; set; }

        public List<BookMetadata> Metadata { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Bookmark> bookmarks { get; set; }

    }
}
