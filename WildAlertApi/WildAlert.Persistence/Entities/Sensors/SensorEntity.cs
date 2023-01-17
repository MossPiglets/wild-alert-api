namespace WildAlert.Persistence.Entities.Sensors;

public class SensorEntity
{
    
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
}