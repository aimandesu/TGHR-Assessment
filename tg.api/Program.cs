using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;
using tg.infrastructure;
using tg.application;
using tg.infrastructure.Data;
using tg.api.Extensions;
// using tg.infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureJWTPolicy(builder.Configuration);
builder.Services.ConfigureIdentityPolicy();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
dataContext?.Database.EnsureCreated();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
