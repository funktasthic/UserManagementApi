using UserManagementApi.DTOs.Auth;

namespace UserManagementApi.Services.Interfaces;

public interface IAuthService
{

    /// <summary>
    /// Metodo que autentifica al usuario activo comparando las credenciales otorgadas.
    /// </summary>
    /// <param name="loginRequestDto"> que contiene las credenciales de inicio de sesion</param>
    /// <returns><see cref="LoginResponseDto"/></returns>
    public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    
}