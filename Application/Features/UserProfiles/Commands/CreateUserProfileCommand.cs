using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Commands
{
    public class CreateUserProfileCommand : IRequest<CreatedUserProfileDto>
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        
    }

    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileDto>
    {
        private readonly IUserProfileRepository _UserProfileRepository;
        private readonly IMapper _mapper;
        private readonly UserProfileRules _UserProfileRules;

        public CreateUserProfileCommandHandler(IUserProfileRepository UserProfileRepository, IMapper mapper, UserProfileRules UserProfileRules)
        {
            _UserProfileRepository = UserProfileRepository;
            _mapper = mapper;
            _UserProfileRules = UserProfileRules;
        }

        public async Task<CreatedUserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            await _UserProfileRules.AddressCannotBeDublicatedWhenInserted(request.GithubAddress);
            await _UserProfileRules.CheckUserExists(request.UserId);

            UserProfile UserProfile =  await _UserProfileRepository.AddAsync(_mapper.Map<UserProfile>(request));
            CreatedUserProfileDto createdUserProfileDto = _mapper.Map<CreatedUserProfileDto>(UserProfile);

            return createdUserProfileDto;
        }
    }

    


}
