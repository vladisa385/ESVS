using System;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommand:IRequest<Guid>,IHaveCustomMapping
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Length { get; set; }
        public bool NotNull { get; set; }
        public bool IsForeignKey { get; set; }
        public Guid TypeId { get; set; }
        public Guid CatalogId { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<CreateFieldCommand, Field>();
    }
}