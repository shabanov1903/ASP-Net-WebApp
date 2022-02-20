namespace GeekBrains.TimeSheets.API.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public string? Role { get; set; }
        public string? RefreshToken { get; set; }
    }
}
