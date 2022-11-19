using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WildAlertApi.Extensions;
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
    public IActionResult Post(CreateAlert createAlert, [FromServices] IValidator<CreateAlert> validator)
    {
        ValidationResult result = validator.Validate(createAlert);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }
        
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
    public IActionResult Get([FromQuery] GetAlertsQuery query, [FromServices] IValidator<GetAlertsQuery> validator)
    {
        ValidationResult result = validator.Validate(query);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        const double radius = 0.016;
        IEnumerable<Alert> alerts = _context.Alerts
            .Where(x => (query.Latitude==null || query.Longitude==null) ||
                        ((x.Latitude < query.Latitude + radius && x.Latitude > query.Latitude - radius) &&
                        (x.Longitude < query.Longitude + radius && x.Longitude > query.Longitude - radius)))
            .ToList();       
        return Ok(alerts);
    }
}