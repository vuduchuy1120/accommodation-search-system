using ASSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ASSystemClient.Controllers
{
    public class MotelController : Controller
    {
        private readonly string _baseUrl = "https://localhost:7280/api/Motel";

        public async Task<IActionResult> IndexAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_baseUrl))
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

        //create
        public IActionResult Create()
        {
            return View();
        }
        // Form
        public IActionResult Form()
        {
            return View();
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_baseUrl + $"/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motel = await response.Content.ReadFromJsonAsync<ApiResponse<MotelwithImagesDto>>();

                            if (motel.Success)
                            {
                                return View(motel.Data);
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
