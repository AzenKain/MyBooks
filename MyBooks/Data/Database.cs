using Microsoft.Data.Sqlite;

namespace MyBooks.Data
{
    public static class Database
    {
        private static readonly string DbFile = "database.db";
        private static readonly string ConnStr = $"Data Source={DbFile}";
        private static readonly List<SqliteConnection> _activeConnections = new List<SqliteConnection>();
        public static SqliteConnection GetConnection()
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();

                InitDefaultData();
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
                    elementIndex INTEGER NOT NULL,
                    percentage REAL NOT NULL,
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS profiles (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    profileName TEXT,
                    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS settings (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    currentProfile INTEGER,
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

                CREATE TABLE IF NOT EXISTS book_profile (
                    bookId INTEGER NOT NULL REFERENCES book_detail(id),
                    profileId INTEGER NOT NULL REFERENCES profiles(id),
                    PRIMARY KEY(bookId, profileId)
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

        public static void InitDefaultData()
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            using var tran = conn.BeginTransaction();

            long profileId;

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT id FROM profiles LIMIT 1;";
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    cmd.CommandText = "INSERT INTO profiles (profileName) VALUES ('Default');";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT last_insert_rowid();";
                    var lastIdObj = cmd.ExecuteScalar();
                    if (lastIdObj == null || lastIdObj == DBNull.Value)
                    {
                        throw new InvalidOperationException("Failed to retrieve last inserted profile ID.");
                    }
                    profileId = Convert.ToInt64(lastIdObj);
                }
                else
                {
                    profileId = (long)result;
                }
            }

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT id FROM settings LIMIT 1;";
                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    cmd.CommandText = "INSERT INTO settings (currentProfile) VALUES (@pid);";
                }
                else
                {
                    cmd.CommandText = "UPDATE settings SET currentProfile = @pid;";
                }

                cmd.Parameters.AddWithValue("@pid", profileId);
                cmd.ExecuteNonQuery();
            }

            tran.Commit();
            conn.Close();
        }

        public static void DisconnectAll()
        {
            SqliteConnection.ClearAllPools();
        }
    }
}
