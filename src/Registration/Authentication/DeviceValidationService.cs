using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Registration.Authentication
{
    public class DeviceValidationService
    {
        private readonly DeviceSecretProvider keyProvider;

        public DeviceValidationService(DeviceSecretProvider keyProvider)
        {
            this.keyProvider = keyProvider;
        }

        public async Task ValidateCredentials(DeviceCredentials DeviceCredentials)
        {
            if(DeviceCredentials == null || DeviceCredentials.SerialNumber == null)
                throw new InvalidCredentialException();

            var secrets = await keyProvider.GetSecrets();
            
            if (!secrets.ContainsKey(DeviceCredentials.SerialNumber) || secrets[DeviceCredentials.SerialNumber] != DeviceCredentials.Secret)
                throw new InvalidCredentialException();
        }

    }
}