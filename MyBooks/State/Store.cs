using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.State
{
    public record AppState
    {
        public HomeState Home { get; init; } = new();
        public SearchState Search { get; init; } = new();

        public SettingState Setting { get; init; } = new();
    }
    public static class AppStore
    {
        public static AppState States { get; private set; } = new();

        public static event Action<AppState>? Changed;

        public static void Update(Func<AppState, AppState> reducer)
        {
            States = reducer(States);
            Changed?.Invoke(States);
        }
    }
}
