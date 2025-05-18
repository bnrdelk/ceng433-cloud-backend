using cloudBackend.DataAccess;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using cloudBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "8080"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("https://ceng433-cloud-computing-d2c30.web.app")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";
// Add controllers to the services.
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}



app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();


app.Run();