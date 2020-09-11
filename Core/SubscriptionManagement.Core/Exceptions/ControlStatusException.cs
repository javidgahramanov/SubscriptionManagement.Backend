using System;

namespace SubscriptionManagement.Core.Exceptions
{
    [Serializable]
    public class ControlStatusException : Exception
    {
        public ControlStatusException()
        {
        }

        public ControlStatusException(string message) : base(message)
        {
        }

        public ControlStatusException(string message, string innerMessage)
            : base(message, new ControlStatusException(innerMessage))
        {
        }
    }
}