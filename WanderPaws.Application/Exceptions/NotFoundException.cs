using WanderPaws.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WanderPaws.Application.Exceptions
{
    public class NotFoundException: Exception, ICustomException
    {
        private string _message;
        int ICustomException.StatusCode => StatusCodes.Status404NotFound;

        string ICustomException.Message
        {
            get => _message;
            set => _message = value;
        }

        public NotFoundException(int id, Type type)
            : base($"Entity of type {type.Name} with an ID {id} was not found.")
        {
            _message = Message;
        }

        public NotFoundException(string customMessage)
            : base(customMessage)
        {
            _message = customMessage;
        }
    }
}
