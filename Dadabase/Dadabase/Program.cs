using Dadabase.data;
using Dadabase.Services;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Dbf25TeamNamContext>(o => o.UseNpgsql(builder.Configuration["DB_CONN"]));

builder.Services.AddScoped<IJokeService, JokeService>();
builder.Services.AddScoped<IAudienceService, AudienceService>();
builder.Services.AddScoped<IAdminService, AdminService>();

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
app.MapGet("/", () => "Hello World");
app.UseRouting();
app.MapGet("/testt", () => "works");
app.Run();

public partial class Program { }