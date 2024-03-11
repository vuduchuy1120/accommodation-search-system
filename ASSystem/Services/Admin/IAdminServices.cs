using ASSystem.Dtos;
using ASSystem.Dtos.Admin;

namespace ASSystem.Services.Admin
{
    public interface IAdminServices
    {
        public Task<ApiResponse<List<UserProfileDto>>> GetAllUser();

        public Task<ApiResponse<List<RoleDto>>> getUserRole();
    }
}
