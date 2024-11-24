using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public async Task<UserDto> GetById(string id)
    {
        return await _userService.GetById(id);
    }

    [HttpPost]
    public async Task<UserDto> Post([FromBody] UserCreateRequestDto userCreateRequestDto)
    {
        return await _userService.Create(userCreateRequestDto);
    }

    [HttpPatch("{id}")]
    public async Task<UserDto> Patch(string id, [FromBody] UserUpdateRequestDto userUpdateRequestDto)
    {
        return await _userService.EditUser(userUpdateRequestDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _userService.DeleteUser(id);
        return Ok(response);
    }
}