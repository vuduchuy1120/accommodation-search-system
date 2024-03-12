
using ASSystem.Dtos;
using ASSystem.Repository.Motel;

namespace ASSystem.Services.Motel
{
    public class RoomImagesServices : IRoomImagesServices
    {
        private readonly RoomImagesRepository _roomImagesRepository;
        public RoomImagesServices(RoomImagesRepository roomImagesRepository)
        {
            _roomImagesRepository = roomImagesRepository;
        }
        public async Task<ApiResponse<RoomImageDto>> DeleteRoomImage(int id)
        {
            var result = await _roomImagesRepository.DeleteImages(id);
            if (!result)
            {
                throw new Exception("Delete failed");
            }
            return new ApiResponse<RoomImageDto>
            {
                Success = true,
                Message = "Delete successfully.",
                Data = null
            };
        }
    }
}
