using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Administration
{
    public class ResolveAlertCommand : IRequest
    {
        int AlertId { get; }
        public ResolveAlertCommand(int alertId)
        {
            AlertId = alertId;
        }
    }

    public class ResolveAlertCommandHandler : IRequestHandler<ResolveAlertCommand>
    {

        private readonly AdministrationContext _context;

        public ResolveAlertCommandHandler(AdministrationContext context)
        {
            _context = context;
        }
        
        public Task<Unit> Handle(ResolveAlertCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }


}