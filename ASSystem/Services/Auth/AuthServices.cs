using ASSystem.Dtos;
using ASSystem.Dtos.Admin;
using ASSystem.Dtos.User;
using ASSystem.Exceptions;
using ASSystem.Repository.Auth;
using AutoMapper;
using System.Net;

namespace ASSystem.Services.Auth
{
    public class AuthServices : IAuthServies
    {
        private readonly AuthRepository _authRepository;
        private readonly IMapper _mapper;
        public AuthServices(AuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public string GenerateAccessToken()
        {
            throw new NotImplementedException();
        }

        public string GenerateJSONWebToken()
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<UserProfileDto>> Login(string username, string password)
        {
            var user = await _authRepository.Login(username, password);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, $"Username or password is incorrect");
            }
            Console.WriteLine("Login successful");
            return new ApiResponse<UserProfileDto>
            {
                Success = true,
                Message = "Login successful",
                Data = _mapper.Map<UserProfileDto>(user)
            };
        }

        public Task<ApiResponse<UserProfileDto>> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
