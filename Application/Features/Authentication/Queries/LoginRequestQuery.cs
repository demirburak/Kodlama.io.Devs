using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using FluentValidation.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Queries
{
    public class LoginRequestQuery : IRequest<LoginResultDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }

    public class LoginRequestQueryHandler : IRequestHandler<LoginRequestQuery, LoginResultDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationRules _authenticationRules;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public LoginRequestQueryHandler(IUserRepository userRepository, IMapper mapper, AuthenticationRules authenticationRules, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationRules = authenticationRules;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<LoginResultDto> Handle(LoginRequestQuery request, CancellationToken cancellationToken)
        {
            await _authenticationRules.CheckLoginInfos(request.Email,request.Password);

            User? user = await _userRepository.GetAsync(x => x.Email == request.Email);
            if (user == null) return new LoginResultDto();

            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) return new LoginResultDto();

            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(include: m => m.Include(c => c.OperationClaim),
                                                                                                                 expression: e => e.UserId == user.Id,
                                                                                                                 index:0 ,
                                                                                                                 size: int.MaxValue);
            List<OperationClaim> operationClaims = userOperationClaims.Items.Select(x => x.OperationClaim).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            LoginResultDto loginResultDto = _mapper.Map<LoginResultDto>(accessToken);

            return loginResultDto;

        }
    }
}
