using ASSystem.Dtos;
using ASSystem.Dtos.Admin;
using ASSystem.Dtos.User;
using AutoMapper;

namespace ASSystem.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Room, RoomResponseTest>();
            CreateMap<Account, UserRegisterDto>();
            CreateMap<UserRegisterDto, Account>();
            CreateMap<UserUpdateDto, Account>();
            CreateMap<Account, UserUpdateDto>();
            CreateMap<UserChangePasswordDto, Account>();
            CreateMap<Account, UserChangePasswordDto>();
            CreateMap<Account, UserProfileDto>();
            CreateMap<UserProfileDto, Account>();
            CreateMap<Account, UserDto>();
            CreateMap<UserDto, Account>();
        }
    }
}
