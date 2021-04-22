using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registration.Contracts;

namespace Registration
{
    public class RegisterDeviceCommand : IRequest
    {
        public IDevice Device { get; }

        public RegisterDeviceCommand(IDevice device)
        {
            Device = device;
        }
    }

    public class RegisterDeviceCommandHandler : IRequestHandler<RegisterDeviceCommand>
    {
        private readonly RegistrationContext _context;

        public RegisterDeviceCommandHandler(RegistrationContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(RegisterDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = new Device(request.Device);
            // TODO: figure out Upsert
            if (!await _context.Devices.ContainsAsync(device))
            {
                await _context.Devices.AddAsync(device);
                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}