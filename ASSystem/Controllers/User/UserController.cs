using ASSystem.Dtos.User;
using ASSystem.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ASSystem.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            var result = await _userServices.Register(user);
            return Ok(result);
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            var result = await _userServices.GetUserByID(id);
            return Ok(result);
        }

        [HttpPut("UpdateUserByID")]
        public async Task<IActionResult> UpdateUserByID(int id, UserUpdateDto user)
        {
            var result = await _userServices.UpdateUserByID(id, user);
            return Ok(result);
        }

        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var result = await _userServices.GetUserByUsername(username);
            return Ok(result);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userServices.GetUserByEmail(email);
            return Ok(result);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(int id, UserChangePasswordDto user)
        {
            var result = await _userServices.ChangePassword(id, user);
            return Ok(result);
        }


    }
}
