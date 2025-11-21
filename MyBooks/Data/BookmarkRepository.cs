using Dapper;
using Microsoft.Data.Sqlite;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class BookmarkRepository
    {
        public IEnumerable<Bookmark> GetByBookId(int bookId)
        {
            using var db = Database.GetConnection();
            return db.Query<Bookmark>("SELECT * FROM bookmarks WHERE book_id=@BookId", new { BookId = bookId });
        }

        public int Insert(Bookmark bookmark)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
            INSERT INTO bookmarks (book_id, note)
            VALUES (@BookId, @Note);
            SELECT last_insert_rowid();
        ", bookmark);
        }
        public void Update(Bookmark bookmark)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                UPDATE bookmarks SET
                    book_id=@BookId,
                    note=@Note,
                    updated_at=CURRENT_TIMESTAMP
                WHERE id=@Id
            ", bookmark);
        }

        public void Delete(int id)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM bookmarks WHERE id=@Id", new { Id = id });
        }

        public void DeleteByBookId(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM bookmarks WHERE book_id = @BookId", new { BookId = bookId });
        }
    }
}
