using Registration.Authentication;
using Registration.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Registration
{
    public record Registration
    {
        [Required]
        public DeviceCredentials Credentials { get; set; }
        public string FirmwareVersion { get; set; }
    }
}