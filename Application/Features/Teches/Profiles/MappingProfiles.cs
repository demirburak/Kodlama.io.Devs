using Application.Features.Techs.Commands;
using Application.Features.Techs.Dtos;
using Application.Features.Techs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Techs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tech, RegisterUserDto>().ReverseMap();
            CreateMap<Tech, CreateTechCommand>().ReverseMap();

            CreateMap<Tech, UpdatedTechDto>().ReverseMap();
            CreateMap<Tech, UpdateTechCommand>().ReverseMap();

            CreateMap<Tech, DeletedTechDto>().ReverseMap();
            CreateMap<Tech, DeleteTechCommand>().ReverseMap();

            CreateMap<IPaginate<Tech>, TechListModel>().ReverseMap();
            CreateMap<Tech, TechGetByIdDto>().ReverseMap();
            CreateMap<Tech, TechGetListDto>().ReverseMap();

            CreateMap<Tech, TechGetListDto>().ForMember(t => t.LangugeName, opt => opt.MapFrom(t => t.ProgramLanguage.LanguageName)).ReverseMap();


        }
    }
}
