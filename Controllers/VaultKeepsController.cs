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


        [HttpPost]
        public ActionResult<string> Post([FromBody] VaultKeep vk)
        {
            VaultKeep result = _vaultKeepRepo.AddVaultKeep(vk);
            return Created("api/vaultkeep/" + result.Id, result);

        }

        // GET VAULTKEEPS BY VAULTID

        [Authorize]
        [HttpGet("{vaultId}")]

        public ActionResult<IEnumerable<VaultKeep>> GetVaultKeepsByVaultId(int vaultId)
        {
            IEnumerable<VaultKeep> result = _vaultKeepRepo.GetVaultKeepsByVaultId(vaultId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}