using BudgetBloom.Implementation.Auth.Queries;
using FluentValidation;

namespace BudgetBloom.Implementation.Validation
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator() { }
    }
}
