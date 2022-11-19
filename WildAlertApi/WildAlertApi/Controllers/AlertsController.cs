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
}