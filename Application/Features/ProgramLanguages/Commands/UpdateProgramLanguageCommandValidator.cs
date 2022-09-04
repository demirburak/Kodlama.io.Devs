using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands
{
    public class UpdateProgramLanguageCommandValidator : AbstractValidator<UpdateProgramLanguageCommand>
    {
        public UpdateProgramLanguageCommandValidator()
        {
            RuleFor(c => c.LanguageId).NotNull();
            RuleFor(c => c.LanguageId).GreaterThan(0);
            RuleFor(c => c.LanguageName).NotEmpty();
        }
    }
}
