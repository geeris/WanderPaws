using BudgetBloom.Application.DTOs.Auth;
using BudgetBloom.Application.Exceptions;
using BudgetBloom.Application.Interfaces;
using MediatR;
using System.Security.Claims;

namespace BudgetBloom.Implementation.Auth.Queries
{
    public class LoginUserQuery : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserQueryHandler(IUserService userService, IPasswordHasherService passwordService, IJwtAuthManager jwtAuthManager) : IRequestHandler<LoginUserQuery, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByEmailAsync(request.Email);

            if (user == null || !passwordService.VerifyPassword(request.Password, user.Password))
            {
                throw new BadRequestException("Incorrect email or password");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, request.Email) };
            var jwtResult = jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);

            return new LoginResult
            {
                Email = user.Email,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            };
        }
    }
}
