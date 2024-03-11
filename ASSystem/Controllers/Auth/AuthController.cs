using ASSystem.Dtos.Auth;
using ASSystem.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSystem.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServies _authService;

        public AuthController(IAuthServies authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }       
    }
}
