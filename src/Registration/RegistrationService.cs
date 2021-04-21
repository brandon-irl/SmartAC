using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Registration
{
    public class RegistrationService
    {
        private readonly ILogger<RegistrationService> _logger;
        private readonly RegistrationContext _context;

        public RegistrationService(ILogger<RegistrationService> logger, RegistrationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task RegisterDevice(Device newDevice)
        {
            _context.Devices.Add(newDevice with { RegistrationDate = DateTime.UtcNow });
            await _context.SaveChangesAsync();
        }
    }
}