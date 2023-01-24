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
    }
}