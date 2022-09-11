using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Models;
using Application.Features.UserProfiles.Rules;
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

namespace Application.Features.UserProfiles.Queries
{
    public class GetListUserProfileQuery : IRequest<UserProfileListModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListUserProfileQueryHandler : IRequestHandler<GetListUserProfileQuery, UserProfileListModel>
    {
        private readonly IUserProfileRepository _UserProfileRepsitory;
        private readonly IMapper _mapper;

        public GetListUserProfileQueryHandler(IUserProfileRepository UserProfileRepsitory, IMapper mapper)
        {
            _UserProfileRepsitory = UserProfileRepsitory;
            _mapper = mapper;
        }

        public async Task<UserProfileListModel> Handle(GetListUserProfileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserProfile> ups = await _UserProfileRepsitory.GetListAsync(include: m=>m.Include(c=>c.User),
                                                                                  index: request.PageRequest.Page,
                                                                                  size: request.PageRequest.PageSize);
            UserProfileListModel UserProfileListModel = _mapper.Map<UserProfileListModel>(ups);

            return UserProfileListModel;
        }
    }

   

}
