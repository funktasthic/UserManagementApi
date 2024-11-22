
using AutoMapper;
using UserManagementApi.DTOs.Auth;
using UserManagementApi.Models;

namespace UserManagementApi.Extensions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginResponseDto>();
    }
    
}