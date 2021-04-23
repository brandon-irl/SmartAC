using System;

namespace Administration.Contracts
{
    public interface IAlert
    {
        public int Id { get; init; }
        public string DeviceSerialNumber { get; init; }
        public string Message { get; init; }
        public DateTime Time { get; init; }
        public bool Resolved { get; }
        public string UserResolved { get; }
        public void ResolveAlert(string userName);
    }
}
