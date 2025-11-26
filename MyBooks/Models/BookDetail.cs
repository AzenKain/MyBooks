using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Models
{
    public class BookDetail
    {
        public int Id { get; set; }                  
        public string Title { get; set; } = "";      
        public string Subtitle { get; set; } = ""; 
        public string Description { get; set; } = ""; 
        public string ISBN { get; set; } = "";   
        public string CoverPath { get; set; } = "";  
        public DateTime? PublishedYear { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
