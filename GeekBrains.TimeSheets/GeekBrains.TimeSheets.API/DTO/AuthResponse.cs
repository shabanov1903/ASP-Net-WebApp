namespace GeekBrains.TimeSheets.API.DTO
{
    public class AuthResponse
    {
<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/DTO/PersonDTO.cs
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public int Age { get; set; }
=======
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API/DTO/AuthResponse.cs
    }
}
