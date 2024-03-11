using ASSystem.Dtos;
using ASSystem.Dtos.Admin;

namespace ASSystem.Services.Auth
{
    public interface IAuthServies
    {
        public Task<ApiResponse<UserProfileDto>> Login(string username, string password);
        public Task<ApiResponse<UserProfileDto>> Logout();


        // genarate token
        public string GenerateJSONWebToken();
        // genarate refresh token
        public string GenerateRefreshToken();
        public string GenerateAccessToken();

    }
}
