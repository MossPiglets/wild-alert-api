using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Authentication;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Alerts.Commands.CreateAlert;
using WildAlert.Application.Requests.Alerts.Commands.DeleteAlert;
using WildAlert.Application.Requests.Alerts.Queries.GetAlerts;
using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlertsController(IMediator mediator)
    {
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
    
    [ServiceFilter((typeof(ApiKeyAuthFilter)))]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteAlertCommand()
        {
            Id = id
        };

        await _mediator.Send(command);
        return Ok();
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

        var alerts = await _mediator.Send(query, token);
        return Ok(alerts);
    }
}