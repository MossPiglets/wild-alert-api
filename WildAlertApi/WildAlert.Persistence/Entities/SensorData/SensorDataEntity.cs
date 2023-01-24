using WildAlert.Persistence.Entities.Alerts;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Persistence.Entities.SensorData;

public class SensorDataEntity
{
    public Guid Id { get; set; }
    public DateTime DetectedAt { get; set; }    
    public AnimalType DetectedAnimal { get; set; }
    public Guid SensorId { get; set; }
    public SensorEntity Sensor { get; set; }
}