using Application.Features.Authentication.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Rules
{
    public class AuthenticationRules
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CheckEmailExists(string email)
        {
            var temp = await _userRepository.GetAsync(x => x.Email == email);
            if (temp != null) throw new BusinessException(AuthenticationMessages.EmailExists);
        }

        
    }
}
