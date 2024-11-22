using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
using UserManagementApi.DTOs.Auth;
using UserManagementApi.Exceptions;
using UserManagementApi.Models;
using UserManagementApi.Repositories.Interfaces;
using UserManagementApi.Services.Interfaces;

namespace UserManagementApi.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapperService _mapperService;
        private readonly IHttpContextAccessor _ctxAccesor;
        private readonly string _jwtSecret;

        public AuthService(IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IMapperService mapperService,
        IHttpContextAccessor ctxAccesor
        )
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapperService = mapperService;
            _ctxAccesor = ctxAccesor;
            _jwtSecret = Env.GetString("JWT_SECRET") ?? throw new InvalidJwtException("JWT_SECRET not found");
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            // obtener al usuario por base de datos
            var user = await _unitOfWork.UsersRepository.GetByEmail(loginRequestDto.Email)
                ?? throw new InvalidCredentialException("Invalid Credentials");

            // Verificar contraseña
            var verifyPassword = BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.Password);
            if (!verifyPassword)
                throw new InvalidCredentialException("Invalid Credentials");

            // Verificar si es que esta habilitado
            if (!user.IsActive)
                throw new DisabledUserException("User is not enabled - Contact an administrator");

            // Generar token y asignarlo
            var token = CreateToken(user.Email);
            var response = _mapperService.Map<User, LoginResponseDto>(user);
            MapMissingFields(user, token, response);
            return response;
        }
        
        private static void MapMissingFields(User createdUser, string token, LoginResponseDto response)
        {
            response.Token = token;
        }

        private async Task ValidateEmail(string email)
        {
            var user = await _unitOfWork.UsersRepository.GetByEmail(email);
            if (user is not null)
                throw new DuplicateUserException("Email already in use");
        }


        private string CreateToken(string email)
        {
            var claims = new List<Claim>{
                new (ClaimTypes.Email, email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        

        private ClaimsPrincipal GetHttpUser()
        {
            //Check if the HttpContext is available to work with
            return (_ctxAccesor.HttpContext?.User) ??
                throw new UnauthorizedAccessException();
        }
    
}