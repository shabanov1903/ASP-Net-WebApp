using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Repository;
using static Microsoft.EntityFrameworkCore.SqliteDbContextOptionsBuilderExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавление сервиса самодельного маппера
builder.Services.AddMapperService();
// Добавление сервиса базы данных
var connectionString = builder.Configuration.GetConnectionString("sqlite");
builder.Services.AddDbContext<TimeSheetsDbContext>(options => options.UseSqlite(connectionString));
// Регистрация зависимостей
builder.Services.AddScoped<IRepository<UserContext>, UserRepositiry>();
builder.Services.AddScoped<IRepository<EmployeeContext>, EmployeeRepositiry>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
