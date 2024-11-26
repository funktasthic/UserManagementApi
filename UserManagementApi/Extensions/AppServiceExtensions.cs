using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagementApi.Services;
using Microsoft.OpenApi.Models;
using UserManagementApi.Exceptions;
using UserManagementApi.Repositories.Interfaces;
using UserManagementApi.Services.Interfaces;
using UserManagementApi.Repositories;

namespace UserManagementApi.Extensions;

public static class AppServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        InitEnvironmentVariables();
        AddAutoMapper(services);
        AddServices(services);
        AddSwaggerGen(services);
        AddUnitOfWork(services);
        AddAuthentication(services, config);
        AddHttpContextAccesor(services);
    }

    private static void InitEnvironmentVariables()
    {
        Env.Load();
    }

    // services here...
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IMapperService, MapperService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }


    // swagger configuration
    private static void AddSwaggerGen(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "UserManagement API", Version = "v1" })
        );

    }


    // unit of work here
    private static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    // Automappers here
    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
    }


    private static IServiceCollection AddAuthentication(IServiceCollection services, IConfiguration config)
    {
        var jwtSecret = Env.GetString("JWT_SECRET") ??
            throw new InvalidJwtException("JWT_SECRET not present in .ENV");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        return services;
    }


    private static void AddHttpContextAccesor(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
    }


}