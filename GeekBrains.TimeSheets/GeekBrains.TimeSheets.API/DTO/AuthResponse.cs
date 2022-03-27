namespace GeekBrains.TimeSheets.API.DTO
{
    public class AuthResponse
    {
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
