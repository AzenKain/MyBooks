using Microsoft.Data.Sqlite;
using System.IO;

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
                    publisher TEXT,
                    published_year TIMESTAMP,
                    cover_path TEXT,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS author (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT,
                    description TEXT,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS tags (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT UNIQUE,
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

                CREATE TABLE IF NOT EXISTS book_author (
                    book_id INTEGER NOT NULL REFERENCES book_detail(id),
                    author_id INTEGER NOT NULL REFERENCES author(id),
                    PRIMARY KEY(book_id, author_id)
                );

                CREATE TABLE IF NOT EXISTS book_tag (
                    book_id INTEGER NOT NULL REFERENCES book_detail(id),
                    tag_id INTEGER NOT NULL REFERENCES tags(id),
                    PRIMARY KEY(book_id, tag_id)
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
