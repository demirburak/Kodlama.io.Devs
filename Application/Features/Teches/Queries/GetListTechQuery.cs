using Application.Features.Techs.Dtos;
using Application.Features.Techs.Models;
using Application.Features.Techs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Techs.Queries
{
    public class GetListTechQuery : IRequest<TechListModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListTechQueryHandler : IRequestHandler<GetListTechQuery, TechListModel>
    {
        private readonly ITechRepository _TechRepsitory;
        private readonly IMapper _mapper;

        public GetListTechQueryHandler(ITechRepository TechRepsitory, IMapper mapper)
        {
            _TechRepsitory = TechRepsitory;
            _mapper = mapper;
        }

        public async Task<TechListModel> Handle(GetListTechQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Tech> pls = await _TechRepsitory.GetListAsync(include: m => m.Include(c => c.ProgramLanguage),
                                                                    index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize);
            TechListModel TechListModel = _mapper.Map<TechListModel>(pls);

            return TechListModel;
        }
    }



}
