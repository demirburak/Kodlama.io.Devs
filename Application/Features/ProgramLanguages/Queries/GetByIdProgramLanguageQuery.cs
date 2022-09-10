using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Queries
{
    public class GetByIdProgramLanguageQuery : IRequest<ProgramLanguageGetByIdDto>
    {
        public int LanguageId { get; set; }
    }

    public class GetByIdProgramLanguageQueryHandler : IRequestHandler<GetByIdProgramLanguageQuery, ProgramLanguageGetByIdDto>
    {
        private readonly IProgramLanguageRepository _programLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgramLanguageRules _programLanguageRules;

        public GetByIdProgramLanguageQueryHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageRules programLanguageRules)
        {
            _programLanguageRepository = programLanguageRepository;
            _mapper = mapper;
            _programLanguageRules = programLanguageRules;
        }

        public async Task<ProgramLanguageGetByIdDto> Handle(GetByIdProgramLanguageQuery request, CancellationToken cancellationToken)
        {
            ProgramLanguage? programLanguage = await _programLanguageRepository.GetAsync(x => x.Id == request.LanguageId);

            await _programLanguageRules.CheckLanguageExist(programLanguage);

            ProgramLanguageGetByIdDto programLanguageGetByIdDto = _mapper.Map<ProgramLanguageGetByIdDto>(programLanguage);
            return programLanguageGetByIdDto;
        }
    }

}
