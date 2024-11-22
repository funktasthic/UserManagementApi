using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.DTOs.User;

public class UserUpdateRequestDto
{
    [Required, MaxLength(15)]
    public string Name { get; set; } = null!;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(30)]
    public string Password { get; set; } = null!;
}