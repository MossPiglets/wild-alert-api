using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WildAlert.Persistence.Extensions;

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions
{
    public static void AddPersistence(this IServiceCollection services, IWebHostEnvironment environment, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x =>
        {
            x.UseSqlite("Filename=mydb.db;");
        });
    }
}