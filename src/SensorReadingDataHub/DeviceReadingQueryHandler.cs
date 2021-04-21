using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SensorReadingDataHub.Contracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SensorReadingDataHub
{
    public class DeviceReadingQueryHandler : IRequestHandler<DeviceReadingQuery, IEnumerable<ISensorReading>>
    {
        private readonly SensorReadingContext _context;

        public DeviceReadingQueryHandler(SensorReadingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ISensorReading>> Handle(DeviceReadingQuery request, CancellationToken cancellationToken)
        {
            var filter = request.SerialNumbers != null && request.SerialNumbers.Any();
            return await _context.SensorReadings.Where(_ => filter ? request.SerialNumbers.Contains(_.DeviceSerialNumber) : true)
                                                .ToListAsync();
        }
    }
}