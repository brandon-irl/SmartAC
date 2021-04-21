using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Administration
{
    public class AlertQuery : IRequest<IEnumerable<Alert>> { }

    public class AlertQueryHandler : IRequestHandler<AlertQuery, IEnumerable<Alert>>
    {
        private readonly AdministrationContext _context;

        public AlertQueryHandler(AdministrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Alert>> Handle(AlertQuery request, CancellationToken cancellationToken)
        {
            return await _context.Alerts.ToListAsync();
        }
    }
}