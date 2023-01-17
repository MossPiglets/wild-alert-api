using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;

namespace WildAlert.UnitTests.Factories;

public class ApplicationDbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        return new ApplicationDbContext(options); 
    }
}