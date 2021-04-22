using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration
{
    [Route("[controller]/[action]")]
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AlertController : ControllerBase
    {
        private readonly IMediator _mediator;

        //Temporary username until we stand up a permanent user database
        private const string _alertResolver = "Joe Biden";

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
        public async Task<IActionResult> Resolve([FromBody] int alertId)
        {
            await _mediator.Send(new ResolveAlertCommand(alertId, _alertResolver));
            return NoContent();
        }
    }
}