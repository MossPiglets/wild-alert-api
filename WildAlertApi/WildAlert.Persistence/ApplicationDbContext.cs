using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence.Entities.Alert;

namespace WildAlert.Persistence;

public class ApplicationDbContext : DbContext 
{
    public DbSet<AlertEntity> Alerts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
        
    }
}