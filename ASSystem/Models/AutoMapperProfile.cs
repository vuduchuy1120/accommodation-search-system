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

            CreateMap<Role,RoleDto>();
            CreateMap<RoleDto,Role>();

            CreateMap<RoomImage, RoomImageDto>();   
            CreateMap<RoomImageDto, RoomImage>();

            CreateMap<Motel, MotelDto>();
            CreateMap<MotelDto, Motel>();

            CreateMap<MotelwithImagesDto, Motel>();
            CreateMap<Motel, MotelwithImagesDto>();

            CreateMap<Motel, MotelUpdateDto>();
            CreateMap<MotelUpdateDto, Motel>();

        }
    }
}
