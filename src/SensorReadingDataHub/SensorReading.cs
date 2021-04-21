using System;
using SensorReadingDataHub.Contracts;

namespace SensorReadingDataHub
{
    public record SensorReading : ISensorReading
    {
        public SensorReading() {}
        public SensorReading(ISensorReading reading)
        {
            DeviceSerialNumber = reading.DeviceSerialNumber;
            Time = reading.Time;
            Temperature = reading.Temperature;
            Humidity = reading.Humidity;
            COLevel = reading.COLevel;
            HealthStatus = reading.HealthStatus;
        }

        public string DeviceSerialNumber { get; init; }
        public DateTime Time {get; init;}
        public double Temperature { get; init; }
        public int Humidity { get; init; }
        public int COLevel { get; init; }
        public string HealthStatus { get; init; }
    }
}