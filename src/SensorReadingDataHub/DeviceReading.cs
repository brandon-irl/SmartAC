using System.Collections.Generic;
using SensorReadingDataHub.Contracts;

namespace SensorReadingDataHub
{
    public record DeviceReading
    {
        public string SerialNumber { get; init; }
        public IEnumerable<SensorReading> SensorReadings { get; init; }
    }
}