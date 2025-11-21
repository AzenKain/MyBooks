using Dapper;


namespace MyBooks.Data
{
    public class BookDataFieldRepository
    {
        public void AddFieldToBook(int bookId, int fieldId)
        {
            using var db = Database.GetConnection();
            db.Execute("INSERT INTO book_data_field (bookId, fieldId) VALUES (@BookId, @FieldId)", new { BookId = bookId, FieldId = fieldId });
        }

        public void RemoveFieldFromBook(int bookId, int fieldId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_data_field WHERE bookId=@BookId AND fieldId=@FieldId", new { BookId = bookId, FieldId = fieldId });
        }

        public void RemoveAllFieldsFromBook(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_data_field WHERE bookId=@BookId", new { BookId = bookId });
        }
    }
}
