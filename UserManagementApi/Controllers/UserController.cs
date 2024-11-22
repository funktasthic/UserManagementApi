using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Controllers;
using UserManagementApi.DTOs.User;
using UserManagementApi.Services.Interfaces;

namespace UserManagementApi.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        return await _userService.GetAll();
    }

    [HttpGet("{uuid}")]
    public async Task<UserDto> GetByUUID(string uuid)
    {
        return await _userService.GetByUUID(uuid);
    }

    [HttpPost]
    public async Task<UserDto> Post([FromBody] UserCreateRequestDto userCreateRequestDto)
    {
        return await _userService.Create(userCreateRequestDto);
    }


    [HttpPut("{uuid}")]
    public async Task<UserDto> Put(string uuid, [FromBody] UserUpdateRequestDto userUpdateRequestDto)
    {
        return await _userService.EditUser(userUpdateRequestDto);
    }

    [HttpDelete("{uuid}")]
    public async Task<IActionResult> Delete(string uuid)
    {
        var response = await _userService.DeleteUser(uuid);
        return Ok(response);
    }
}