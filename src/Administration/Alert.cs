using System;

namespace Administration
{
    public record Alert
    {
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