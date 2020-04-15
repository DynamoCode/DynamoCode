using DynamoCode.Domain.Validations.NotificationPattern;
using System.Collections.Generic;

namespace DynamoCode.Domain.Validations
{
    public interface IValidator
    {
        List<Error> Validate();
    }
}
