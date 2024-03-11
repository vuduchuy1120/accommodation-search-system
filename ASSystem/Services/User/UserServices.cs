using ASSystem.Dtos;
using ASSystem.Dtos.User;
using ASSystem.Exceptions;
using ASSystem.Models;
using ASSystem.Repository.User;
using AutoMapper;
using System.Net;

namespace ASSystem.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        public UserServices(IMapper mapper, UserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<UserChangePasswordDto>> ChangePassword(string email, UserChangePasswordDto userChangePasswordDto)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, $"User has email {email} not found.");
            }
            user.Password = userChangePasswordDto.Password;
            var result = await _userRepository.Update(user);
            if (!result)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Change password failed.");
            }
            return new ApiResponse<UserChangePasswordDto> { Success = true, Message = "Change password successfully.", Data = _mapper.Map<UserChangePasswordDto>(user) };

        }

        public async Task<ApiResponse<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, $"User has email {email} not found.");
            }
            return new ApiResponse<UserDto> { Success = true, Message = "Get user by email successfully.", Data = _mapper.Map<UserDto>(user) };
        }

        public async Task<ApiResponse<UserDto>> GetUserByID(int id)
        {
            var user = await _userRepository.GetUserByID(id);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, $"User has id {id} not found.");
            }
            return new ApiResponse<UserDto> { Success = true, Message = "Get user by id successfully.", Data = _mapper.Map<UserDto>(user) };
        }

        public async Task<ApiResponse<UserDto>> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, $"User has username {username} not found.");
            }
            return new ApiResponse<UserDto> { Success = true, Message = "Get user by username successfully.", Data = _mapper.Map<UserDto>(user) };

        }

        public async Task<ApiResponse<UserRegisterDto>> Register(UserRegisterDto userRegisterDto)
        {
            var isEmailExist = await _userRepository.IsEmailExist(userRegisterDto.Email);
            if (isEmailExist)
            {
                throw new MyException((int)HttpStatusCode.OK, $"User has email {userRegisterDto.Email} already exist.");
            }
            
            var user = _mapper.Map<Account>(userRegisterDto);
            var result = await _userRepository.Add(user);
            if (!result)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Add user account failed.");
            }
            return new ApiResponse<UserRegisterDto> { Success = true, Message = "User registered successfully.", Data = _mapper.Map<UserRegisterDto>(user) };
        }

        public async Task<ApiResponse<UserUpdateDto>> UpdateUserByID(int id, UserUpdateDto user)
        {
            var userUpdate = await _userRepository.GetUserByID(id);
            if (userUpdate == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, $"User has id {id} not found.");
            }
            var isPhoneExist = await _userRepository.IsPhoneExist(user.Phone);
            if (isPhoneExist)
            {
                throw new MyException((int)HttpStatusCode.OK, $"User has phone {user.Phone} already exist.");
            }
            userUpdate.FirstName = user.FirstName;
            userUpdate.LastName = user.LastName;
            userUpdate.Phone = user.Phone;
            userUpdate.Gender = user.Gender;

            var result = await _userRepository.Update(userUpdate);
            if (!result)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Update user account failed.");
            }
            return new ApiResponse<UserUpdateDto> { Success = true, Message = "Update user account successfully.", Data = _mapper.Map<UserUpdateDto>(userUpdate) };
        }
    }
}
