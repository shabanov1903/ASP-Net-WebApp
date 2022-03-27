using System.ComponentModel.DataAnnotations;

namespace GeekBrains.TimeSheets.API.DTO
{
    public class UserDTO
    {
        [Required]
        [RegularExpression(@"[0-z]{8}-[0-z]{4}-[0-z]{4}-[0-z]{4}-[0-9]{12}")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string PasswordHash { get; set; }
        public string? Salt { get; set; }
        [StringLength(20)]
        public string Role { get; set; }
        public string? RefreshToken { get; set; }
    }
}
