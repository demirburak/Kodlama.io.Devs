using Application.Features.ProgramLanguages.Commands;
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramLanguage, CreatedProgramLanguageDto>().ReverseMap();
            CreateMap<ProgramLanguage, CreateProgramLanguageCommand>().ReverseMap();

            CreateMap<ProgramLanguage, UpdatedProgramLanguageDto>().ReverseMap();
            CreateMap<ProgramLanguage, UpdateProgramLanguageCommand>().ReverseMap();

            CreateMap<ProgramLanguage, DeletedProgramLanguageDto>().ReverseMap();
            CreateMap<ProgramLanguage, DeleteProgramLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<ProgramLanguage>, ProgramLanguageListModel>().ReverseMap();
            CreateMap<ProgramLanguage, ProgramLanguageGetByIdDto>().ReverseMap();
            CreateMap<ProgramLanguage, ProgramLanguageGetListDto>().ReverseMap();


        }
    }
}
