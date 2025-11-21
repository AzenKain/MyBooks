using Microsoft.Data.Sqlite;
using MyBooks.Models;
using System.Collections.Generic;

namespace MyBooks.Data
{
    public class BookmarkRepository
    {
        public List<Bookmark> GetAll()
        {
            var list = new List<Bookmark>();
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bookmarks";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Bookmark
                {
                    Id = reader.GetInt32(0),
                    BookId = reader.GetInt32(1),
                    Note = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    CreatedAt = reader.GetDateTime(3),
                    UpdatedAt = reader.GetDateTime(4)
                });
            }
            return list;
        }

        public void Add(Bookmark bookmark)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO bookmarks (book_id, note) 
                                VALUES (@book_id, @note)";
            cmd.Parameters.AddWithValue("@book_id", bookmark.BookId);
            cmd.Parameters.AddWithValue("@note", bookmark.Note ?? "");
            cmd.ExecuteNonQuery();
        }

        public void Update(Bookmark bookmark)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE bookmarks SET note=@note, updated_at=CURRENT_TIMESTAMP
                                WHERE id=@id";
            cmd.Parameters.AddWithValue("@note", bookmark.Note ?? "");
            cmd.Parameters.AddWithValue("@id", bookmark.Id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM bookmarks WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
