using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Administration.Contracts;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Administration
{

    public class AlertQueryHandler : IRequestHandler<AlertQuery, IEnumerable<IAlert>>
    {
        private readonly AdministrationContext _context;

        public AlertQueryHandler(AdministrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<IAlert>> Handle(AlertQuery request, CancellationToken cancellationToken)
        {
            var filter = request.SerialNumbers != null && request.SerialNumbers.Any();
            return await _context.Alerts.Where(_ => filter ? request.SerialNumbers.Contains(_.DeviceSerialNumber) : true)
                                         .ToListAsync();
        }
    }
}