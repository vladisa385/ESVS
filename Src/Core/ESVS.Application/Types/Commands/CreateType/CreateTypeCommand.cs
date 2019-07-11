using System;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using MediatR;
using Type = ESVS.Domain.Entities.Type;

namespace ESVS.Application.Types.Commands.CreateType
{
    public class CreateTypeCommand:IRequest<Guid>,IHaveCustomMapping
    {
         public string Name { get; set; }
         public void CreateMappings(Profile configuration) => 
             configuration.CreateMap<CreateTypeCommand, Type>();
    }
}