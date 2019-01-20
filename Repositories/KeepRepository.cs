using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;
        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }
        public Keep AddKeep(Keep newkeep)
        {
            int id = _db.ExecuteScalar<int>(@"INSERT INTO Keeps (Name, Description, img, views, shares, userId, IsPrivate)
                        VALUES(@Name, @Description, @image, @views, @shares, @userId, @IsPrivate); 
                        SELECT LAST_INSERT_ID();", newkeep);
            newkeep.Id = id;
            return newkeep;
        }

        public bool DeleteKeep(int vId, string userId)
        {
            int success = _db.Execute(@"DELETE FROM Keeps WHERE id = @vId AND userId = @userId", new { vId, userId });
            return success != 0;
        }

        // GET KEEPS BY USERID

        public IEnumerable<Keep> GetKeepsByUserId(string userId)
        {
            return _db.Query<Keep>($"SELECT * FROM Keeps WHERE userId = @userId", new { userId });
        }

        // GET ALL KEEPS

        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM Keeps");
        }

    }
}



