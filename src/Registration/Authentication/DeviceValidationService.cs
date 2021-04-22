using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace Registration.Authentication
{
    public class DeviceValidationService
    {
        private readonly IEnumerable<DeviceCredentials> devices;

        public DeviceValidationService()
        {
            devices = new List<DeviceCredentials> {
                new() {
                    SerialNumber = "123456789",
                    Secret = "This should be hashed"
                    }
            };
        }

        public void ValidateCredentials(DeviceCredentials DeviceCredentials)
        {
            bool isValid =
                devices.Any(d =>
                    d.SerialNumber == DeviceCredentials.SerialNumber &&
                    d.Secret == DeviceCredentials.Secret);

            if (!isValid)
            {
                throw new InvalidCredentialException();
            }
        }
    }
}