using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
             _context.SensorReadings.UpdateRange(notification.Readings.Select(_ => new SensorReading(_)));
            await _context.SaveChangesAsync();
        }
    }
}