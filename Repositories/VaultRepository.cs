using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
    public class VaultRepository
    {
        private readonly IDbConnection _db;
        public VaultRepository(IDbConnection db)
        {
            _db = db;
        }

        // AddVaults
        public Vault AddVault(Vault newvault)
        {
            int id = _db.ExecuteScalar<int>(@"INSERT INTO Vaults (Name, Description, userId)
                        VALUES(@Name, @Description, @userId); 
                        SELECT LAST_INSERT_ID();", newvault);
            newvault.Id = id;
            return newvault;


        }
        // DELETE VAULTS CREATED BY USER
        public bool DeleteVault(int vId, string userId)
        {
            int success = _db.Execute(@"DELETE FROM Vaults WHERE id = @vId AND userId = @userId", new { vId, userId });
            return success != 0;

        }

        // GET VAULTS BY USERID

        public IEnumerable<Vault> GetVaultsByUserId(string userId)
        {
            return _db.Query<Vault>($"SELECT * FROM Vaults WHERE userId = @userId", new { userId });
        }



    }
}