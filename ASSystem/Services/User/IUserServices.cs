using ASSystem.Dtos;
using ASSystem.Dtos.User;

namespace ASSystem.Services.User
{
    public interface IUserServices
    {
        Task<ApiResponse> Register(UserRegisterDto user);
        Task<ApiResponse> GetUserByID(int id);
        Task<ApiResponse> UpdateUserByID(int id, UserUpdateDto user);
        Task<ApiResponse> GetUserByUsername(string username);
        Task<ApiResponse> GetUserByEmail(string email);

        Task<ApiResponse> ChangePassword(string email, UserChangePasswordDto user);

        //Task<ApiResponse> Search(int page, int pageSize);
    }
}
