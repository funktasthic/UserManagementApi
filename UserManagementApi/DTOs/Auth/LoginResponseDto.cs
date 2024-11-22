using UserManagementApi.DTOs.Models;

namespace UserManagementApi.DTOs.Auth;

public class LoginResponseDto : BaseModelDto
{
    public string Email { get; set; }
    public bool IsEnabled { get; set; }
    public string Token { get; set; }
}