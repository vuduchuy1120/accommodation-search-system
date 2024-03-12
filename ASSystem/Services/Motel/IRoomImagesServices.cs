using ASSystem.Dtos;

namespace ASSystem.Services.Motel
{
    public interface IRoomImagesServices
    {
        public Task<ApiResponse<RoomImageDto>> DeleteRoomImage(int id);
    }
}
