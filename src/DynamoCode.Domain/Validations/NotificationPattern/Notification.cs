using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoCode.Domain.Validations.NotificationPattern
{
    public class Notification
    {
        private List<Error> _errors = new List<Error>();

        public void AddError(string message)
        {
            _errors.Add(new Error(message, null));
        }

        public void AddError(string message, Exception e)
        {
            _errors.Add(new Error(message, e));
        }

        public void AddErrors(List<Error> errors)
        {
            foreach (var _error in errors)
            {
                _errors.Add(new Error(_error.Message, _error.Cause));
            }
        }

        public bool HasErrors()
        {
            return _errors.Any();
        }

        public List<Error> Errors()
        {
            return _errors;
        }

        public List<string> ErrorMessages()
        {
            List<string> _messages = new List<string>();

            foreach (var _error in _errors)
            {
                _messages.Add(_error.Message);
            }

            return _messages;
        }

        public List<Exception> Exceptions()
        {
            List<Exception> _exceptions = new List<Exception>();

            foreach (var _error in _errors)
            {
                if (_error.Cause != null)
                {
                    _exceptions.Add(_error.Cause);
                }
            }

            return _exceptions;
        }
    }
}
