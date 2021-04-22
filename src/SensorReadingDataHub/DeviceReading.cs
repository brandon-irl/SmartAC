using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SensorReadingDataHub
{
    public record DeviceReading
    {
        [Required]
        public string SerialNumber { get; init; }
        [Required]
        public IEnumerable<SensorReading> SensorReadings { get; init; }
    }
}