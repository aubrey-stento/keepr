using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultsController : ControllerBase
    {
        private readonly VaultRepository _repo;
        public VaultsController(VaultRepository repo)
        {
            _repo = repo;
        }
        [Authorize]
        [HttpPost]
        public ActionResult<Vault> AddVault([FromBody]Vault vault)
        {
            var id = HttpContext.User.Identity.Name;
            vault.UserId = id;
            return Ok(_repo.AddVault(vault));
        }

        [Authorize]
        [HttpDelete("{vaultid}")]
        public ActionResult<string> Delete(int vaultid)
        {
            var id = HttpContext.User.Identity.Name;
            if (_repo.DeleteVault(vaultid, id))
            {
                return Ok("Successfully Deleted!");
            }
            return BadRequest("Unable to delete!");
        }

        [Authorize]
        [HttpGet]
        // GET VAULTS BY USERID
        public ActionResult<IEnumerable<Vault>> GetVaults()
        {
            var id = HttpContext.User.Identity.Name;
            IEnumerable<Vault> result = _repo.GetVaults(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // Get VAULT BY VAULTID

        [Authorize]
        [HttpGet("{vaultId}")]
        public ActionResult<IEnumerable<Vault>> GetVault(int vaultId)
        {
            var id = HttpContext.User.Identity.Name;
            IEnumerable<Vault> result = _repo.GetVault(vaultId, id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



    }
}



