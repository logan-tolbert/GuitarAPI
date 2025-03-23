using ChordAPI.Data.Access;
using ChordAPI.Data.Repository;
using ChordAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISqlDbContext, SqlDbContext>();
builder.Services.AddScoped<ChordRepo>();
builder.Services.AddScoped<ChordService>();

var app = builder.Build();

app.UseRouting();

app.MapGet("/", () => "Chord API is running!");

app.Run();
