using Microsoft.EntityFrameworkCore;
using WildAlertApi.Extensions;
using WildAlertApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    string connectionString;
    if (builder.Environment.IsProduction())
    {
        connectionString = new HerokuDbConnector.HerokuDbConnector().Build();
    }
    else
    {
        connectionString = builder.Configuration.GetConnectionString("default");
    }
    x.UseNpgsql(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Migrate().Run();
