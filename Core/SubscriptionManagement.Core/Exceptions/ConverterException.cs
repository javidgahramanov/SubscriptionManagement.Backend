using System;

namespace SubscriptionManagement.Core.Exceptions
{
    [Serializable]
    public class ConverterException : Exception
    {
        public ConverterException()
        {
        }

        public ConverterException(string message) : base(message)
        {
        }
    }
}