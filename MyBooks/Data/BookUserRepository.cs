using Dapper;


namespace MyBooks.Data
{
    public class BookUserRepository
    {
        public void AddBookToUser(int bookId, int userId)
        {
            using var db = Database.GetConnection();
            db.Execute("INSERT INTO book_user (bookId, userId) VALUES (@BookId, @UserId)", new { BookId = bookId, UserId = userId });
        }

        public void RemoveBookFromUser(int bookId, int userId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_user WHERE bookId=@BookId AND userId=@UserId", new { BookId = bookId, UserId = userId });
        }

        public void RemoveAllBooksFromUser(int userId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_user WHERE userId=@UserId", new { UserId = userId });
        }

        public void RemoveAllUsersFromBook(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_user WHERE bookId=@BookId", new { BookId = bookId });
        }
    }
}
