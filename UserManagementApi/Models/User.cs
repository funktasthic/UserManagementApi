using System.ComponentModel.DataAnnotations;

namespace UserAppApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(15)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = null!;
        [Required, MaxLength(30)]
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; } = false;
    }
}