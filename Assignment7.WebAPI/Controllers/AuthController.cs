using Assignment7.Application.Dtos.Account;
using Assignment7.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment7.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        //[Authorize(Roles = "Librarian, Library Manager")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.SignUpAsync(model);

            if (result.Status == "Error")
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(model);
            if (result.Status == "Error")

                return BadRequest(result.Message);

            return Ok(result);
        }
        //[Authorize(Roles = "Library Manager")]
        [HttpPost("set-role")]
        public async Task<IActionResult> CreateRoleAsync(string rolename)
        {
            var result = await _authService.CreateRoleAsync(rolename);
            return Ok(result);
        }
       // [Authorize(Roles = "Library Manager")]
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignToRoleAsync(string userName, [FromBody] string rolename)
        {
            var result = await _authService.AssignToRoleAsync(userName, rolename);
            return Ok(result);
        }
        [Authorize(Roles = "Library Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoleAsync(string userName, [FromBody] string rolename)
        {
            var result = await _authService.UpdateToRoleAsync(userName, rolename);
            return Ok(result);
        }
        [Authorize(Roles = "Library Manager")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoleAsync(string userName, [FromBody] string rolename)
        {
            var result = await _authService.DeleteToRoleAsync(userName, rolename);
            return Ok(result);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync(string userName)
        {
            var result = await _authService.LogoutAsync(userName);
            return Ok(result);
        }
    }
}

