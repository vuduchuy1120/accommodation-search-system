using ASSystem.Dtos;
using ASSystem.Models;
using ASSystem.Services.Motel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System.Net.Http.Json;


namespace ASSystem.Controllers.Motel
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotelController : ControllerBase
    {
        private readonly IMotelServices _motelServices;
        private readonly IMapper _mapp;
        public MotelController(IMotelServices motelServices, IMapper mapper)
        {
            _motelServices = motelServices;
            _mapp = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMotel()
        {
            var result = await _motelServices.GetAllMotel();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CreateMotelNotImages")]
        public async Task<IActionResult> CreateMotelNotImages([FromBody] MotelDto motel)
        {
            var result = await _motelServices.CreateMotel(motel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            // Xác định loại MIME dựa trên phần mở rộng của tập tin
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            if (!contentTypeProvider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream"; // Loại MIME mặc định nếu không thể xác định
            }

            var imageFileStream = System.IO.File.OpenRead(imagePath);
            return File(imageFileStream, contentType);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMotel([FromForm] string motelJson, IFormFile[] images)
        {
            var motel = JsonConvert.DeserializeObject<ASSystem.Models.Motel>(motelJson);

            var result = await _motelServices.CreateMotel(_mapp.Map<MotelDto>(motel));
            if (result.Success)
            {
                int id = result.Data.MotelId;
                var uploadResult = await _motelServices.UploadImage(id, images);
                if (uploadResult.Success)
                {
                    return Ok(uploadResult);
                }
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotelById(int id)
        {
            var result = await _motelServices.GetMotelById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMotel(int id, [FromForm] string motelJson, IFormFile[] images)
        {
            var motel = JsonConvert.DeserializeObject<ASSystem.Models.Motel>(motelJson);

            var result = await _motelServices.UpdateMotel(id, _mapp.Map<MotelUpdateDto>(motel));

            if (result.Success)
            {
                int idMotel = result.Data.MotelId;
                var uploadResult = await _motelServices.UploadImage(idMotel, images);
                if (uploadResult.Success)
                {
                    return Ok(uploadResult);
                }
            }
            return BadRequest(result);
        }


        [HttpGet("GetMotelByAccountId/{accountId}")]
        public async Task<IActionResult> GetMotelByAccountId(int accountId)
        {
            var result = await _motelServices.GetMotelByAccountId(accountId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("SearchMotel")]
        public async Task<IActionResult> SearchMotel(
            [FromQuery(Name = "province")] string? province,
            [FromQuery(Name = "district")] string? district,
            [FromQuery(Name = "ward")] string? ward,
            [FromQuery(Name = "price")] Decimal? price,
            [FromQuery(Name = "area")] double? area,
            [FromQuery(Name = "title")] string? title)
         {
            var result = await _motelServices.SearchMotel(province, district, ward, price, area, title);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
