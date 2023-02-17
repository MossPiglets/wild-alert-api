using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Persistence.Entities.SensorData;

public class SensorDataConfiguration : IEntityTypeConfiguration<SensorDataEntity>
{
    public void Configure(EntityTypeBuilder<SensorDataEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasData(
            new List<SensorDataEntity>
            {
                new SensorDataEntity
                {
                    Id = Guid.Parse("6964B836-EF63-4736-B6CB-B4F7D74649F0"),
                    DetectedAt = new DateTime(2023, 02, 10),
                    DetectedAnimal = AnimalType.Boar,
                    SensorId = Guid.Parse("237AC44E-C4EA-4EF4-BC3C-D4DB57F5A343"),
                    Sensor = null
                },
                new SensorDataEntity
                {
                    Id = Guid.Parse("DC4EF180-4DC3-4C3A-A42E-2E034C693897"),
                    DetectedAt = new DateTime(2023, 02, 11),
                    DetectedAnimal = AnimalType.Other,
                    SensorId = Guid.Parse("3DC6ABCC-3D4D-4C34-8FB2-5E115B5B73CD"),
                    Sensor = null
                },
                new SensorDataEntity
                {
                    Id = Guid.Parse("FE447DA9-2C08-4BBB-9B4E-53043F56FFF1"),
                    DetectedAt = new DateTime(2023, 02, 12),
                    DetectedAnimal = AnimalType.Unknown,
                    SensorId = Guid.Parse("FE447DA9-2C08-4BBB-9B4E-53043F56FFF1"),
                    Sensor = null
                }
            });
    }
}