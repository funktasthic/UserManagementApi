using Microsoft.AspNetCore.Mvc;
using UserManagementApi.DTOs.User;
using UserManagementApi.Errors;
using UserManagementApi.Exceptions;
using UserManagementApi.Models.Common;
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
    public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var response = await _userService.GetAllUsersPaged(page, pageSize);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var result = await _userService.GetUserById(id);
        return Ok(result);
    }


    [HttpPost("create")]
    public async Task<BaseResponse<UserDto>> Post([FromBody] UserCreateRequestDto userCreateRequestDto)
    {
        return await _userService.CreateUser(userCreateRequestDto);
    }

    [HttpPatch("{id}")]
    public async Task<UserDto> Patch(string id, [FromBody] UserUpdateRequestDto userUpdateRequestDto)
    {
        return await _userService.EditUser(userUpdateRequestDto);
    }

    [HttpPatch("delete/{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        try
        {
            var result = await _userService.DeleteUser(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred", details = ex.Message });
        }
    }
}