namespace WildAlertApi.Models.Alerts;

public class GetAlertsQuery
{
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }

    public double Radius { get; set; } = 2;
}