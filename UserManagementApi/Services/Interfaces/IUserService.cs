using UserManagementApi.DTOs.User;

namespace UserManagementApi.Services.Interfaces;

public interface IUserService
{
    public Task<List<UserDto>> GetAll();

    public Task<UserDto> GetById(Guid uuid);

    public Task<UserDto> Create(UserCreateRequestDto userCreateRequestDto);

    public Task<UserDto> EditUser(UserUpdateRequestDto userUpdateRequestDto);

    public Task<bool> DeleteUser(Guid uuid);
}