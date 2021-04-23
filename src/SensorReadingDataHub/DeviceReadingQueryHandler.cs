using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SensorReadingDataHub.Contracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Administration.Contracts;

namespace SensorReadingDataHub
{
    public class DeviceReadingQueryHandler : IRequestHandler<DeviceReadingQuery, IEnumerable<ISensorReading>>
    {
        private readonly SensorReadingContext _context;
        private readonly IMediator _mediator;

        public DeviceReadingQueryHandler(SensorReadingContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ISensorReading>> Handle(DeviceReadingQuery request, CancellationToken cancellationToken)
        {
            var filter = request.SerialNumbers != null && request.SerialNumbers.Any();
            var alerts = await _mediator.Send(new AlertQuery { SerialNumbers = request.SerialNumbers });
            var readings = await _context.SensorReadings.Where(_ => filter ? request.SerialNumbers.Contains(_.DeviceSerialNumber) : true)
                                                        .OrderByDescending(_ => _.Time)
                                                        .ToListAsync();
            
            return readings.Select(_ => new SensorReading(_, alerts.Where(__ => _.Time == __.Time && !__.Resolved)));
                                                
        }
    }
}