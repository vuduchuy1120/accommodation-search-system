using ASSystem.Services.Motel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImageController : ControllerBase
    {
        private readonly IRoomImagesServices _roomImagesServices;

        public RoomImageController(IRoomImagesServices roomImagesServices)
        {
            _roomImagesServices = roomImagesServices;
        }

        [HttpDelete("{motelId}/{id}")]
        public async Task<IActionResult> DeleteRoomImage(int motelId, int id)
        {
            var result = await _roomImagesServices.DeleteRoomImage(motelId, id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
