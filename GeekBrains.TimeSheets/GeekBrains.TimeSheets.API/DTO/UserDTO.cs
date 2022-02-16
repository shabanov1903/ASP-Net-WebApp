namespace GeekBrains.TimeSheets.API.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public short[]? PasswordHash { get; set; }
        public string? Role { get; set; }
    }
}
