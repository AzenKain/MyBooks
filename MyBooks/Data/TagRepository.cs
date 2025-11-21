using Microsoft.Data.Sqlite;
using MyBooks.Models;
using System.Collections.Generic;

namespace MyBooks.Data
{
    public class TagRepository
    {
        public List<Tag> GetAll()
        {
            var list = new List<Tag>();
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tags";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Tag
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    CreatedAt = reader.GetDateTime(2),
                    UpdatedAt = reader.GetDateTime(3)
                });
            }
            return list;
        }

        public void Add(Tag tag)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO tags (name) VALUES (@name)";
            cmd.Parameters.AddWithValue("@name", tag.Name);
            cmd.ExecuteNonQuery();
        }

        public void Update(Tag tag)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE tags SET name=@name, updated_at=CURRENT_TIMESTAMP
                                WHERE id=@id";
            cmd.Parameters.AddWithValue("@name", tag.Name);
            cmd.Parameters.AddWithValue("@id", tag.Id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM tags WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
