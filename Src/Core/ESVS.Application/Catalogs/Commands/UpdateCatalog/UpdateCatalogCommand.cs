using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ESVS.Application.Catalogs.Commands.CreateCatalog;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.UpdateCatalog
{
    public class UpdateCatalogCommand:IRequest<Guid>,IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

         public Guid? ParentCatalogId { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<UpdateCatalogCommand, Catalog>();
    }
}
