using System.Collections.Generic;
using DynamoCode.Domain.Exceptions;
using DynamoCode.Domain.Validations.NotificationPattern;

namespace DynamoCode.Domain.Validations
{
    public abstract class ValidatorBase<TEntity> where TEntity: class
    {
        private Notification _notification = new Notification();
        private List<IValidator> _validators = new List<IValidator>();

        public void AddValidator(IValidator validator)
        {
            _validators.Add(validator);
        }

        public abstract void RegisterValidators(TEntity entity);

        public virtual void Validate(TEntity entity)
        {
            RegisterValidators(entity);

            foreach (var validator in _validators)
            {
                _notification.AddErrors(validator.Validate());
            }

            if (_notification.HasErrors())
            {
                throw new NotificationException(_notification);
            }
        }
    }
}
