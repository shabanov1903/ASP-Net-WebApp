namespace GeekBrains.TimeSheets.API.Services
{
    public static class User
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddSingleton<UserService>();
        }
    }
}
