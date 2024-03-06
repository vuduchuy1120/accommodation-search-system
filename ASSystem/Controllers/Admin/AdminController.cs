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
    }
}
