using UserManagementApi.DTOs.Auth;

namespace UserManagementApi.Services.Interfaces;

public interface IAuthService
{

    public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    
    public string GetUserEmailInToken();
    
}