using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Registration.Authentication
{
    public class DeviceSecretProvider
    {
        private const string secretKeyResourceName = "Registration.Devices.txt";
        private IDictionary<string, string> secrets;
        
        public async Task<IDictionary<string, string>> GetSecrets()
        {
            if(secrets != null)
                return secrets;

            var assembly = Assembly.GetExecutingAssembly();            
            secrets = new Dictionary<string, string>();
            using(var stream = assembly.GetManifestResourceStream(secretKeyResourceName))
            using(var sr = new StreamReader(stream))
            {
                while(sr.Peek() >= 1)
                {
                    // TODO: Hash password
                    secrets.Add(await sr.ReadLineAsync(), await sr.ReadLineAsync());
                }
            }

            return secrets;
        }
    }
}