using UserManagementApi.DTOs.User;
using UserManagementApi.Models;
using UserManagementApi.Repositories.Interfaces;
using UserManagementApi.Services.Interfaces;

namespace UserManagementApi.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _repository;

    public UserService(IUsersRepository repository)
    {
        _repository = repository;
    }

    public Task<UserDto> Create(UserCreateRequestDto userCreateRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(Guid uuid)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> EditUser(UserUpdateRequestDto userUpdateRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetById(Guid uuid)
    {
        throw new NotImplementedException();
    }
}
