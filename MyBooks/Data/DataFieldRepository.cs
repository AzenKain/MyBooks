using Dapper;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class DataFieldRepository
    {
        public IEnumerable<DataField> GetAll()
        {
            using var db = Database.GetConnection();
            return db.Query<DataField>("SELECT * FROM data_field");
        }

        public IEnumerable<DataField> GetAllByType(string dataType)
        {
            using var db = Database.GetConnection();
            return db.Query<DataField>(
                "SELECT * FROM data_field WHERE dataType=@DataType",
                new { DataType = dataType }
            );
        }

        public DataField? GetById(int id)
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<DataField>("SELECT * FROM data_field WHERE id=@Id", new { Id = id });
        }
        public IEnumerable<DataField> GetListByBookId(int bookId, string dataType)
        {
            using var db = Database.GetConnection();
            return db.Query<DataField>(
                @"SELECT df.*
                  FROM data_field df
                  INNER JOIN book_data_field bdf ON df.id = bdf.fieldId
                  WHERE bdf.bookId = @BookId
                  AND df.dataType = @DataType",
                new { BookId = bookId, DataType = dataType }
            );
        }
        public DataField? GetByNameAndType(string name, string dataType)
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<DataField>(
                "SELECT * FROM data_field WHERE name=@Name AND dataType=@DataType",
                new { Name = name, DataType = dataType }
            );
        }

        public int Insert(DataField field)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
                INSERT INTO data_field (name, dataType)
                VALUES (@Name, @DataType);
                SELECT last_insert_rowid();
            ", field);
        }

        public void Update(DataField field)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                UPDATE data_field SET
                    name=@Name,
                    dataType=@DataType,
                    updated_at=CURRENT_TIMESTAMP
                WHERE id=@Id
            ", field);
        }

        public void Delete(int id)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM data_field WHERE id=@Id", new { Id = id });
        }
    }
}
