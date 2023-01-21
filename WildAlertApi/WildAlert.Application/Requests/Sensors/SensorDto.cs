namespace WildAlert.Application.Requests.Sensors;

public class SensorDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
}