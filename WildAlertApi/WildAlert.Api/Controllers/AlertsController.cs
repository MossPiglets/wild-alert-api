using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Alerts.Commands.CreateAlert;
using WildAlert.Application.Requests.Alerts.Commands.DeleteAlert;
using WildAlert.Application.Requests.Alerts.Queries.GetAlerts;
using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Api.Controllers;

public class AlertsController : Controller
{
    private readonly IMediator _mediator;

    public AlertsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Longitude,Latitude,Comments,Animal")]CreateAlertCommand request, [FromServices] IValidator<CreateAlertCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        var alert = await _mediator.Send(request, token);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AlertEntity>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Index([FromQuery] GetAlertsQuery query, [FromServices] IValidator<GetAlertsQuery> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(query, token);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }
    
        var alerts = await _mediator.Send(query, token);
        return View(alerts);
    }
    
    public async Task<IActionResult> Delete([FromRoute]Guid id)
    {
        var command = new DeleteAlertCommand()
        {
            Id = id
        };

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}