using Microsoft.Data.Sqlite;

namespace MyBooks.Data
{
    public static class Database
    {
        private static readonly string DbFile = "database.db";
        private static readonly string ConnStr = $"Data Source={DbFile}";

        public static SqliteConnection GetConnection()
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }

            var conn = new SqliteConnection(ConnStr);
            conn.Open();
            return conn;
        }

        public static void CreateDatabase()
        {
            string createScript = @"
                CREATE TABLE IF NOT EXISTS book_detail (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title TEXT,
                    subtitle TEXT,
                    description TEXT,
                    isbn TEXT,
                    coverPath TEXT,
                    publishedYear TIMESTAMP,
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS book_metadata (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    bookId INTEGER NOT NULL REFERENCES book_detail(id),
                    filePath TEXT,
                    fileType TEXT,
                    fileSize INTEGER,
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS bookmarks (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    bookId INTEGER NOT NULL REFERENCES book_detail(id),
                    note TEXT,
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT,
                    password TEXT,
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS data_field (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT,
                    dataType TEXT CHECK(dataType IN ('publishers','series','tags','authors', 'languages')),
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS book_data_field (
                    bookId INTEGER NOT NULL REFERENCES book_detail(id),
                    fieldId INTEGER NOT NULL REFERENCES data_field(id),
                    PRIMARY KEY(bookId, fieldId)
                );

                CREATE TABLE IF NOT EXISTS book_user (
                    bookId INTEGER NOT NULL REFERENCES book_detail(id),
                    userId INTEGER NOT NULL REFERENCES users(id),
                    PRIMARY KEY(bookId, userId)
                );";
            string[] commands = createScript.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            foreach (string commandText in commands)
            {
                if (!string.IsNullOrWhiteSpace(commandText))
                {
                    try
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = commandText.Trim();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n--- GENERAL ERROR ---");
                        Console.WriteLine($"Command: {commandText.Trim()}");
                        Console.WriteLine($"Message: {ex.Message}");
                        Console.WriteLine($"---------------------\n");
                    }
                }
            }
            conn.Close();
        }
    }
}
