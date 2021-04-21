using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SensorReadingDataHub.Contracts;

namespace Administration
{
    public class ReadingReportedHandler : INotificationHandler<ReadingReported>
    {
        private readonly AdministrationContext _context;
        private readonly string[] _healthStatuses = new string[] { "needs_service", "needs_new_filter", "gas_leak" };

        public ReadingReportedHandler(AdministrationContext context)
        {
            _context = context;
        }

        public async Task Handle(ReadingReported notification, CancellationToken cancellationToken)
        {
            foreach (var reading in notification.Readings)
            {
                if (reading.COLevel > 9)
                    await _context.Alerts.AddAsync(new Alert { DeviceSerialNumber = reading.DeviceSerialNumber, Time = reading.Time, Message = "CO Level > 9!" });
                if (_healthStatuses.Any(reading.HealthStatus.Contains))
                    await _context.Alerts.AddAsync(new Alert { DeviceSerialNumber = reading.DeviceSerialNumber, Time = reading.Time, Message = $"Status Alert!: {reading.HealthStatus}" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
