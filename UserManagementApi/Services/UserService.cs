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

    public async Task<bool> DeleteUser(string id)
    {
        var user = await _repository.GetById(id);

        if (user == null)
        {
            throw new NotFoundException($"User with ID '{id}' not found");
        }

        // TODO: Add exception
        if (!user.IsActive)
        {
            throw new DisabledUserException($"User with ID '{id}' is disabled");
        }

        await _repository.DeleteUser(id);
        return true;
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
            throw new NotFoundException($"User with ID '{id}'");
        }

        if (!user.IsActive)
        {
            throw new DisabledUserException($"User with ID '{id}' is disabled");
        }

        return new BaseResponse<UserDto>("User found successfully", new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            IsActive = user.IsActive
        });
    }
}
