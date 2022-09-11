using Application.Features.UserProfiles.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Rules
{
    public class UserProfileRules
    {
        private readonly IUserProfileRepository _UserProfileRepository;
        private readonly IUserRepository _userRepository;

        public UserProfileRules(IUserProfileRepository UserProfileRepository, IUserRepository userRepository)
        {
            _UserProfileRepository = UserProfileRepository;
            _userRepository = userRepository;
        }

        public async Task AddressCannotBeDublicatedWhenInserted(string name)
        {
            IPaginate<UserProfile> results = await _UserProfileRepository.GetListAsync(x => x.GithubAddress == name);
            if (results.Count != 0) throw new BusinessException(UserProfileMessages.NameExists);
        }

        public async Task AddressCannotBeEmpty(string? name)
        {
            if (string.IsNullOrEmpty(name)) throw new BusinessException(UserProfileMessages.NameEmpty);
        }

        public async Task AddressCannotBeDublicatedWhenUpdated(string name, int id)
        {
            IPaginate<UserProfile> results = await _UserProfileRepository.GetListAsync(x => x.GithubAddress == name && x.Id != id);
            if (results.Count != 0) throw new BusinessException(UserProfileMessages.NameExists);
        }

        public async Task CheckUserExists(int userid)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == userid);
            if (user == null) throw new BusinessException(UserProfileMessages.UserCannotFound);
        }

        public async Task CheckUserProfileExist(UserProfile? userProfile)
        {
            if (userProfile == null) throw new BusinessException(UserProfileMessages.UserCannotFound);
        }
    }
}
