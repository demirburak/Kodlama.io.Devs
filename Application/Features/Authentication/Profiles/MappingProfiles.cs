using Application.Features.Authentication.Dtos;
using Application.Features.Techs.Commands;
using Application.Features.Techs.Dtos;
using Application.Features.Techs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegistrationDto, User>().ReverseMap();
            CreateMap<AccessToken, LoginResultDto>()
                .ForMember(l => l.IsSuccess, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Token)))
                .ReverseMap();

        }
    }
}
