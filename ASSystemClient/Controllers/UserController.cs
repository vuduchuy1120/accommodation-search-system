using ASSystem.Dtos;
using ASSystem.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASSystemClient.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly string _baseUrl = "https://localhost:7280/api/User";

        public async Task<IActionResult> Index()
        {

            var accountId = User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value;

            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_baseUrl + "/GetUserByID?id=" + accountId))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motels = await response.Content.ReadFromJsonAsync<ApiResponse<UserDto>>();

                            if (motels.Success)
                            {
                                return View(motels.Data);
                            }
                            else
                            {
                                return View();
                            }
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
                catch (Exception e)
                {
                    return View();
                }
            }

  
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update(int? id)
        {

            var accountId = -1;
            if(id != null)
            {
                accountId = id.Value;
            }
            else
            {
                accountId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value);
            }

            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_baseUrl + "/GetUserByID?id=" + accountId))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motels = await response.Content.ReadFromJsonAsync<ApiResponse<UserDto>>();

                            if (motels.Success)
                            {
                                return View(motels.Data);
                            }
                            else
                            {
                                return View();
                            }
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
                catch (Exception e)
                {
                    return View();
                }
            }


        }
    }
}
