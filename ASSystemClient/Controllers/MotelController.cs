using ASSystem.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ASSystemClient.Controllers
{

    [Authorize]
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
        public async Task<IActionResult> Form(int id)
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
        // getMotelByAccountId
        public async Task<IActionResult> ManageMotel()
        {
            var accountId = User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value;
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(_baseUrl + $"/GetMotelByAccountId/{accountId}"))
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

        [HttpGet]
        public async Task<IActionResult> SearchMotel(string province, string district, string ward, string price, string area, string title)
        {
            // if one of the parameters is null or empty then equal "" to it
            province = string.IsNullOrEmpty(province) ? "" : province;
            district = string.IsNullOrEmpty(district) ? "" : district;
            ward = string.IsNullOrEmpty(ward) ? "" : ward;
            price = string.IsNullOrEmpty(price) ? "" : price;
            area = string.IsNullOrEmpty(area) ? "" : area;
            title = string.IsNullOrEmpty(title) ? "" : title;

            try
            {
                using (var client = new HttpClient())
                {
                    var queryString = new StringBuilder();

                    // Append query parameters only if they are not null or empty
                    if (!string.IsNullOrEmpty(province))
                        queryString.Append($"province={Uri.EscapeDataString(province)}&");
                    if (!string.IsNullOrEmpty(district))
                        queryString.Append($"district={Uri.EscapeDataString(district)}&");
                    if (!string.IsNullOrEmpty(ward))
                        queryString.Append($"ward={Uri.EscapeDataString(ward)}&");
                    if (!string.IsNullOrEmpty(price))
                        queryString.Append($"price={Uri.EscapeDataString(price)}&");
                    if (!string.IsNullOrEmpty(area))
                        queryString.Append($"area={Uri.EscapeDataString(area)}&");
                    if (!string.IsNullOrEmpty(title))
                        queryString.Append($"title={Uri.EscapeDataString(title)}&");

                    var requestUrl = $"{_baseUrl}/SearchMotel?{queryString.ToString().TrimEnd('&')}";

                    using (var response = await client.GetAsync(requestUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var motels = await response.Content.ReadFromJsonAsync<ApiResponse<List<MotelwithImagesDto>>>();

                            if (motels != null && motels.Success)
                            {
                                return View("Index", motels.Data);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Log or handle the exception as needed
            }

            // Return a default view or redirect to another page if needed
            return View();
        }


    }
}
