using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.DTOs
{
    public class FilterDto
    {
        public BookDetail book { get; set; } = new BookDetail();
        public List<DataField> authors { get; set; } = new List<DataField>();

        public List<DataField> tags { get; set; } = new List<DataField>();

        public List<DataField> publisher { get; set; } = new List<DataField>();

        public List<DataField> series { get; set; } = new List<DataField>();

        public List<DataField> languages { get; set; } = new List<DataField>();
    }
}
