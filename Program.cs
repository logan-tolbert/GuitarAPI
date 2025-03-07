var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseSession();
app.UseRouting();

app.MapGet("/", () => "Guitar API is running....");

app.Run();
