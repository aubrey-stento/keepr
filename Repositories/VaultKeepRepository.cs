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

        // get keeps by vaultId

        public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _db.Query<Keep>($@"
            SELECT * FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId
            WHERE (vaultId = @vaultId AND vk.userId=@userId);
            ", new { vaultId, userId });
        }

        // // get vaultkeeps by vaultid

        // public IEnumerable<VaultKeep> GetVaultKeepsByVaultId(int vaultId)
        // {
        //     return _db.Query<VaultKeep>($@"
        //     SELECT * FROM vaultkeeps vk
        //     INNER JOIN keeps k ON k.id = vk.keepId
        //     WHERE (vaultId = @vaultId);
        //     ", new { vaultId });
        // }

        // DELETE VAULTKEEPS

        public bool DeleteVaultKeep(int vaultId, int keepId, string userId)
        {
            int success = _db.Execute($@"DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId", new { vaultId, userId, keepId });
            return success != 0;

        }
    }
}