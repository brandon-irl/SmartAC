using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Registration
{
    [Route("register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Post(Device newDevice)
        {
            //TODO: validation and authentication
            await _mediator.Send(new RegisterDeviceCommand(newDevice));
            // TODO: what is the client expecting? If failure, will they try again?
            return NoContent();
        }
    }
}