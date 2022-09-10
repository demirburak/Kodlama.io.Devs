using Application.Features.Techs.Dtos;
using Application.Features.Techs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Techs.Commands
{
    public class DeleteTechCommand : IRequest<DeletedTechDto>
    {
        public int Id { get; set; }

    }

    public class DeleteTechCommandHandler : IRequestHandler<DeleteTechCommand, DeletedTechDto>
    {
        private readonly ITechRepository _TechRepository;
        private readonly IMapper _mapper;
        private readonly TechRules _TechRules;

        public DeleteTechCommandHandler(ITechRepository TechRepository, IMapper mapper, TechRules TechRules)
        {
            _TechRepository = TechRepository;
            _mapper = mapper;
            _TechRules = TechRules;
        }

        public async Task<DeletedTechDto> Handle(DeleteTechCommand request, CancellationToken cancellationToken)
        {
            Tech Tech = await _TechRepository.DeleteAsync(_mapper.Map<Tech>(request));
            DeletedTechDto DeletedTechDto = _mapper.Map<DeletedTechDto>(Tech);

            return DeletedTechDto;
        }
    }

}
