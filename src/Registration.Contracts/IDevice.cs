using System;

namespace Registration.Contracts
{
    public interface IDevice
    {
        public string SerialNumber {get; init;}
        public DateTime RegistrationDate{get; init;}
        public string FirmwareVersion {get; init;}
    }
}