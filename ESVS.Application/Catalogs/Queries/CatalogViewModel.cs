using System;
using System.Collections.Generic;
using AutoMapper;
using ESVS.Application.Fields;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;

namespace ESVS.Application.Catalogs.Queries
{
    public class CatalogViewModel: IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCatalogId { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public int ChildCatalogsCount { get; set; }
        public ICollection<FieldViewModel> Fields { get; set; }
        public ICollection<CatalogViewModel> ChildCatalogs { get; set; }
        public int FieldsCount { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Catalog, CatalogViewModel>()
                .ForMember(viewModel=>viewModel.ChildCatalogsCount,
                    opt => opt.MapFrom(p => p.ChildCatalogs.Count))
                .ForMember(viewModel => viewModel.FieldsCount,
                    opt => opt.MapFrom(p => p.Fields.Count));
        }
    }
}
