using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Registration.Contracts;

namespace Web.Pages
{
    public class DevicesModel : PageModel
    {
        private readonly IMediator _mediator;

        public DevicesModel(IMediator mediator) {
            _mediator = mediator;
        }

        public IEnumerable<IDevice> Devices {get; set;}

        public async Task OnGetAsync()
        {
            Devices = await _mediator.Send(new DeviceQuery());
        }
    }
}