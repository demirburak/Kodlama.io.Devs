using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserProfiles.Commands
{
    public class DeleteUserProfileCommand : IRequest<DeletedUserProfileDto>
    {
        public int Id { get; set; }

    }

    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileDto>
    {
        private readonly IUserProfileRepository _UserProfileRepository;
        private readonly IMapper _mapper;
        private readonly UserProfileRules _UserProfileRules;

        public DeleteUserProfileCommandHandler(IUserProfileRepository UserProfileRepository, IMapper mapper, UserProfileRules UserProfileRules)
        {
            _UserProfileRepository = UserProfileRepository;
            _mapper = mapper;
            _UserProfileRules = UserProfileRules;
        }

        public async Task<DeletedUserProfileDto> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile UserProfile = await _UserProfileRepository.DeleteAsync(_mapper.Map<UserProfile>(request));
            DeletedUserProfileDto DeletedUserProfileDto = _mapper.Map<DeletedUserProfileDto>(UserProfile);

            return DeletedUserProfileDto;
        }
    }

}
