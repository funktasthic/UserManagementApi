using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = null!;
        [Required, MaxLength(15)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = null!;
        [Required, MaxLength(30)]
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}