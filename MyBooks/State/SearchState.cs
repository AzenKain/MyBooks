using MyBooks.DTOs;
using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.State
{
    public class SearchState
    {
        public List<BookDto> Items { get; init; } = new();

        public List<DataField> AllAuthors { get; init; } = new();
        public List<DataField> AllLanguages { get; init; } = new();
        public List<DataField> AllPublisher { get; init; } = new();
        public List<DataField> AllTags { get; init; } = new();
        public List<DataField> AllSeries { get; init; } = new();

        public SearchState() { }

        public SearchState(SearchState other)
        {
            Items = other.Items;
            AllAuthors = other.AllAuthors;
            AllLanguages = other.AllLanguages;
            AllPublisher = other.AllPublisher;
            AllTags = other.AllTags;
            AllSeries = other.AllSeries;
        }
    }
}
