using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SensorReadingDataHub.Contracts;

namespace SensorReadingDataHub
{
    public class ReadingReportedHandler : INotificationHandler<ReadingReported>
    {
        private readonly SensorReadingContext _context;

        public ReadingReportedHandler(SensorReadingContext context)
        {
            _context = context;
        }

        public async Task Handle(ReadingReported notification, CancellationToken cancellationToken)
        {
            var readings = notification.Readings.Select(_ => new SensorReading(_));
            // TODO: figure out Upsert
            foreach(var reading in readings)            
                if(! await _context.SensorReadings.ContainsAsync(reading))
                    await _context.SensorReadings.AddAsync(reading);
            await _context.SaveChangesAsync();
        }
    }
}