using Application.Features.Authentication.Constants;
using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands
{
    public class RegisterUserCommand : IRequest<RegistrationDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationRules _registerUserRules;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, AuthenticationRules registerUserRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _registerUserRules = registerUserRules;
        }

        public async Task<RegistrationDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //Rules
            await _registerUserRules.CheckEmailExists(request.Email);

            //Register
            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new(0, request.FirstName, request.LastName, request.Email, passwordSalt, passwordHash, true, Core.Security.Enums.AuthenticatorType.None);
            User? createdUser = await _userRepository.AddAsync(user);

            if (createdUser == null) throw new BusinessException(AuthenticationMessages.ThereIsAnErrorWhenUserCreating);

            //Return
            RegistrationDto registrationDto = _mapper.Map<RegistrationDto>(createdUser);
            return registrationDto;
        }

    }
}
