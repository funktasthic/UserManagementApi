using UserManagementApi.DTOs.User;
using UserManagementApi.Exceptions;
using UserManagementApi.Models.Common;
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

    public Task<bool> DeleteUser(string id)
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

    public async Task<BaseResponse<UserDto>> GetUserById(string id)
    {
        var user = await _repository.GetById(id);
        if (user == null)
        {
            throw new EntityNotFoundException("User not found");
        }

        if (!user.IsActive)
        {
            throw new DisabledUserException($"User is disabled");
        }

        return new BaseResponse<UserDto>("User found successfully", new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email
        });
    }
}
