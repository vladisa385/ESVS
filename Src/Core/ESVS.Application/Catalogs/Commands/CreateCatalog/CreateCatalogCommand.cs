using System;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.CreateCatalog
{
    public class CreateCatalogCommand:IRequest<Guid>,IHaveCustomMapping
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentCatalogId { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<CreateCatalogCommand, Catalog>();
    }
}