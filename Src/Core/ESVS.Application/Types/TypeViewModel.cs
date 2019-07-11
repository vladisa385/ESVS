using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using Type = ESVS.Domain.Entities.Type;
namespace ESVS.Application.Types
{
    public class TypeViewModel: IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<Type, TypeViewModel>();
    }
}
