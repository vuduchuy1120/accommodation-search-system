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
        public async Task<ApiResponse> GetAllUser()
        {
            var result = await _adminRepository.GetAllUser();
            return new ApiResponse { Success = true, Message = "Get all user successfully.", Data = _mapper.Map<List<UserProfileDto>>(result) };
        }
    }
}
