using GeekBrains.TimeSheets.API.Services;
using GeekBrains.TimeSheets.API.Sources;
using GeekBrains.TimeSheets.DB.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� ������� ������������ �������
builder.Services.AddMapperService();
// ���������� ������� ����� � ����������
builder.Services.AddSingleton<IRepository>(service => new ListRepository(new Source().ListDataBase));

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
