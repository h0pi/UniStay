using FluentValidation;
using UniStay.Application.Modules.Catalog.User.Commands.Create;
using UniStay.Domain.Entities.Identity; 

namespace UniStay.Application.Modules.Users.Commands.Create;

public sealed class CreateUserCommandValidator
    : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(User.Constraints.UsernameMaxLength)
            .WithMessage($"Username can be at most {User.Constraints.UsernameMaxLength} characters long.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(User.Constraints.PasswordMinLength)
            .WithMessage($"Password must be at least {User.Constraints.PasswordMinLength} characters long.");

        RuleFor(x => x.UserRoleId)
            .GreaterThan(0).WithMessage("A valid UserRoleId is required.");
    }
}