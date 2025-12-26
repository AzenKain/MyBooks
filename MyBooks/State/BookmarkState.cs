using MyBooks.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.State
{
    public record BookmarkState
    {
        public List<BookDto> Items { get; init; } = new();
    }
}
