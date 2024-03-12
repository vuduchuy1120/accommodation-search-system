using ASSystem.Dtos.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ASSystem.Dtos.User;
using ASSystem.Dtos;
using System.Text.Json;
using Newtonsoft.Json;
using ASSystem.Dtos.Admin;
using ASSystemClient.Models;

namespace ASSystemClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly string _urlAuth = "https://localhost:7280/api/Auth/login";

        // signIn
        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", new { Message = "Please input both email and password!" });
            }
            var authRequest = new LoginRequest
            {
                Email = email,
                Password = password
            };

            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.PostAsJsonAsync(_urlAuth, authRequest))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseJson = await response.Content.ReadAsStringAsync();
                            var successResponse = JsonConvert.DeserializeObject<ApiResponse<UserProfileDto>>(responseJson);
                            var user = successResponse.Data;

                            var claims = new List<Claim>
                                    {
                                        new Claim("AccountId", user.AccountId.ToString()),
                                        new Claim(ClaimTypes.NameIdentifier, user.Email),
                                        new Claim("Role", user.RoleId.ToString())
                                    };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var authProperties = new AuthenticationProperties
                            {
                                AllowRefresh = true,
                                IsPersistent = true
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties
                            );

                            return RedirectToAction("Index", "Home");
                        }

                        var errorResponseJson = await response.Content.ReadAsStringAsync();
                        var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorResponseJson);
                        return RedirectToAction("Index", new { Message = errorResponse.Message });
                    }

                }
                catch (HttpRequestException)
                {
                    return RedirectToAction("Index", new { Message = "Error connecting to service." });
                }
                catch (System.Text.Json.JsonException)
                {
                    return RedirectToAction("Index", new { Message = "Error parsing the service response." });
                }

            }
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
