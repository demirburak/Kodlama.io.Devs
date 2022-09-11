using Application.Features.Authentication.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
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
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null) throw new AuthorizationException(AuthenticationMessages.EmailExists);
        }

        public async Task CheckLoginInfos(string? Email, string? Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                    throw new AuthorizationException(AuthenticationMessages.EmailOrPasswordCannotBeEmpty);
        }

        
    }
}
