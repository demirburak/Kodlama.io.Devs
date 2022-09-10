using Application.Features.Techs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic
{
    public class GetListTechByDynamicQuery : IRequest<TechListModel>
    {
        public Dynamic Dynamic { get; set; }

        public PageRequest PageRequest { get; set; }

        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListTechByDynamicQuery, TechListModel>
        {
            private readonly IMapper _mapper;
            private readonly ITechRepository _techRepository;

            public GetListModelByDynamicQueryHandler(IMapper mapper, ITechRepository techRepository)
            {
                _mapper = mapper;
                _techRepository = techRepository;
            }

            public async Task<TechListModel> Handle(GetListTechByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Tech> teches = await _techRepository.GetListByDynamicAsync
                                                   (dynamic: request.Dynamic,
                                                    include: t => t.Include(c => c.ProgramLanguage),
                                                    index: request.PageRequest.Page,
                                                    size: request.PageRequest.PageSize);

                TechListModel techModels = _mapper.Map<TechListModel>(teches);
                return techModels;
            }
        }
    }
}
