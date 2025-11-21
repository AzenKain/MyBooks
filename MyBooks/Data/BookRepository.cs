using Microsoft.Data.Sqlite;
using MyBooks.Data;
using MyBooks.Models;
using System;
using System.Collections.Generic;

namespace MyBooks.Repositories
{
    public class BookRepository
    {
        // CREATE BOOK
        public int Add(BookDetail book)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO book_detail (title, subtitle, description, isbn, publisher, published_year, cover_path, created_at, updated_at)
                VALUES (@title, @sub, @desc, @isbn, @pub, @pubYear, @cover, @created, @updated);
                SELECT last_insert_rowid();";

            FillBookParams(cmd, book);
            cmd.Parameters.AddWithValue("@created", DateTime.Now);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);

            book.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return book.Id;
        }

        // UPDATE BOOK
        public void Update(BookDetail book)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE book_detail 
                SET title=@title, subtitle=@sub, description=@desc, isbn=@isbn, 
                    publisher=@pub, published_year=@pubYear, cover_path=@cover, updated_at=@updated
                WHERE id=@id";

            FillBookParams(cmd, book);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", book.Id);

            cmd.ExecuteNonQuery();
        }

        // DELETE BOOK
        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            // SQLite mặc định không bật Foreign Key Constraints, nên cần xóa bảng con trước thủ công
            // hoặc bật PRAGMA foreign_keys = ON;
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                DELETE FROM book_author WHERE book_id = @id;
                DELETE FROM book_tag WHERE book_id = @id;
                DELETE FROM book_metadata WHERE book_id = @id;
                DELETE FROM bookmarks WHERE book_id = @id;
                DELETE FROM book_detail WHERE id = @id;";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // GET ALL
        public List<BookDetail> GetAll()
        {
            var list = new List<BookDetail>();
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM book_detail";
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapReaderToBook(reader));
            return list;
        }

        // GET BY ID
        public BookDetail GetById(int id)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM book_detail WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return MapReaderToBook(reader);
            return null;
        }

        public void AddAuthorToBook(int bookId, int authorId)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO book_author (book_id, author_id) VALUES (@bid, @aid)";
            cmd.Parameters.AddWithValue("@bid", bookId);
            cmd.Parameters.AddWithValue("@aid", authorId);
            cmd.ExecuteNonQuery();
        }
        public List<Author> GetAuthorsByBookId(int bookId)
        {
            var list = new List<Author>();
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT a.* FROM author a
                JOIN book_author ba ON a.id = ba.author_id
                WHERE ba.book_id = @bid";
            cmd.Parameters.AddWithValue("@bid", bookId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Author
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),

                });
            }
            return list;
        }
        public void AddTagToBook(int bookId, int tagId)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT OR IGNORE INTO book_tag (book_id, tag_id) VALUES (@bid, @tid)";
            cmd.Parameters.AddWithValue("@bid", bookId);
            cmd.Parameters.AddWithValue("@tid", tagId);
            cmd.ExecuteNonQuery();
        }

        // --- HELPERS ---
        private void FillBookParams(SqliteCommand cmd, BookDetail book)
        {
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@sub", (object)book.Subtitle ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@desc", (object)book.Description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isbn", (object)book.ISBN ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@pub", (object)book.Publisher ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@pubYear", (object)book.PublishedYear ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@cover", (object)book.CoverPath ?? DBNull.Value);
        }

        private BookDetail MapReaderToBook(SqliteDataReader reader)
        {
            return new BookDetail
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Subtitle = reader.IsDBNull(2) ? null : reader.GetString(2),
                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                ISBN = reader.IsDBNull(4) ? null : reader.GetString(4),
                Publisher = reader.IsDBNull(5) ? null : reader.GetString(5),
                PublishedYear = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                CoverPath = reader.IsDBNull(7) ? null : reader.GetString(7),
                CreatedAt = reader.GetDateTime(8),
                UpdatedAt = reader.GetDateTime(9)
            };
        }
    }
}