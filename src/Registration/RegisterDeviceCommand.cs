using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            _context.Devices.Add(new Device(request.Device));
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}