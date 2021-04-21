using System;

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
    }
}