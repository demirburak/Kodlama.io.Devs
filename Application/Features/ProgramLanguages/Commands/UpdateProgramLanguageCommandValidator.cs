using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands
{
    public class UpdateProgramLanguageCommandValidator : AbstractValidator<UpdateProgramLanguageCommand>
    {
        public UpdateProgramLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.LanguageName).NotEmpty();
        }
    }
}
