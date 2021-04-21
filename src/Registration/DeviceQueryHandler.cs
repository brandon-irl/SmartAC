using System.Collections.Generic;
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
            return await _context.Devices.ToListAsync();
        }
    }
}