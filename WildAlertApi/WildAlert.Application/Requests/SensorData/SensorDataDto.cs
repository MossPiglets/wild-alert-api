using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Application.Requests.SensorData;

public class SensorDataDto
{
    public Guid Id { get; set; }
    public DateTime DetectedAt { get; set; }    
    public AnimalType DetectedAnimal { get; set; }
}