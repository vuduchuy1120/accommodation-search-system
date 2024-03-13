using ASSystem.Dtos.Admin;
using ASSystem.Services.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ASSystem.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _adminServices.GetAllUser();
            return Ok(result);
        }
        [HttpGet("GetUserRole")]
        public async Task<IActionResult> GetUserRole()
        {
            var result = await _adminServices.getUserRole();
            return Ok(result);
        }
        [HttpGet("GetMotelByUser")]
        public async Task<IActionResult> GetMotelByUser(int id)
        {
            var result = await _adminServices.getMotelByUser(id);
            return Ok(result);
        }
        [HttpGet("GetAllMotel")]
        public async Task<IActionResult> GetAllMotel()
        {
            var result = await _adminServices.getAllMotel();
            return Ok(result);
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _adminServices.GetUserById(id);
            return Ok(result);
        }
        [HttpPut("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _adminServices.DeleteUser(id);
            return Ok(result);
        }
        
        [HttpPut("UpdateUserRole/{id}")]
        public async Task<IActionResult> UpdateUserRole(int id, RoleDto role)
        {
            var result = await _adminServices.UpdateUserRole(id, role);
            return Ok(result);
        }

        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var result = await _adminServices.getAllRole();
            return Ok(result);
        }

        //getuserbyemail
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _adminServices.GetUserByEmail(email);
            return Ok(result);
        }

        [HttpPut("UpdateMotelStatus/{id}")]
        public async Task<IActionResult> UpdateMotelStatus(int id, string status)
        {
            var result = await _adminServices.ChangeStatusMotel(id, status);
            return Ok(result);
        }

        [HttpPut("DeleteMotel/{id}")]
        public async Task<IActionResult> DeleteMotel(int id)
        {
            var result = await _adminServices.DeleteMotel(id);
            return Ok(result);
        }


    }
}
