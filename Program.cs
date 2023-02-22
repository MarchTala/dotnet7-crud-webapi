using DotNetEnv;
using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load environment variables
Env.Load();

// Load appsettings.json configuration file
builder.Configuration.AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true);

// Get environment variables
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Replace variables in connection string
var connectionString =
   builder.Configuration.GetConnectionString("DefaultConnection")
   ?.Replace("${DB_HOST}", dbHost)
   .Replace("${DB_PORT}", dbPort)
   .Replace("${DB_DATABASE}", dbName)
   .Replace("${DB_USERNAME}", dbUser)
   .Replace("${DB_PASSWORD}", dbPass);
if (connectionString is null)
{
   throw new Exception("DefaultConnection not found in configuration");
}

// Add the DbContext to the container
builder.Services.AddDbContext<ApiDbContext>(
   options => options.UseMySql(
      connectionString,
      Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")
   )
);

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
