using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;

namespace WildAlert.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication Migrate(this WebApplication application)
    {
        application.Logger.Log(LogLevel.Information, "Checking for migrations...");
        using var scope = application.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var migrations = dbContext.Database.GetPendingMigrations();
        if (migrations.Any())
        {
            application.Logger.Log(LogLevel.Information, "Migration started");
            dbContext.Database.Migrate();
        }
        return application;
    }
}