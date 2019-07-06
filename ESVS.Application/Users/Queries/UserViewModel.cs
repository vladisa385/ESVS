using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;

namespace ESVS.Application.Users.Queries
{
    public class UserViewModel: IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForAllOtherMembers(opts => opts.Ignore());
    }
}
