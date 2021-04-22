using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Administration
{
    public class ResolveAlertCommand : IRequest
    {
        public int AlertId { get; }
        public string Username { get; }
        public ResolveAlertCommand(int alertId, string username)
        {
            AlertId = alertId;
            Username = username;
        }
    }

    public class ResolveAlertCommandHandler : IRequestHandler<ResolveAlertCommand>
    {

        private readonly AdministrationContext _context;

        public ResolveAlertCommandHandler(AdministrationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ResolveAlertCommand request, CancellationToken cancellationToken)
        {
            var alert = _context.Alerts.Where(_ => request.AlertId == _.Id).FirstOrDefault();
            if (alert != null)
                alert.ResolveAlert(request.Username);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }


}