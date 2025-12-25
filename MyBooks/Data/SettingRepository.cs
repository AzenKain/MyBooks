using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyBooks.Models;

namespace MyBooks.Data
{
    public class SettingRepository
    {
        public Setting GetCurrentSetting()
        {
            using var db = Database.GetConnection();
            var result =  db.QueryFirstOrDefault<Setting>("SELECT * FROM settings LIMIT 1");
            if (result == null)
            {
                throw new InvalidOperationException("No settings found in the database.");
            }
            return result;
        }
        public void Update(Setting setting)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                UPDATE settings SET
                    currentProfile=@CurrentProfile,
                    updatedAt=CURRENT_TIMESTAMP
                WHERE id=@Id
            ", setting);
        }

        public void Insert(Setting setting)
        {
            using var db = Database.GetConnection();
            db.Execute(@"
                INSERT INTO settings (currentProfile)
                VALUES (@CurrentProfile);
            ", setting);
        }
    }
}
