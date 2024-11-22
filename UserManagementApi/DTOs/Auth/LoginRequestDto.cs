using System.ComponentModel.DataAnnotations;
using UserManagementApi.DTOs.Models;

namespace UserManagementApi.DTOs.Auth
{
    public class LoginRequestDto : BaseModelDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
    }
}