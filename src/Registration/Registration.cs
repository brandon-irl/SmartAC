using Registration.Authentication;
using Registration.Contracts;

namespace Registration
{
    public record Registration
    {
        public DeviceCredentials Credentials { get; set; }
        public string FirmwareVersion { get; set; }
    }
}