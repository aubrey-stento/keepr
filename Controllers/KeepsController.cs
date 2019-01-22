using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepsController : ControllerBase
    {
        private readonly KeepRepository _repo;
        public KeepsController(KeepRepository repo)
        {
            _repo = repo;
        }
        [Authorize]
        [HttpPost]
        public ActionResult<Keep> AddKeep([FromBody]Keep keep)
        {
            var id = HttpContext.User.Identity.Name;
            keep.UserId = id;
            return Ok(_repo.AddKeep(keep));
        }
        [Authorize]
        [HttpDelete("{keepid}")]
        public ActionResult<string> Delete(int keepid)
        {
            var id = HttpContext.User.Identity.Name;
            if (_repo.DeleteKeep(keepid, id))
            {
                return Ok("Successfully Deleted");
            }
            return BadRequest("Unable to Delete!");
        }

        [Authorize]
        [HttpGet("user")]
        // GET KEEPS BY USERID
        public ActionResult<IEnumerable<Keep>> GetKeeps()
        {
            var id = HttpContext.User.Identity.Name;
            IEnumerable<Keep> result = _repo.GetKeepsByUserId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // GET ALL PUBLIC KEEPS
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> Get()
        {
            return Ok(_repo.GetAllPublicKeeps());
        }

        // GET KEEP BY KEEPID

        [HttpGet("{id}")]
        public ActionResult<Keep> GetKeep(int id)
        {
            Keep result = _repo.GetKeepById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // Edit keeps

        [HttpPut("{id}")]
        public ActionResult<Keep> Put(int id, [FromBody] Keep keep)
        {
            Keep result = _repo.GetOneByIdAndUpdate(id, keep);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }
    }
}