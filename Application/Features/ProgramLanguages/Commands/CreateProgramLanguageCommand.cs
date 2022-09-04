using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Commands
{
    public class CreateProgramLanguageCommand : IRequest<CreatedProgramLanguageDto>
    {
        public string LanguageName { get; set; }
        
    }

    public class CreateProgramLanguageCommandHandler : IRequestHandler<CreateProgramLanguageCommand, CreatedProgramLanguageDto>
    {
        private readonly IProgramLanguageRepository _programLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgramLanguageRules _programLanguageRules;

        public CreateProgramLanguageCommandHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageRules programLanguageRules)
        {
            _programLanguageRepository = programLanguageRepository;
            _mapper = mapper;
            _programLanguageRules = programLanguageRules;
        }

        public async Task<CreatedProgramLanguageDto> Handle(CreateProgramLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programLanguageRules.LanguageNameCannotBeDublicatedWhenInserted(request.LanguageName);

            ProgramLanguage programLanguage =  await _programLanguageRepository.AddAsync(_mapper.Map<ProgramLanguage>(request));
            CreatedProgramLanguageDto createdProgramLanguageDto = _mapper.Map<CreatedProgramLanguageDto>(programLanguage);

            return createdProgramLanguageDto;
        }
    }

    


}
