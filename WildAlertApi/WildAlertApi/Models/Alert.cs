namespace WildAlertApi;

public class Alert
{
    public DateTime CreatedAt { get; set; }
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
    public string? Comments { get; set; }
    public AnimalType Animal { get; set; }
}

public enum AnimalType
{
    Unknown,
    Boar,
    Fox,
    Deer,
    // add new entry here
    Other = 666
}