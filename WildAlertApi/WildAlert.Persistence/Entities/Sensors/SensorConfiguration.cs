using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WildAlert.Persistence.Entities.Sensors;

public class SensorConfiguration : IEntityTypeConfiguration<SensorEntity>
{
    public void Configure(EntityTypeBuilder<SensorEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.SensorData)
            .WithOne(x => x.Sensor)
            .HasForeignKey(x => x.SensorId);
        builder.HasData(
            new List<SensorEntity>
            {
                new SensorEntity
                {
                    Id = Guid.Parse("237AC44E-C4EA-4EF4-BC3C-D4DB57F5A343"),
                    Name = "skrzyzowanie x z y",
                    Longitude = 21,
                    Latitude = 31,
                    SensorData = null
                },
                new SensorEntity
                {
                    Id = Guid.Parse("3DC6ABCC-3D4D-4C34-8FB2-5E115B5B73CD"),
                    Name = "ulica przykladowa",
                    Longitude = 21,
                    Latitude = 51,
                    SensorData = null
                },
                new SensorEntity
                {
                    Id = Guid.Parse("FE447DA9-2C08-4BBB-9B4E-53043F56FFF1"),
                    Name = "testowy park",
                    Longitude = 31,
                    Latitude = 31,
                    SensorData = null
                }
            });
    }
}