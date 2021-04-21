using System;
using System.Collections.Generic;
using MediatR;

namespace SensorReadingDataHub.Contracts
{
    public class DeviceReadingQuery : IRequest<IEnumerable<ISensorReading>> 
    { 
        public IList<string> SerialNumbers {get; init;}
    }
}
