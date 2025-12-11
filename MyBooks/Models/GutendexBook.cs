using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Models
{
    public class GutendexBook
    {
        public int id { get; set; } = 0;
        public string title { get; set; } = "";
        public List<GutendexPerson> authors { get; set; } = new List<GutendexPerson>();
        public List<GutendexPerson> editor { get; set; } = new List<GutendexPerson>();
        public List<GutendexPerson> translators { get; set; } = new List<GutendexPerson>();
        public List<string> subjects { get; set; } = new List<string>();
        public List<string> bookshelves { get; set; } = new List<string>();
        public List<string> languages { get; set; } = new List<string>();
        public List<string> summaries { get; set; } = new List<string>();
        public bool? copyright { get; set; } = null;
        public string media_type { get; set; } = "";
        public Dictionary<string, string> formats { get; set; } = new Dictionary<string, string>();
        public int download_count { get; set; } = 0;
    }
}
