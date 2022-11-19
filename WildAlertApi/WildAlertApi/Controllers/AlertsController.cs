using System.Net;
using Microsoft.AspNetCore.Mvc;
using WildAlertApi.Models;
using WildAlertApi.Models.Alerts;

namespace WildAlertApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertsController : ControllerBase
{
    private readonly ILogger<AlertsController> _logger;
    private readonly ApplicationDbContext _context;

    public AlertsController(ILogger<AlertsController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public IActionResult Post(CreateAlert createAlert)
    {
        Alert alert = new Alert()
        {
            Animal = createAlert.Animal,
            Comments = createAlert.Comments,
            CreatedAt = DateTime.UtcNow,
            Latitude = createAlert.Latitude,
            Longitude = createAlert.Longitude,
            Id = Guid.NewGuid()
        };
        _context.Alerts.Add(alert);
        _context.SaveChanges();
        return Ok(alert);
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Alert>), (int) HttpStatusCode.OK)]
    public IActionResult Get([FromQuery] GetAlertsQuery query)
    {
        const double radius = 0.016;
        IEnumerable<Alert> alerts = _context.Alerts
            .Where(x => (query.Latitude==null || query.Longitude==null) ||
                        ((x.Latitude < query.Latitude + radius && x.Latitude > query.Latitude - radius) &&
                        (x.Longitude < query.Longitude + radius && x.Longitude > query.Longitude - radius)))
            .ToList();       
        return Ok(alerts);
    }
}