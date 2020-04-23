using System;

namespace DynamoCode.Domain.Validations.NotificationPattern
{
    public class Error
    {
        public Error(string message)
        {
            Message = message;
            Cause = null;
        }

        public Error(string message, Exception cause)
        {
            Message = message;
            Cause = cause;
        }

        public string Message { get; }

        public Exception Cause { get; }
    }
}
