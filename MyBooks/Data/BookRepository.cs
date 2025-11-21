using Dapper;
using MyBooks.Models;


namespace MyBooks.Data
{
    public class BookRepository
    {
        public IEnumerable<BookDetail> GetAll()
        {
            using var db = Database.GetConnection();
            return db.Query<BookDetail>("SELECT * FROM book_detail");
        }

        public BookDetail? GetById(int id)
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<BookDetail>("SELECT * FROM book_detail WHERE id=@Id", new { Id = id });
        }

        public int Insert(BookDetail book)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
            INSERT INTO book_detail (title, subtitle, description, isbn, cover_path, published_year)
            VALUES (@Title, @Subtitle, @Description, @ISBN, @CoverPath, @PublishedYear);
            SELECT last_insert_rowid();
        ", book);
        }

        public void Update(BookDetail book)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
            UPDATE book_detail SET
                title=@Title,
                subtitle=@Subtitle,
                description=@Description,
                isbn=@ISBN,
                cover_path=@CoverPath,
                published_year=@PublishedYear,
                updated_at=CURRENT_TIMESTAMP
            WHERE id=@Id
        ", book);
        }

        public void Delete(int id)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_detail WHERE id=@Id", new { Id = id });
        }
    }
}