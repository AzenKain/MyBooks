using Dapper;
using Microsoft.Data.Sqlite;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class BookmarkRepository
    {
        public Bookmark? GetByBookId(int bookId)
        {
            using var db = Database.GetConnection();
            return db.QuerySingleOrDefault<Bookmark>(
                "SELECT * FROM bookmarks WHERE bookId = @BookId",
                new { BookId = bookId }
            );
        }
        public int Insert(Bookmark bookmark)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
            INSERT INTO bookmarks (bookId, elementIndex, percentage)
            VALUES (@BookId, @ElementIndex, @Percentage);
            SELECT last_insert_rowid();
        ", bookmark);
        }
        public void Update(Bookmark bookmark)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                UPDATE bookmarks SET
                    bookId=@BookId,
                    elementIndex=@ElementIndex,                    
                    percentage=@ercentage,
                    updatedAt=CURRENT_TIMESTAMP
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
            db.Execute("DELETE FROM bookmarks WHERE bookId=@BookId", new { BookId = bookId });
        }
    }
}
