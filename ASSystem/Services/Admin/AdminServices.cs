using ASSystem.Dtos;
using ASSystem.Dtos.Admin;
using ASSystem.Repository.Admin;
using AutoMapper;

namespace ASSystem.Services.Admin
{
    public class AdminServices : IAdminServices
    {
        private readonly AdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AdminServices(AdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<MotelwithImagesDto>> ChangeStatusMotel(int id, string status)
        {
            var result = await _adminRepository.UpdateMotelStatus(id, status);
            if (!result)
            {
                return new ApiResponse<MotelwithImagesDto>
                {
                    Success = false,
                    Message = "Change status motel failed."
                };
            }
            return new ApiResponse<MotelwithImagesDto>
            {
                Success = true,
                Message = "Change status motel successfully."
            };
        }

        public Task<ApiResponse<UserProfileDto>> CreateUser(UserProfileDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<MotelwithImagesDto>> DeleteMotel(int id)
        {
            var result = await _adminRepository.DeleteMotel(id);
            if (!result)
            {
                return new ApiResponse<MotelwithImagesDto>
                {
                    Success = false,
                    Message = "Delete motel failed."
                };
            }
            return new ApiResponse<MotelwithImagesDto>
            {
                Success = true,
                Message = "Delete motel successfully."
            };

        }

        public async Task<ApiResponse<UserProfileDto>> DeleteUser(int id)
        {
            var result = await _adminRepository.DeleteUser(id);
            if (!result)
            {
                return new ApiResponse<UserProfileDto>
                {
                    Success = false,
                    Message = "Delete user failed."
                };
            }
            return new ApiResponse<UserProfileDto>
            {
                Success = true,
                Message = "Delete user successfully."
            };
        }

        public async Task<ApiResponse<List<MotelwithImagesDto>>> getAllMotel()
        {
            var result = await _adminRepository.getAllMotel();
            if (result == null)
            {
                return new ApiResponse<List<MotelwithImagesDto>>
                {
                    Success = false,
                    Message = "Get all motel failed."
                };
            }
            return new ApiResponse<List<MotelwithImagesDto>>
            {
                Success = true,
                Message = "Get all motel successfully.",
                Data = _mapper.Map<List<MotelwithImagesDto>>(result)
            };
        }

        public async Task<ApiResponse<List<RoleDto>>> getAllRole()
        {
            var result = await _adminRepository.getAllRole();
            return new ApiResponse<List<RoleDto>>
            {
                Success = true,
                Message = "Get all role successfully.",
                Data = _mapper.Map<List<RoleDto>>(result)
            };
        }

        public async Task<ApiResponse<List<UserProfileDto>>> GetAllUser()
        {
            var result = await _adminRepository.GetAllUser();
            if (result == null)
            {
                return new ApiResponse<List<UserProfileDto>>
                {
                    Success = false,
                    Message = "Get all user failed."
                };
            }
            return new ApiResponse<List<UserProfileDto>>
            {
                Success = true,
                Message = "Get all user successfully.",
                Data = _mapper.Map<List<UserProfileDto>>(result)
            };
        }

        public async Task<ApiResponse<List<MotelwithImagesDto>>> getMotelByUser(int id)
        {
            var result = await _adminRepository.getMotelByUser(id);
            if (result == null)
            {
                return new ApiResponse<List<MotelwithImagesDto>>
                {
                    Success = false,
                    Message = "Get motel by user failed."
                };
            }
            return new ApiResponse<List<MotelwithImagesDto>>
            {
                Success = true,
                Message = "Get motel by user successfully.",
                Data = _mapper.Map<List<MotelwithImagesDto>>(result)
            };

        }

        public async Task<ApiResponse<List<UserProfileDto>>> GetUserByEmail(string email)
        {
            var result = await _adminRepository.GetUserByEmail(email);
            if (result == null)
            {
                return new ApiResponse<List<UserProfileDto>>
                {
                    Success = false,
                    Message = "Get user by email failed."
                };
            }
            return new ApiResponse<List<UserProfileDto>>
            {
                Success = true,
                Message = "Get user by email successfully.",
                Data = _mapper.Map<List<UserProfileDto>>(result)
            };
        }

        public async Task<ApiResponse<UserProfileDto>> GetUserById(int id)
        {
            var result = await _adminRepository.GetUserById(id);
            if (result == null)
            {
                return new ApiResponse<UserProfileDto>
                {
                    Success = false,
                    Message = "Get user by id failed."
                };
            }
            return new ApiResponse<UserProfileDto>
            {
                Success = true,
                Message = "Get user by id successfully.",
                Data = _mapper.Map<UserProfileDto>(result)
            };
        }

        public Task<ApiResponse<MotelDto>> getUserMotel()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<RoleDto>>> getUserRole()
        {
            var result = await _adminRepository.getUserRole();
            return new ApiResponse<List<RoleDto>>
            {
                Success = true,
                Message = "Get user role successfully.",
                Data = _mapper.Map<List<RoleDto>>(result)
            };
        }

        public async Task<ApiResponse<UserProfileDto>> UpdateUserRole(int id, RoleDto role)
        {
            var result = await _adminRepository.UpdateUserRole(id, _mapper.Map<RoleDto>(role));
            if (!result)
            {
                return new ApiResponse<UserProfileDto>
                {
                    Success = false,
                    Message = "Update user role failed."
                };
            }
            return new ApiResponse<UserProfileDto>
            {
                Success = true,
                Message = "Update user role successfully."
            };
        }

        public async Task<ApiResponse<UserProfileDto>> UpdateUserStatus(int id, bool status)
        {
            var result = await _adminRepository.UpdateUserStatus(id, status);
            if (!result)
            {
                return new ApiResponse<UserProfileDto>
                {
                    Success = false,
                    Message = "Update user status failed."
                };
            }
            return new ApiResponse<UserProfileDto>
            {
                Success = true,
                Message = "Update user status successfully."
            };
        }

       
    }
}
