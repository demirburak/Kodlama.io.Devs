using FluentValidation;

namespace Application.Features.UserProfiles.Commands
{
    public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.UserId).NotNull();
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.GithubAddress).NotEmpty();
        }
    }
}
