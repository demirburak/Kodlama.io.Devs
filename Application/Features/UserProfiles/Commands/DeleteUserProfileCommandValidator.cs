using FluentValidation;

namespace Application.Features.UserProfiles.Commands
{
    public class DeleteUserProfileCommandValidator : AbstractValidator<DeleteUserProfileCommand>
    {
        public DeleteUserProfileCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Id).GreaterThan(0);
            //RuleFor(c => c.UserProfileName).NotEmpty();
        }
    }
}
