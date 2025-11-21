using Dapper;


namespace MyBooks.Data
{
    public class BookDataFieldRepository
    {
        public void AddFieldToBook(int bookId, int fieldId)
        {
            using var db = Database.GetConnection();
            db.Execute("INSERT INTO book_data_field (book_id, field_id) VALUES (@BookId, @FieldId)", new { BookId = bookId, FieldId = fieldId });
        }

        public void RemoveFieldFromBook(int bookId, int fieldId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_data_field WHERE book_id=@BookId AND field_id=@FieldId", new { BookId = bookId, FieldId = fieldId });
        }

        public void RemoveAllFieldsFromBook(int bookId)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM book_data_field WHERE book_id=@BookId", new { BookId = bookId });
        }
    }
}
