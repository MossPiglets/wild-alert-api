using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Persistence.Entities.SensorData;

public class SensorDataEntity
{
    public Guid Id { get; set; }
    public Guid SensorId { get; set; }
    public DateTime DetectedAt { get; set; }    
    public AnimalType DetectedAnimal { get; set; }
}