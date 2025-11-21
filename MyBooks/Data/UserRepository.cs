using Dapper;
using Microsoft.Data.Sqlite;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class UserRepository
    {
        public User? GetByUsername(string username)
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<User>("SELECT * FROM users WHERE username=@Username", new { Username = username });
        }

        public User? GetById(int id)
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<User>("SELECT * FROM users WHERE id=@Id", new { Id = id });
        }

        public IEnumerable<User> GetAll()
        {
            using var db = Database.GetConnection();
            return db.Query<User>("SELECT * FROM users");
        }

        public int Insert(User user)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
                INSERT INTO users (username, password)
                VALUES (@Username, @Password);
                SELECT last_insert_rowid();
            ", user);
        }

        public void Update(User user)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                UPDATE users SET
                    username=@Username,
                    password=@Password,
                    updated_at=CURRENT_TIMESTAMP
                WHERE id=@Id
            ", user);
        }

        public void Delete(int id)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM users WHERE id=@Id", new { Id = id });
        }
    }
}
