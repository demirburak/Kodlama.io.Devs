using Application.Features.UserProfiles.Commands;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, CreatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();

            CreateMap<UserProfile, UpdatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();

            CreateMap<UserProfile, DeletedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();

            CreateMap<IPaginate<UserProfile>, UserProfileListModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileGetByIdDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileGetListDto>().ForMember(f=>f.Email,opt=>opt.MapFrom(c=>c.User.Email)).ReverseMap();


        }
    }
}
