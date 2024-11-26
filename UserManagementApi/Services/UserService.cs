using AutoMapper;
using UserManagementApi.DTOs.User;
using UserManagementApi.Exceptions;
using UserManagementApi.Helpers;
using UserManagementApi.Models;
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

    public async Task<BaseResponse<UserDto>> CreateUser(UserCreateRequestDto userCreateRequestDto)
    {
        if (string.IsNullOrWhiteSpace(userCreateRequestDto.Name) ||
            string.IsNullOrWhiteSpace(userCreateRequestDto.LastName) ||
            string.IsNullOrWhiteSpace(userCreateRequestDto.Email) ||
            string.IsNullOrWhiteSpace(userCreateRequestDto.Password))
        {
            throw new BadRequestException("Invalid user data provided.");
        }

        var existingUser = await _repository.GetByEmail(userCreateRequestDto.Email);
        if (existingUser != null)
        {
            throw new DuplicateUserException("Email is already in use");
        }

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = userCreateRequestDto.Name,
            LastName = userCreateRequestDto.LastName,
            Email = userCreateRequestDto.Email,
            Password = PasswordHelper.EncryptPassword(userCreateRequestDto.Password),
            IsActive = true
        };

        var createdUser = await _repository.CreateUser(user);

        if (createdUser == null)
        {
            throw new Exception("Failed to create user");
        }

        var userDto = _mapper.Map<UserDto>(createdUser);

        return new BaseResponse<UserDto>("User created successfully", userDto);
    }

    public async Task<bool> DeleteUser(string id)
    {
        var user = await _repository.GetById(id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var result = await _repository.DeleteUser(id);

        if (!result)
        {
            throw new Exception();
        }

        return true;
    }

    public async Task<UserDto> EditUser(string id, UserUpdateRequestDto userUpdateRequestDto)
    {
        var user = await _repository.GetById(id);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        if (string.IsNullOrWhiteSpace(userUpdateRequestDto.Name) ||
            string.IsNullOrWhiteSpace(userUpdateRequestDto.LastName) ||
            string.IsNullOrWhiteSpace(userUpdateRequestDto.Email) ||
            string.IsNullOrWhiteSpace(userUpdateRequestDto.Password))
        {
            throw new BadRequestException("Invalid user data provided.");
        }

        user.Name = userUpdateRequestDto.Name;
        user.LastName = userUpdateRequestDto.LastName;
        user.Email = userUpdateRequestDto.Email;
        user.Password = PasswordHelper.EncryptPassword(userUpdateRequestDto.Password);

        var result = await _repository.UpdateUser(id, user);

        if (result == null)
        {
            throw new Exception("Failed to update user");
        }

        return _mapper.Map<UserDto>(user);
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
            throw new NotFoundException("User not found");
        }

        if (!user.IsActive)
        {
            throw new DisabledUserException("User is disabled");
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
