//using DemoJWT.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace DemoJWT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly AccommodationSearchSystemContext _context;
//        private readonly AppSettings _appSettings;
//        public UserController(AccommodationSearchSystemContext context, IOptionsMonitor<AppSettings> optionsMonitor) {
//            _context = context;
//            _appSettings = optionsMonitor.CurrentValue;
//        }

//        [HttpPost("Login")]
//        public IActionResult Validate(Login model)
//        {
//            var user = _context.Accounts.SingleOrDefault(p => p.Username == model.username && model.password == model.password);
//            if(user == null)
//            {
//                return Ok(new ApiResponse
//                {
//                    Success = false,
//                    Message = "Invalid Username/Password"
//                });
//            }

//            // cấp token


//            return Ok(new ApiResponse
//            {
//                Success = true,
//                Message = "Authenticate success!",
//                Data = GenerateToken(user)
//            });  
//        }

//        private string GenerateToken(Account account)
//        {
//            var jwtTokenHandler = new JwtSecurityTokenHandler();
//            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
//            var tokenDecription = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim(ClaimTypes.Name, account.Email)

//                }),
//                Expires = DateTime.UtcNow.AddMinutes(1),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256)
//            };
//            var token = jwtTokenHandler.CreateToken(tokenDecription);
//            return jwtTokenHandler.WriteToken(token);

//        }



//    }
//}
