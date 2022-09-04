using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands
{
    public class DeleteProgramLanguageCommandValidator : AbstractValidator<DeleteProgramLanguageCommand>
    {
        public DeleteProgramLanguageCommandValidator()
        {
            RuleFor(c => c.LanguageId).NotNull();
            RuleFor(c => c.LanguageId).GreaterThan(0);
            //RuleFor(c => c.ProgramLanguageName).NotEmpty();
        }
    }
}
