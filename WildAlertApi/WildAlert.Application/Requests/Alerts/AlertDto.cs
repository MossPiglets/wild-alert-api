using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Application.Requests.Alerts;

public class AlertDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
    public string? Comments { get; set; }
    public AnimalType Animal { get; set; }
}