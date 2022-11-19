using Microsoft.EntityFrameworkCore;
using WildAlertApi.Models;

namespace WildAlertApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication Migrate(this WebApplication application)
    {
        if (!application.Environment.IsProduction())
        {
            return application;
        }
        application.Logger.Log(LogLevel.Information, "Checking for migrations...");
        var dbContext = application.Services.GetRequiredService<ApplicationDbContext>();
        var migrations = dbContext.Database.GetPendingMigrations();
        if (migrations.Any())
        {
            application.Logger.Log(LogLevel.Information, "Migration started");
            dbContext.Database.Migrate();
        }

        return application;
    }
}