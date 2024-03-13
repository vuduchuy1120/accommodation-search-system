using ASSystem.Dtos;
using ASSystem.Dtos.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASSystemClient.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly string _apiUrl = "https://localhost:7280/api/Admin";
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ManagementUser()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_apiUrl + "/GetAllUser"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motels = await response.Content.ReadFromJsonAsync<ApiResponse<List<UserProfileDto>>>();

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

        //Search
        public async Task<IActionResult> Search(string search)
        {
            if(search == null)
            {
                return RedirectToAction("ManagementUser");
            }
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_apiUrl + "/GetUserByEmail?email=" + search))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motels = await response.Content.ReadFromJsonAsync<ApiResponse<List<UserProfileDto>>>();

                            if (motels.Success)
                            {
                                return View("ManagementUser", motels.Data);
                            }
                            else
                            {
                                return View("ManagementUser");
                            }
                        }
                        else
                        {
                            return View("ManagementUser");
                        }
                    }
                }
                catch (Exception e)
                {
                    return View("ManagementUser");
                }
            }
        }

        //MotelManagement
        public async Task<IActionResult> MotelManagement()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_apiUrl + "/GetAllMotel"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motels = await response.Content.ReadFromJsonAsync<ApiResponse<List<MotelwithImagesDto>>>();

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
