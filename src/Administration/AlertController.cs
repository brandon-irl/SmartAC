using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Alert>> Get()
        {
            return await _mediator.Send(new AlertQuery());
        }

        [HttpPost]
        public async Task<IActionResult> Resolve(int alertId)
        {
            await _mediator.Send(new ResolveAlertCommand(alertId));
            return NoContent();
        }
    }
}