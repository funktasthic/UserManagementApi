using AutoMapper;
using UserManagementApi.DTOs.User;
using UserManagementApi.Exceptions;
using UserManagementApi.Models.Common;
using UserManagementApi.Repositories.Interfaces;
using UserManagementApi.Services.Interfaces;

namespace UserManagementApi.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUsersRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<BaseResponse<UserDto>> CreateUser(UserCreateRequestDto userCreateRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUser(string id)
    {
        var user = await _repository.GetById(id);

        if (user == null)
        {
            throw new NotFoundException($"User with ID '{id}'");
        }

        var result = await _repository.DeleteUser(id);

        if (!result)
        {
            throw new Exception();
        }

        return true;
    }

    public Task<UserDto> EditUser(UserUpdateRequestDto userUpdateRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<UserDto>>> GetAllUsersPaged(int page, int pageSize)
    {
        if (page <= 0 || pageSize <= 0)
        {
            throw new BadRequestException("Page and Page Size must be greater than 0");
        }

        var users = await _repository.GetAllUsers(page, pageSize);

        if (users == null || !users.Any())
        {
            throw new NotFoundException("No users found");
        }

        var userDtos = _mapper.Map<List<UserDto>>(users);

        return new BaseResponse<List<UserDto>>("Users retrieved successfully", userDtos);
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
