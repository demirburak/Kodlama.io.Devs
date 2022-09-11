using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramLanguages.Commands
{
    public class DeleteProgramLanguageCommand : IRequest<DeletedProgramLanguageDto>
    {
        public int Id { get; set; }

    }

    public class DeleteProgramLanguageCommandHandler : IRequestHandler<DeleteProgramLanguageCommand, DeletedProgramLanguageDto>
    {
        private readonly IProgramLanguageRepository _programLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgramLanguageRules _programLanguageRules;

        public DeleteProgramLanguageCommandHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageRules programLanguageRules)
        {
            _programLanguageRepository = programLanguageRepository;
            _mapper = mapper;
            _programLanguageRules = programLanguageRules;
        }

        public async Task<DeletedProgramLanguageDto> Handle(DeleteProgramLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgramLanguage programLanguage = await _programLanguageRepository.DeleteAsync(_mapper.Map<ProgramLanguage>(request));
            DeletedProgramLanguageDto DeletedProgramLanguageDto = _mapper.Map<DeletedProgramLanguageDto>(programLanguage);

            return DeletedProgramLanguageDto;
        }
    }

}
