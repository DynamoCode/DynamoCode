using DynamoCode.Domain.Validations.NotificationPattern;
using System;

namespace DynamoCode.Domain.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(Notification notification)
        {
            Notification = notification;
        }

        public Notification Notification { get; }
    }
}
