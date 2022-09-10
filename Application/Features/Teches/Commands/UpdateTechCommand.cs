using Application.Features.Techs.Dtos;
using Application.Features.Techs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Techs.Commands
{
    public class UpdateTechCommand : IRequest<UpdatedTechDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProgramLanguageId { get; set; }

    }

    public class UpdateTechCommandHandler : IRequestHandler<UpdateTechCommand, UpdatedTechDto>
    {
        private readonly ITechRepository _TechRepository;
        private readonly IMapper _mapper;
        private readonly TechRules _TechRules;

        public UpdateTechCommandHandler(ITechRepository TechRepository, IMapper mapper, TechRules TechRules)
        {
            _TechRepository = TechRepository;
            _mapper = mapper;
            _TechRules = TechRules;
        }

        public async Task<UpdatedTechDto> Handle(UpdateTechCommand request, CancellationToken cancellationToken)
        {
            await _TechRules.TechNameCannotBeDublicatedWhenUpdated(request.Name, request.Id);
            await _TechRules.CheckProgramLanguageExistWhenTechInsertedOrUpdated(request.ProgramLanguageId);

            Tech Tech = await _TechRepository.UpdateAsync(_mapper.Map<Tech>(request));
            UpdatedTechDto UpdatedTechDto = _mapper.Map<UpdatedTechDto>(Tech);

            return UpdatedTechDto;
        }
    }


}
