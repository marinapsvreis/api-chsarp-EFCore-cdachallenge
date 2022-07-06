using API_DOTNET.Data;
using API_DOTNET.Repository;
using API_DOTNET.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthenticationService, JwtService>();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICriminalCodeRepository, CriminalCodeRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
