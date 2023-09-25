
using DLS_WebAPI.Entites;
using DLS_WebAPI.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;
using Serilog;

//Configuring Serilog in Program.cs
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

//Using Serilog in this project... Not using the default Logger of ASP.Net
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

//adding mail service here
builder.Services.AddTransient<LocalMailService>();



//string _connectionString = string.Empty;
using StreamReader r = new StreamReader("appsettings.json");
string json = r.ReadToEnd();
var item = JsonConvert.DeserializeObject<ReadConnection>(json);
//_connectionString = item.ConString;

//builder.Services.AddDbContext<DlDbContext>(options =>options.UseMySql("server=10.11.201.76;port=3306;database=dl_db;user id=dldadm;password=Dld@Adm", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));
builder.Services.AddDbContext<DlDbContext>(options => options.UseMySql(item.ConString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));


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
public class ReadConnection
{
    public string ConString { get; set; }
}

