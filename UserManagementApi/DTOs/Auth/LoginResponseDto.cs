
namespace UserManagementApi.DTOs.Auth;

public class LoginResponseDto
{
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public string Token { get; set; }
}