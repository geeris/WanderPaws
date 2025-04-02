using WanderPaws.Implementation.Auth.Queries;
using FluentValidation;

namespace WanderPaws.Implementation.Validation
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator() { }
    }
}
