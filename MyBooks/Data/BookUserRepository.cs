using Dapper;


namespace MyBooks.Data
{
    public class BookUserRepository
    {
        public void AddBookToUser(int bookId, int userId)
        {
            using var db = Database.GetConnection();
            db.Execute("INSERT INTO book_user (book_id, user_id) VALUES (@BookId, @UserId)", new { BookId = bookId, UserId = userId });
        }

        public void RemoveBookFromUser(int bookId, int userId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_user WHERE book_id=@BookId AND user_id=@UserId", new { BookId = bookId, UserId = userId });
        }

        public void RemoveAllBooksFromUser(int userId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_user WHERE user_id=@UserId", new { UserId = userId });
        }

        public void RemoveAllUsersFromBook(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_user WHERE book_id=@BookId", new { BookId = bookId });
        }
    }
}
