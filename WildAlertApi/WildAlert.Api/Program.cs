using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WildAlert.Api.Extensions;
using WildAlert.Api.Models;
using WildAlert.Api.Models.Alerts;
using WildAlert.Application.Extensions;
using WildAlert.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddApplication();

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

builder.Services.AddCors();

// Fluent validation
builder.Services.AddValidatorsFromAssemblyContaining<CreateAlertValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Migrate().Run();

