using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Techs.Commands
{
    public class CreateTechCommandValidator : AbstractValidator<CreateTechCommand>
    {
        public CreateTechCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProgramLanguageId).GreaterThan(0);
        }
    }

}
