using System.Collections.Generic;

namespace WebApi.Domain
{
    public class Result
    {
        public ResultAction Action { get; set; }

        public bool Success
        {
            get { return Notifications == null || Notifications.Count == 0; }
        }

        public List<string> Notifications { get; } = new List<string>();

        public void AddNotification(string message)
        {
            Notifications.Add(message);
        }
    }
}
