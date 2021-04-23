using System;
using System.Collections.Generic;
using MediatR;

namespace Administration.Contracts
{
    public class AlertQuery : IRequest<IEnumerable<IAlert>>
    {
        public IEnumerable<string> SerialNumbers { get; init; }
    }
}