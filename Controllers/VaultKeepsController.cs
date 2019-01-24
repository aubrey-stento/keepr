using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepRepository _vaultKeepRepo;
        public VaultKeepsController(VaultKeepRepository vaultKeepRepo)
        {
            _vaultKeepRepo = vaultKeepRepo;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<string> Post([FromBody] VaultKeep vk)
        {
            var id = HttpContext.User.Identity.Name;
            vk.UserId = id;
            VaultKeep result = _vaultKeepRepo.AddVaultKeep(vk);
            return Created("api/vaultkeep/" + result.Id, result);

        }

        // GET KEEPS BY VAULTID
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Keep>> Get(int id)
        {
            var userId = HttpContext.User.Identity.Name;
            IEnumerable<Keep> result = _vaultKeepRepo.GetKeepsByVaultId(id, userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        // GET VALTKEEPS BY VAULTID

        // [Authorize]
        // [HttpGet("{vaultId}")]

        // public ActionResult<IEnumerable<VaultKeep>> GetVaultKeepsByVaultId(int vaultId)
        // {
        //     var id = HttpContext.User.Identity.Name;
        //     IEnumerable<VaultKeep> result = _vaultKeepRepo.GetVaultKeepsByVaultId(vaultId);
        //     if (result != null)
        //     {
        //         return Ok(result);
        //     }
        //     return BadRequest();
        // }

        [Authorize]
        [HttpDelete("{vaultkeepId}")]

        // pass the vaultid and keepid instead

        public ActionResult<string> Delete(int vaultkeepId)
        {
            var id = HttpContext.User.Identity.Name;
            if (_vaultKeepRepo.DeleteVaultKeep(vaultkeepId, id))
            {
                return Ok("Successfully Deleted");
            }
            return BadRequest("Unable to Delete!");
        }
    }
}