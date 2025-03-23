using ScaleAPI.Data.Access;
using ScaleAPI.Data.Repository;
using ScaleAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDapperDbContext, DaperSqlDbContext>();
builder.Services.AddScoped<ScaleRepo>();
builder.Services.AddScoped<ScaleService>();

var app = builder.Build();

app.UseRouting();

app.MapGet("/", () => "Scale API is running!");

app.Run();
