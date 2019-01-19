using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }

        // add vaultkeep
        public VaultKeep AddVaultKeep(VaultKeep vk)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO VaultKeeps(vaultId, keepId, userId)
            VALUES(@VaultId, @KeepId, @userId);
            SELECT LAST_INSERT_ID();
            ", vk);
            vk.Id = id;
            return vk;
        }
    }
}