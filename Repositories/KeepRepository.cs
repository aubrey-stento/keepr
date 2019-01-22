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
                        VALUES(@Name, @Description, @img, @views, @shares, @userId, @IsPrivate); 
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

        // GET ALL PUBLIC KEEPS

        public IEnumerable<Keep> GetAllPublicKeeps()
        {
            return _db.Query<Keep>("SELECT * FROM Keeps WHERE IsPrivate = 0");
        }

        // GET KEEP BY KEEPID

        public Keep GetKeepById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>("SELECT * FROM Keeps WHERE id=@id", new { id });
        }

        // EDIT A KEEP

        public Keep GetOneByIdAndUpdate(int id, Keep newkeep)
        {
            {
                return _db.QueryFirstOrDefault<Keep>($@"
                UPDATE Keeps SET
                Views = @Views,
                Shares = @Shares,
                Keeps = @Keeps
                WHERE Id = {id};
                SELECT * FROM Keeps WHERE id = {id};", newkeep
                );
            }
        }

    }
}



