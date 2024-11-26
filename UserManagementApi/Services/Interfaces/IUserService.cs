using UserManagementApi.DTOs.User;
using UserManagementApi.Models.Common;

namespace UserManagementApi.Services.Interfaces;

public interface IUserService
{
    public Task<BaseResponse<List<UserDto>>> GetAllUsersPaged(int page, int pageSize);

    public Task<BaseResponse<UserDto>> GetUserById(string id);

    public Task<BaseResponse<UserDto>> CreateUser(UserCreateRequestDto userCreateRequestDto);

    public Task<UserDto> EditUser(string id, UserUpdateRequestDto userUpdateRequestDto);

    public Task<bool> DeleteUser(string id);


}