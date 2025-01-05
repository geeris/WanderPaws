using BudgetBloom.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BudgetBloom.Application.Exceptions
{
    public class BadRequestException(string customMessage) : Exception(customMessage), ICustomException
    {
        private string _message = customMessage;

        public int StatusCode => StatusCodes.Status400BadRequest;

        public new string Message
        {
            get => _message;
            set => _message = value;
        }
    }
}
