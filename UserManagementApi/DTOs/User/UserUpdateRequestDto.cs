using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.DTOs.User;

public class UserUpdateRequestDto
{
    [Required]
    public string Nombre { get; set; } = null!;
    
    [Required]
    public string Apellidos { get; set; } = null!;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    public string HashedPassword { get; set; } = null!;
}