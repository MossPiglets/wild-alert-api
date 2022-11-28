using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Models;
using WildAlert.Api.Models.Alerts;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Alerts.Commands.CreateAlert;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alert;

namespace WildAlert.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertsController : ControllerBase
{
    private readonly ILogger<AlertsController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public AlertsController(ILogger<AlertsController> logger, ApplicationDbContext context, Mediator mediator)
    {
        _logger = logger;
        _context = context;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAlertCommand request, [FromServices] IValidator<CreateAlertCommand> validator)
    {
        ValidationResult result = validator.Validate(request);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        var alert = await _mediator.Send(request);
        return Ok(alert);
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AlertEntity>), (int) HttpStatusCode.OK)]
    public IActionResult Get([FromQuery] GetAlertsQuery query, [FromServices] IValidator<GetAlertsQuery> validator)
    {
        ValidationResult result = validator.Validate(query);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        const double radius = 0.016;
        IEnumerable<AlertEntity> alerts = _context.Alerts
            .Where(x => (query.Latitude==null || query.Longitude==null) ||
                        ((x.Latitude < query.Latitude + radius && x.Latitude > query.Latitude - radius) &&
                        (x.Longitude < query.Longitude + radius && x.Longitude > query.Longitude - radius)))
            .ToList();       
        return Ok(alerts);
    }
}