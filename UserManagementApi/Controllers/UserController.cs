using Microsoft.AspNetCore.Mvc;
using UserManagementApi.DTOs.User;
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
    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        return await _userService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        try
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new MessageResponse<string>("User not found") { Status = "error" });
        }
        catch (DisabledUserException ex)
        {
            return BadRequest(new MessageResponse<string>("User is disabled") { Status = "error" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new MessageResponse<string>("An unexpected error occurred") { Status = "error" });
        }
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