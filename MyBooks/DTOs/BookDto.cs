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
        public BookDetail Book { get; set; } = new BookDetail();

        public  List<Author> authors { get; set; } = new List<Author>();

        public List<BookMetadata> Metadata { get; set; } = new List<BookMetadata>();

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public List<Bookmark> bookmarks { get; set; } = new List<Bookmark>();

    }
}
