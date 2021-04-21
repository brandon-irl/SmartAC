using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Registration.Contracts;
using SensorReadingDataHub.Contracts;

namespace Web.Pages.Devices
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IDevice Device { get; set; }
        public IList<ISensorReading> SensorReadings { get; set; }

        public async Task<IActionResult> OnGetAsync(string serialNumber)
        {
            if(string.IsNullOrEmpty(serialNumber))
                return NotFound();

            Device = (await _mediator.Send(new DeviceQuery { SerialNumbers = new List<string> { serialNumber } })).FirstOrDefault();

            if(Device == null)
                return NotFound();
                
            SensorReadings = (await _mediator.Send(new DeviceReadingQuery{SerialNumbers = new List<string> { serialNumber }})).ToList();
            return Page();
        }
    }
}