using ASSystem.Dtos;

namespace ASSystem.Services.Motel
{
    public interface IMotelServices
    {
        public Task<ApiResponse<List<MotelwithImagesDto>>> GetAllMotel();
        public Task<ApiResponse<MotelwithImagesDto>> GetMotelById(int id);
        public Task<ApiResponse<MotelDto>> CreateMotel(MotelDto motel);
        public Task<ApiResponse<MotelDto>> UpdateMotel(int id, MotelUpdateDto motel);
        public Task<ApiResponse<MotelDto>> DeleteMotel(int id);
        public Task<ApiResponse<List<MotelDto>>> GetMotelByAccountId(int accountId);
        // upload IformFile
        public Task<ApiResponse<MotelwithImagesDto>> UploadImage(int id, IFormFile[] images);
    }
}
