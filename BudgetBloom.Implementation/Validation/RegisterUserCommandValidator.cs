using BudgetBloom.Implementation.Auth.Commands;
using FluentValidation;

namespace BudgetBloom.Implementation.Validation
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email is too long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[A-Z])(?=.*\d).{8,}$").WithMessage("Password must be at least 8 characters long, contain at least one uppercase letter, and one number.")
                .MaximumLength(100).WithMessage("Password is too long.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .Equal(x => x.Password).WithMessage("Password and Confirm Password must match.");
        }
    }
}
