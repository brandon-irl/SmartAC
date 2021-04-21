using System.Collections.Generic;
using MediatR;

namespace SensorReadingDataHub.Contracts
{
    public class ReadingReported : INotification
    {
        public IEnumerable<ISensorReading> Readings { get; set; }
    }

}