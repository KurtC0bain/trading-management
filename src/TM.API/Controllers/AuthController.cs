using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TM.API.Controllers
{
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase    
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logged out successfully" });
        }
    }
}
