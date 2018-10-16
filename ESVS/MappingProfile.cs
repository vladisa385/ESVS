﻿using AutoMapper;
using Entities;
using ViewModel.Users;

namespace ESVS
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
       

            CreateMap<User, UserResponse>()
                 .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email))
                .ForMember(d => d.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                 .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
      



                .ForAllOtherMembers(opts => opts.Ignore());
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

         


        }
    }



}
