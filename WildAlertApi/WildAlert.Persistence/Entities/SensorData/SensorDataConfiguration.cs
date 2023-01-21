using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WildAlert.Persistence.Entities.SensorData;

public class SensorDataConfiguration : IEntityTypeConfiguration<SensorDataEntity>
{
    public void Configure(EntityTypeBuilder<SensorDataEntity> builder)
    {
        builder.HasKey(x => x.Id);
        //todo: jakieś zależności z sensorami?
    }

}