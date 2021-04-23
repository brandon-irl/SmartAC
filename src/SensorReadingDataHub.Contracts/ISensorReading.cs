using System;
using System.Collections.Generic;
using Administration.Contracts;

namespace SensorReadingDataHub.Contracts
{
    public interface ISensorReading
    {
        public string DeviceSerialNumber { get; init; }
        public DateTime Time { get; init; }
        public double Temperature { get; init; }
        public int Humidity { get; init; }
        public int COLevel { get; init; }
        public string HealthStatus { get; init; }
        public IEnumerable<IAlert> Alerts { get; init; }
    }
}