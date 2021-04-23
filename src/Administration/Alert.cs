using System;
using Administration.Contracts;

namespace Administration
{
    public record Alert : IAlert
    {
        public Alert(){}
        public Alert(IAlert alert)
        {
            Id = alert.Id;
            DeviceSerialNumber = alert.DeviceSerialNumber;
            Message = alert.Message;
            Time = alert.Time;
            Resolved = alert.Resolved;
            UserResolved = alert.UserResolved;
        }

        public int Id { get; init; }
        public string DeviceSerialNumber { get; init; }
        public string Message { get; init; }
        public DateTime Time { get; init; }
        public bool Resolved { get; private set; }
        public string UserResolved { get; private set; }

        public void ResolveAlert(string userName)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            Resolved = true;
            UserResolved = userName;
        }
    }
}