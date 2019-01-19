using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
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
    }
}