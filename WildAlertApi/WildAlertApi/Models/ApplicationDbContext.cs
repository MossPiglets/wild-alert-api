using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using WildAlertApi.Models.Alerts;

namespace WildAlertApi.Models;

public class ApplicationDbContext : DbContext 
{
    public DbSet<Alert> Alerts { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
        
    }
}