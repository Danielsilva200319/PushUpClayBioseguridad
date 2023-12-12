using System.Reflection;
using Api.Extensions;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.BearerToken; //👈
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Serilog;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services
                .AddAuthentication()
                .AddBearerToken(); //👈
builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
/* builder.Services.AddJwt(builder.Configuration); */
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BiosegurityContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();
app.MapGet("/login", (string username) =>
{
    var claimsPrincipal = new ClaimsPrincipal
    (
        new ClaimsIdentity
        (
            new[] { new Claim(ClaimTypes.Name, username)},
            BearerTokenDefaults.AuthenticationScheme //👈
        )
    );
    return Results.SignIn(claimsPrincipal);
});
app.MapGet("/user", (ClaimsPrincipal user) => 
{
    return Results.Ok($"Welcome {user.Identity.Name}!");
})
.RequireAuthorization();
/* app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}"); */
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<BiosegurityContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrio un error durante la migracion");
    }
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();