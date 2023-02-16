using MediatR;

namespace WildAlert.Application.Requests.Alerts.Commands.DeleteAlert;

    public class DeleteAlertCommand : IRequest
    {
        public Guid Id { get; set; }
    }
