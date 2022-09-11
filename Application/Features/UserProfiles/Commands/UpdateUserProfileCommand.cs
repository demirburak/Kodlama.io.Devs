using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Commands
{
    public class UpdateUserProfileCommand : IRequest<UpdatedUserProfileDto>
    {
        public int Id { get; set; }

        public string GithubAddress { get; set; }

        public int UserId { get; set; }

    }

    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileDto>
    {
        private readonly IUserProfileRepository _UserProfileRepository;
        private readonly IMapper _mapper;
        private readonly UserProfileRules _UserProfileRules;

        public UpdateUserProfileCommandHandler(IUserProfileRepository UserProfileRepository, IMapper mapper, UserProfileRules UserProfileRules)
        {
            _UserProfileRepository = UserProfileRepository;
            _mapper = mapper;
            _UserProfileRules = UserProfileRules;
        }

        public async Task<UpdatedUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            await _UserProfileRules.AddressCannotBeDublicatedWhenUpdated(request.GithubAddress, request.Id);
            await _UserProfileRules.CheckUserExists(request.UserId);

            UserProfile UserProfile = await _UserProfileRepository.UpdateAsync(_mapper.Map<UserProfile>(request));
            UpdatedUserProfileDto UpdatedUserProfileDto = _mapper.Map<UpdatedUserProfileDto>(UserProfile);

            return UpdatedUserProfileDto;
        }
    }


}
