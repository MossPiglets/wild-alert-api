namespace WildAlert.Api.Models.Alerts;

public class CreateAlert
{
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
    public string? Comments { get; set; }
    public AnimalType Animal { get; set; }
}