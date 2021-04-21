using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registration.Contracts;

namespace Registration
{
    public class DeviceQueryHandler : IRequestHandler<DeviceQuery, IEnumerable<IDevice>>
    {
        private readonly RegistrationContext _context;

        public DeviceQueryHandler(RegistrationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IDevice>> Handle(DeviceQuery request, CancellationToken cancellationToken)
        {
            var filter = request.SerialNumbers != null && request.SerialNumbers.Any();
            return await _context.Devices.Where(_ => filter ? request.SerialNumbers.Contains(_.SerialNumber) : true)
                                         .ToListAsync();
        }
    }
}