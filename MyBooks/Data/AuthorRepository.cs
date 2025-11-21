using Microsoft.Data.Sqlite;
using MyBooks.Data;
using MyBooks.Models;
using System;
using System.Collections.Generic;

namespace MyBooks.Repositories
{
    public class AuthorRepository
    {
        // CREATE
        public void Add(Author author)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO author (name, description, created_at, updated_at) 
                VALUES (@name, @desc, @created, @updated);
                SELECT last_insert_rowid();";

            cmd.Parameters.AddWithValue("@name", author.Name);
            cmd.Parameters.AddWithValue("@desc", (object)author.Description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@created", DateTime.Now);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);
            author.Id = Convert.ToInt32(cmd.ExecuteScalar());
        }

        // READ ALL
        public List<Author> GetAll()
        {
            var list = new List<Author>();
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM author";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapReaderToAuthor(reader));
            }
            return list;
        }

        // READ BY ID
        public Author GetById(int id)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM author WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapReaderToAuthor(reader);
            }
            return null;
        }

        // UPDATE
        public void Update(Author author)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE author 
                SET name = @name, description = @desc, updated_at = @updated 
                WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", author.Id);
            cmd.Parameters.AddWithValue("@name", author.Name);
            cmd.Parameters.AddWithValue("@desc", (object)author.Description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM author WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // Helper mapping function
        private Author MapReaderToAuthor(SqliteDataReader reader)
        {
            return new Author
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                CreatedAt = reader.GetDateTime(3),
                UpdatedAt = reader.GetDateTime(4)
            };
        }
    }
}