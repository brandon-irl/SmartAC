using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SensorReadingDataHub
{
    public record DeviceReading
    {
        [Required]
        public string SerialNumber { get; init; }
        [Required]
        [JsonConverter(typeof(SingleOrArrayConverter<SensorReading>))]
        public List<SensorReading> SensorReadings { get; init; }
    }
}