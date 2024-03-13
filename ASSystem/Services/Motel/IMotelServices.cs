using ASSystem.Dtos;

namespace ASSystem.Services.Motel
{
    public interface IMotelServices
    {
        public Task<ApiResponse<List<MotelwithImagesDto>>> GetAllMotel();
        public Task<ApiResponse<MotelwithImagesDto>> GetMotelById(int id);
        public Task<ApiResponse<MotelDto>> CreateMotel(MotelDto motel);
        public Task<ApiResponse<MotelDto>> UpdateMotel(int id, MotelUpdateDto motel);
        public Task<ApiResponse<MotelwithImagesDto>> DeleteMotel(int id);
        public Task<ApiResponse<List<MotelwithImagesDto>>> GetMotelByAccountId(int accountId);
        // upload IformFile
        public Task<ApiResponse<MotelwithImagesDto>> UploadImage(int id, IFormFile[] images);

        // search motel by province or district or ward or price or area or tittle or all of them
        public Task<ApiResponse<List<MotelwithImagesDto>>> SearchMotel(string? province, string? district, string? ward, Decimal? price, double? area, string? title);

    }
}
