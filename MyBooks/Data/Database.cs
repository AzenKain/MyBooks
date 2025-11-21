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

        private static void CreateDatabase()
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS book_detail (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title TEXT,
                    subtitle TEXT,
                    description TEXT,
                    isbn TEXT,
                    cover_path TEXT,
                    published_year TIMESTAMP,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS book_metadata (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    book_id INTEGER NOT NULL REFERENCES book_detail(id),
                    file_path TEXT,
                    file_type TEXT,
                    file_size INTEGER,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS bookmarks (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    book_id INTEGER NOT NULL REFERENCES book_detail(id),
                    note TEXT,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT,
                    password TEXT,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                -- Table data_field (thay enum bằng TEXT)
                CREATE TABLE IF NOT EXISTS data_field (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT,
                    data_type TEXT CHECK(data_type IN ('publisher','series','tags','author')),
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS book_data_field (
                    book_id INTEGER NOT NULL REFERENCES book_detail(id),
                    field_id INTEGER NOT NULL REFERENCES data_field(id),
                    PRIMARY KEY(book_id, field_id)
                );

                CREATE TABLE IF NOT EXISTS book_user (
                    book_id INTEGER NOT NULL REFERENCES book_detail(id),
                    user_id INTEGER NOT NULL REFERENCES users(id),
                    PRIMARY KEY(book_id, user_id)
                );";
            cmd.ExecuteNonQuery();
        }
    }
}
