
namespace UserManagementApi.DTOs.Auth;

public class LoginResponseDto
{
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Token { get; set; } = null!;
}