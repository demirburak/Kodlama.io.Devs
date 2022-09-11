using FluentValidation;

namespace Application.Features.ProgramLanguages.Commands
{
    public class DeleteProgramLanguageCommandValidator : AbstractValidator<DeleteProgramLanguageCommand>
    {
        public DeleteProgramLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Id).GreaterThan(0);
            //RuleFor(c => c.ProgramLanguageName).NotEmpty();
        }
    }
}
