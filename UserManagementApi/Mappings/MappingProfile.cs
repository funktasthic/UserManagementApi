
using AutoMapper;
using UserManagementApi.DTOs.Auth;
using UserManagementApi.DTOs.User;
using UserManagementApi.Models;

namespace UserManagementApi.Extensions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginResponseDto>();
        CreateMap<UserCreateRequestDto, User>();
        CreateMap<UserUpdateRequestDto, User>();
        CreateMap<User, UserDto>();
    }
}