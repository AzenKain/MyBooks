using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Models
{
    public class BookDetail
    {
        public int Id { get; set; }                  // id
        public string Title { get; set; } = "";      // title
        public string Subtitle { get; set; } = "";   // subtitle
        public string Description { get; set; } = ""; // description
        public string ISBN { get; set; } = "";       // isbn
        public string CoverPath { get; set; } = "";  // cover_path
        public DateTime? PublishedYear { get; set; } // published_year
        public DateTime CreatedAt { get; set; }      // created_at
        public DateTime UpdatedAt { get; set; }      // updated_at
    }
}
