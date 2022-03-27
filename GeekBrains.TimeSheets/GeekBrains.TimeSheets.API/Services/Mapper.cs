namespace GeekBrains.TimeSheets.API.Services
{
    public static class Mapper
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton<MapperService>();
        }
    }
}
