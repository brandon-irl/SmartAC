
using System;
using Registration.Contracts;

namespace Registration
{
    public record Device : IDevice
    {
        public Device() { }
        public Device(IDevice device)
        {
            SerialNumber = device.SerialNumber;
            RegistrationDate = device.RegistrationDate;
            FirmwareVersion = device.FirmwareVersion;
        }

        public string SerialNumber { get; init; }
        public DateTime RegistrationDate { get; init; }
        public string FirmwareVersion { get; init; }
    }
}