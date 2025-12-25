using MyBooks.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Models;

namespace MyBooks.State
{
    public record SettingState
    {
        public Profile currentProfile { get; init; } = new();
    }
}
