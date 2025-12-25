using Dapper;
using Microsoft.Data.Sqlite;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class ProfileRepository
    {

        public Profile? GetById(int id)
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<Profile>("SELECT * FROM profiles WHERE id=@Id", new { Id = id });
        }

        public IEnumerable<Profile> GetAll()
        {
            using var db = Database.GetConnection();
            return db.Query<Profile>("SELECT * FROM profiles");
        }

        public int Count()
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>("SELECT COUNT(*) FROM profiles");
        }

        public Profile? GetDefaultProfile()
        {
            using var db = Database.GetConnection();
            return db.QueryFirstOrDefault<Profile>("SELECT * FROM profiles ORDER BY id LIMIT 1");
        }

        public int Insert(Profile profile)
        {
            using var db = Database.GetConnection();
            return db.ExecuteScalar<int>(@"
                INSERT INTO profiles (profileName)
                VALUES (@ProfileName);
                SELECT last_insert_rowid();
            ", profile);
        }

        public void Update(Profile profile)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                UPDATE profiles SET
                    profileName=@ProfileName,
                    updated_at=CURRENT_TIMESTAMP
                WHERE id=@Id
            ", profile);
        }

        public void Delete(int id)
        {
            using var db = Database.GetConnection();
            db.Execute("DELETE FROM profiles WHERE id=@Id", new { Id = id });
        }
    }
}
