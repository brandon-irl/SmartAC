using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensorReadingDataHub.Contracts;

namespace SensorReadingDataHub.Controllers
{

    [Route("sensors")]
    [ApiController]
    public class SensorReadingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SensorReadingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes("application/json")]
        public async Task<IActionResult> Post(DeviceReading data)
        {
            await _mediator.Publish(new ReadingReported { Readings = data.SensorReadings.Select(_ => _ with { DeviceSerialNumber = data.SerialNumber }) });
            return NoContent();
        }
    }
}