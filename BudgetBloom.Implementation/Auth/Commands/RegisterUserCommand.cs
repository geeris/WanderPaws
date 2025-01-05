using BudgetBloom.Application.Exceptions;
using BudgetBloom.Application.Interfaces;
using BudgetBloom.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetBloom.Implementation.Auth.Commands
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserCommandHandler(IUserService userService) : IRequestHandler<RegisterUserCommand, Unit>
    {
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await userService.UserExistsAsync(request.Email);

            if (userExists)
            {
                throw new BadRequestException("Username already exists");
            }

            await userService.RegisterUserAsync(new User
            {
                Email = request.Email,
                Password = request.Password
            });

            return Unit.Value;
        }
    }
}
