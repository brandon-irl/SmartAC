using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registration.Authentication;

namespace Registration
{
    [Route("register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private AuthenticationService _authService;

        public RegistrationController(IMediator mediator, AuthenticationService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Post(Registration reg)
        {
            try
            {
                string token = await _authService.Authenticate(reg.Credentials);
                await _mediator.Send(new RegisterDeviceCommand(new Device { SerialNumber = reg.Credentials.SerialNumber, FirmwareVersion = reg.FirmwareVersion }));
                // TODO: what is the client expecting? If failure, will they try again?
                return Ok(token);
            }
            catch (InvalidCastException)
            {
                return Unauthorized();
            }

        }
    }
}