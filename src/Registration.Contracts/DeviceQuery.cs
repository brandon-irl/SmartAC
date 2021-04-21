using System;
using System.Collections.Generic;
using MediatR;

namespace Registration.Contracts
{
    public class DeviceQuery : IRequest<IEnumerable<IDevice>>
    {
        public IEnumerable<string> SerialNumbers { get; init; }
    }
}
