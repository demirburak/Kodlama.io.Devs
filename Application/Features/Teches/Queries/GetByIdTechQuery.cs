using Application.Features.Techs.Dtos;
using Application.Features.Techs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Techs.Queries
{
    public class GetByIdTechQuery : IRequest<TechGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdTechQueryHandler : IRequestHandler<GetByIdTechQuery, TechGetByIdDto>
    {
        private readonly ITechRepository _TechRepository;
        private readonly IMapper _mapper;
        private readonly TechRules _TechRules;

        public GetByIdTechQueryHandler(ITechRepository TechRepository, IMapper mapper, TechRules TechRules)
        {
            _TechRepository = TechRepository;
            _mapper = mapper;
            _TechRules = TechRules;
        }

        public async Task<TechGetByIdDto> Handle(GetByIdTechQuery request, CancellationToken cancellationToken)
        {
            Tech? Tech = await _TechRepository.GetAsync(x => x.Id == request.Id);

            await _TechRules.CheckTechExist(Tech);

            TechGetByIdDto TechGetByIdDto = _mapper.Map<TechGetByIdDto>(Tech);
            return TechGetByIdDto;
        }
    }

}
