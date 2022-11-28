namespace WildAlert.Api.Models.Alerts;
public class Alert
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
    public string? Comments { get; set; }
    public AnimalType Animal { get; set; }
}