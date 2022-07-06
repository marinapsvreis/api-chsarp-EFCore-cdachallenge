using API_DOTNET.Data;
using API_DOTNET.Repository;
using API_DOTNET.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);

  c.SwaggerDoc("v1",
    new Microsoft.OpenApi.Models.OpenApiInfo
    {
      Title = "Policia do Cidade Alta",
      Description = "Demo Api para Controle de Criminal Codes",
      Version = "v1"
    });
});
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
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
