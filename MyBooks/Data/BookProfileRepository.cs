using Dapper;


namespace MyBooks.Data
{
    public class BookProfileRepository
    {
        public void AddBookToProfile(int bookId, int profileId)
        {
            using var db = Database.GetConnection();
            db.Execute("INSERT INTO book_Profile (bookId, profileId) VALUES (@BookId, @ProfileId)", new { BookId = bookId, ProfileId = profileId });
        }

        public void RemoveBookFromProfile(int bookId, int profileId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_Profile WHERE bookId=@BookId AND profileId=@ProfileId", new { BookId = bookId, ProfileId = profileId });
        }

        public void RemoveAllBooksFromProfile(int profileId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_Profile WHERE profileId=@ProfileId", new { ProfileId = profileId });
        }

        public void RemoveAllProfilesFromBook(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_Profile WHERE bookId=@BookId", new { BookId = bookId });
        }

        public IEnumerable<int> GetBookIdsByProfileid(int profileId)
        {
            using var db = Database.GetConnection();
            return db.Query<int>("SELECT bookId FROM book_Profile WHERE profileId=@ProfileId", new { ProfileId = profileId });
        }
    }
}
