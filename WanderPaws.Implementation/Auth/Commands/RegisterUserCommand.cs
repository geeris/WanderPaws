using WanderPaws.Application.Exceptions;
using WanderPaws.Application.Interfaces;
using WanderPaws.Domain.Entities;
using MediatR;

namespace WanderPaws.Implementation.Auth.Commands
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
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
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password
            });

            return Unit.Value;
        }
    }
}
