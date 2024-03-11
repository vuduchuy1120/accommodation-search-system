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
        public async Task<ApiResponse<List<UserProfileDto>>> GetAllUser()
        {
            var result = await _adminRepository.GetAllUser();
            return new ApiResponse<List<UserProfileDto>> { Success = true, Message = "Get all user successfully.", Data = _mapper.Map<List<UserProfileDto>>(result) };
        }

        public async Task<ApiResponse<List<RoleDto>>> getUserRole()
        {
            var result = await _adminRepository.getUserRole();
            return new ApiResponse<List<RoleDto>> { Success = true, Message = "Get user role successfully.", Data = _mapper.Map<List<RoleDto>>(result) };
        }
    }
}
