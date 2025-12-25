using MyBooks.Data;
using MyBooks.Services;

namespace MyBooks
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            ApplicationConfiguration.Initialize();
            new AuthService();
            Application.Run(new MainLayout());
        }
    }
}