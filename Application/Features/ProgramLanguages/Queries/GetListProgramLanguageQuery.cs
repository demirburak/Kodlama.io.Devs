using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Models;
using Application.Features.ProgramLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Queries
{
    public class GetListProgramLanguageQuery : IRequest<ProgramLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListProgramLanguageQueryHandler : IRequestHandler<GetListProgramLanguageQuery, ProgramLanguageListModel>
    {
        private readonly IProgramLanguageRepository _programLanguageRepsitory;
        private readonly IMapper _mapper;

        public GetListProgramLanguageQueryHandler(IProgramLanguageRepository programLanguageRepsitory, IMapper mapper)
        {
            _programLanguageRepsitory = programLanguageRepsitory;
            _mapper = mapper;
        }

        public async Task<ProgramLanguageListModel> Handle(GetListProgramLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgramLanguage> pls = await _programLanguageRepsitory.GetListAsync(index: request.PageRequest.Page,
                                                                                          size: request.PageRequest.PageSize);
            ProgramLanguageListModel programLanguageListModel = _mapper.Map<ProgramLanguageListModel>(pls);

            return programLanguageListModel;
        }
    }

   

}
