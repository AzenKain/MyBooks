using MyBooks.Data;

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
            using var conn = Database.GetConnection();
            Application.Run(new MainLayout());
        }
    }
}