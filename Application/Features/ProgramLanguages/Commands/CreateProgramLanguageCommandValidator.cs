using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Commands
{
    public class CreateProgramLanguageCommandValidator : AbstractValidator<CreateProgramLanguageCommand>
    {
        public CreateProgramLanguageCommandValidator()
        {
            RuleFor(c => c.LanguageName).NotEmpty();
        }
    }

}
