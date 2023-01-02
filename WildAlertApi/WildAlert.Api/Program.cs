using System.Text.Json.Serialization;
using WildAlert.Api.Extensions;
using WildAlert.Application.Extensions;
using WildAlert.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Environment, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddApplication();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Migrate().Run();
