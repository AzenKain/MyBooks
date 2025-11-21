using Dapper;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class BookMetadataRepository
    {
        public IEnumerable<BookMetadata> GetByBookId(int bookId)
        {
            using var db = Database.GetConnection();
            return db.Query<BookMetadata>("SELECT * FROM book_metadata WHERE book_id=@BookId", new { BookId = bookId });
        }

        public int Insert(BookMetadata metadata)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
            INSERT INTO book_metadata (book_id, file_path, file_type, file_size)
            VALUES (@BookId, @FilePath, @FileType, @FileSize);
            SELECT last_insert_rowid();
        ", metadata);
        }

        public void Delete(int id)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_metadata WHERE id=@Id", new { Id = id });
        }

        public void DeleteByBookId(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_metadata WHERE book_id = @BookId", new { BookId = bookId });
        }
    }
}