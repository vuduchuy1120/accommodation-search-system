using ASSystem.Dtos;
using ASSystem.Dtos.Admin;

namespace ASSystem.Services.Admin
{
    public interface IAdminServices
    {
        public Task<ApiResponse<List<UserProfileDto>>> GetAllUser();
        public Task<ApiResponse<List<RoleDto>>> getUserRole();
        public Task<ApiResponse<List<MotelwithImagesDto>>> getMotelByUser(int id);
        public Task<ApiResponse<List<MotelwithImagesDto>>> getAllMotel();
        public Task<ApiResponse<UserProfileDto>> GetUserById(int id);
        public Task<ApiResponse<UserProfileDto>> DeleteUser(int id);
        public Task<ApiResponse<UserProfileDto>> CreateUser(UserProfileDto user);
        public Task<ApiResponse<UserProfileDto>> UpdateUserRole(int id, RoleDto role);
        public Task<ApiResponse<UserProfileDto>> UpdateUserStatus(int id, bool status);
        public Task<ApiResponse<List<RoleDto>>> getAllRole(); 

        //search user by email
        public Task<ApiResponse<List<UserProfileDto>>> GetUserByEmail(string email);

        //change status motel
        public Task<ApiResponse<MotelwithImagesDto>> ChangeStatusMotel(int id, string status);

        // delete motel
        public Task<ApiResponse<MotelwithImagesDto>> DeleteMotel(int id);
    }
}
