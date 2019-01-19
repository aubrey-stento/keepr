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
    }
}








// // GetKeepsByUserId
//             public IEnumerable<Vault> GetVaultsByUserId(int id)
//             {
//                 return _db.Query<Vault>($@"
//             SELECT * FROM vaultkeeps vk
//             INNER JOIN keeps k ON k.id = vk.keepId
//             WHERE (userId = @id);
//           ", new { id });
//             }