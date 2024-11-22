
using UserManagementApi.DTOs.User;
using UserManagementApi.Services.Interfaces;

namespace UserManagementApi.Services;

public class UserService : IUserService
{
    public Task<List<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByUUID(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Create(UserCreateRequestDto userCreateRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> EditUser(UserUpdateRequestDto userUpdateRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(string uuid)
    {
        throw new NotImplementedException();
    }
}