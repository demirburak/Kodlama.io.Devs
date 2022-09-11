using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Queries
{
    public class GetByIdUserProfileQuery : IRequest<UserProfileGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, UserProfileGetByIdDto>
    {
        private readonly IUserProfileRepository _UserProfileRepository;
        private readonly IMapper _mapper;
        private readonly UserProfileRules _UserProfileRules;

        public GetByIdUserProfileQueryHandler(IUserProfileRepository UserProfileRepository, IMapper mapper, UserProfileRules UserProfileRules)
        {
            _UserProfileRepository = UserProfileRepository;
            _mapper = mapper;
            _UserProfileRules = UserProfileRules;
        }

        public async Task<UserProfileGetByIdDto> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
        {
            UserProfile? UserProfile = await _UserProfileRepository.GetAsync(x => x.Id == request.Id);

            await _UserProfileRules.CheckUserProfileExist(UserProfile);

            UserProfileGetByIdDto UserProfileGetByIdDto = _mapper.Map<UserProfileGetByIdDto>(UserProfile);
            return UserProfileGetByIdDto;
        }
    }

}
