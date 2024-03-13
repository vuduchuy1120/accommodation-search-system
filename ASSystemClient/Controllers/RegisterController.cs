using ASSystem.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace ASSystemClient.Controllers
{
    public class RegisterController : Controller
    {
        private readonly string _baseUrl = "https://localhost:7280/api/User";
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SignUp(string email, string password, string re_password, string roleId)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(re_password))
            {
                return RedirectToAction("Index", new { Message = "Please input both email and password!" });
            }
            if(password != re_password)
            {
                return RedirectToAction("Index", new { Message = "Password and re-password are not the same!" });
            }
            int roleIdValue;
            // Chuyển đổi roleId từ chuỗi sang số nguyên
            if (!int.TryParse(roleId, out roleIdValue))
            {
                // Xử lý trường hợp không thể chuyển đổi thành công

                return RedirectToAction("Index", new { Message = "Invalid roleId!" + roleId + "alo" });
            }
            var user = new UserRegisterDto
            {
                Email = email,
                Password = password,
                RoleId = roleIdValue // roleId đã được chuyển đổi sang kiểu int
            };

            using (var client = new HttpClient())
            {

                try
                {
                    using (var response = await client.PostAsJsonAsync(_baseUrl + "/Register", user))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            return RedirectToAction("Index", new { Message = "Register failed!" });
                        }
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", new { Message = "Register failed!" });
                }
            }
        }
    }
}
