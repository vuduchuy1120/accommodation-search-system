using ASSystem.Dtos;

namespace ASSystem.Services.Admin
{
    public interface IAdminServices
    {
        public Task<ApiResponse> GetAllUser();
    }
}
