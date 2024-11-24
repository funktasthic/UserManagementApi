using UserManagementApi.DTOs.User;
using UserManagementApi.Models.Common;

namespace UserManagementApi.Services.Interfaces;

public interface IUserService
{
    public Task<List<UserDto>> GetAll();

    public Task<BaseResponse<UserDto>> GetUserById(string id);

    public Task<UserDto> Create(UserCreateRequestDto userCreateRequestDto);

    public Task<UserDto> EditUser(UserUpdateRequestDto userUpdateRequestDto);

    public Task<bool> DeleteUser(string id);
}