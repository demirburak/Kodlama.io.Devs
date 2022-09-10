using FluentValidation;

namespace Application.Features.Techs.Commands
{
    public class UpdateTechCommandValidator : AbstractValidator<UpdateTechCommand>
    {
        public UpdateTechCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.ProgramLanguageId).NotNull();
            RuleFor(c => c.ProgramLanguageId).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
