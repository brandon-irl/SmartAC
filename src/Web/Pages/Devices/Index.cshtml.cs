using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Registration.Contracts;

namespace Web.Pages.Devices
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator) {
            _mediator = mediator;
        }

        public IList<IDevice> Devices {get; set;}
        
        public async Task OnGetAsync()
        {
            Devices = (await _mediator.Send(new DeviceQuery())).ToList();
        }
    }
}