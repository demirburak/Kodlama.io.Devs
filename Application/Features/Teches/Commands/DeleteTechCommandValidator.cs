using FluentValidation;

namespace Application.Features.Techs.Commands
{
    public class DeleteTechCommandValidator : AbstractValidator<DeleteTechCommand>
    {
        public DeleteTechCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Id).GreaterThan(0);
            //RuleFor(c => c.TechName).NotEmpty();
        }
    }
}
