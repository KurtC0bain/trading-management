using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TM.Application.Common.Models.Roles;

namespace TM.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController(UserManager<IdentityUser> userManager) : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssingUserToRoleRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok("Role assigned successfully");
            }

            return BadRequest(result.Errors);
        }
    }
}
