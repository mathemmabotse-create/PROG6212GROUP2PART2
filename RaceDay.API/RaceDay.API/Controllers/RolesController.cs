using Microsoft.AspNetCore.Mvc;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // GET: api/Roles
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = new[]
            {
                new { RoleID = 1, RoleName = "Admin" },
                new { RoleID = 2, RoleName = "Organiser" },
                new { RoleID = 3, RoleName = "Participant" }
            };

            return Ok(roles);
        }
    }
}
