using FluentValidation;
using UniStay.Application.Modules.Catalog.User.Commands.Create;
using UniStay.Domain.Entities.Identity;
using UniStay.Application.Users.Commands.UpdateUser;
using UniStay.Domain.Entities;

namespace UniStay.Application.Modules.Users.Commands.Update
{
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(User.Constraints.UsernameMaxLength);

            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress();

            RuleFor(x => x.UserRoleId)
                .GreaterThan(0).WithMessage("Invalid role id.");
        }
    }

}
