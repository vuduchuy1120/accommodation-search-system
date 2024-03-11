using ASSystem.Dtos;
using ASSystem.Dtos.User;

namespace ASSystem.Services.User
{
    public interface IUserServices
    {
        Task<ApiResponse<UserRegisterDto>> Register(UserRegisterDto user);
        Task<ApiResponse<UserDto>> GetUserByID(int id);
        Task<ApiResponse<UserUpdateDto>> UpdateUserByID(int id, UserUpdateDto user);
        Task<ApiResponse<UserDto>> GetUserByUsername(string username);
        Task<ApiResponse<UserDto>> GetUserByEmail(string email);

        Task<ApiResponse<UserChangePasswordDto>> ChangePassword(string email, UserChangePasswordDto user);

        //Task<ApiResponse> Search(int page, int pageSize);
    }
}
