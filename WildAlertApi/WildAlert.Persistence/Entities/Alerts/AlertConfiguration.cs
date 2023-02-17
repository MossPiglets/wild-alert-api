using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WildAlert.Persistence.Entities.Alerts;

public class AlertConfiguration : IEntityTypeConfiguration<AlertEntity>
{
    public void Configure(EntityTypeBuilder<AlertEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasData(
            new List<AlertEntity>
            {
                new AlertEntity
                {
                    Id = Guid.Parse("BF152ECE-9DD3-4F60-ABAB-32C43235E2FB"),
                    CreatedAt = new DateTime(2023,02,14),
                    Longitude = 20,
                    Latitude = 50,
                    Comments = "testowy alert dzik",
                    Animal = AnimalType.Boar
                },    
                new AlertEntity
                {
                    Id = Guid.Parse("9390ACD1-F75C-4541-BF26-E54A04DE1340"),
                    CreatedAt = new DateTime(2023,02,13),
                    Longitude = 20,
                    Latitude = 30,
                    Comments = "testowy alert jeleń",
                    Animal = AnimalType.Deer
                },    
                new AlertEntity
                {
                    Id = Guid.Parse("351B8C74-6F0D-4E1D-846A-87432EE6E9A3"),
                    CreatedAt = new DateTime(2023,02,15),
                    Longitude = 30,
                    Latitude = 20,
                    Comments = "testowy alert lis",
                    Animal = AnimalType.Fox
                },           

            });
    }
}