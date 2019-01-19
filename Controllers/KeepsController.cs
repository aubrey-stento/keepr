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
    }
}