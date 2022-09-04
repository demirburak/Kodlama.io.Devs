using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Commands
{
    public class UpdateProgramLanguageCommand : IRequest<UpdatedProgramLanguageDto>
    {
        public int LanguageId { get; set; }

        public string LanguageName { get; set; }

    }

    public class UpdateProgramLanguageCommandHandler : IRequestHandler<UpdateProgramLanguageCommand, UpdatedProgramLanguageDto>
    {
        private readonly IProgramLanguageRepository _programLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgramLanguageRules _programLanguageRules;

        public UpdateProgramLanguageCommandHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageRules programLanguageRules)
        {
            _programLanguageRepository = programLanguageRepository;
            _mapper = mapper;
            _programLanguageRules = programLanguageRules;
        }

        public async Task<UpdatedProgramLanguageDto> Handle(UpdateProgramLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programLanguageRules.LanguageNameCannotBeDublicatedWhenUpdated(request.LanguageName, request.LanguageId);

            ProgramLanguage programLanguage = await _programLanguageRepository.UpdateAsync(_mapper.Map<ProgramLanguage>(request));
            UpdatedProgramLanguageDto UpdatedProgramLanguageDto = _mapper.Map<UpdatedProgramLanguageDto>(programLanguage);

            return UpdatedProgramLanguageDto;
        }
    }


}
