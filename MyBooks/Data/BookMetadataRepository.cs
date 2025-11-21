using MyBooks.Data;
using MyBooks.Models;

namespace MyBooks.Repositories
{
    public class MetadataRepository
    {
        public void Add(BookMetadata meta)
        {
            using var conn = Database.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO book_metadata (book_id, file_path, file_type, file_size, created_at, updated_at)
                VALUES (@bid, @path, @type, @size, @created, @updated)";

            cmd.Parameters.AddWithValue("@bid", meta.BookId);
            cmd.Parameters.AddWithValue("@path", meta.FilePath);
            cmd.Parameters.AddWithValue("@type", meta.FileType);
            cmd.Parameters.AddWithValue("@size", meta.FileSize);
            cmd.Parameters.AddWithValue("@created", DateTime.Now);
            cmd.Parameters.AddWithValue("@updated", DateTime.Now);

            cmd.ExecuteNonQuery();
        }

        public List<BookMetadata> GetByBookId(int bookId)
        {
            return new List<BookMetadata>();
        }
    }
}