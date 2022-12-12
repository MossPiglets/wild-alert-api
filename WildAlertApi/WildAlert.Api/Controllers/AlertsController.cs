using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Alerts.Commands.CreateAlert;
using WildAlert.Application.Requests.Alerts.Queries.GetQuery;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alert;

namespace WildAlert.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public AlertsController(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAlertCommand request, [FromServices] IValidator<CreateAlertCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        var alert = await _mediator.Send(request, token);
        return Ok(alert);
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AlertEntity>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromQuery] GetAlertsQuery query, [FromServices] IValidator<GetAlertsQuery> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(query, token);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }
        //logikę przenieść do handlera
        const double radius = 0.016;
        var alerts = await _context.Alerts
            .Where(x => (query.Latitude==null || query.Longitude==null) ||
                        ((x.Latitude < query.Latitude + radius && x.Latitude > query.Latitude - radius) &&
                        (x.Longitude < query.Longitude + radius && x.Longitude > query.Longitude - radius)))
            .ToListAsync(token);       
        return Ok(alerts);
    }
}