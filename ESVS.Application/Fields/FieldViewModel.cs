using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;
using ESVS.Domain.ValueObjects;

namespace ESVS.Application.Fields
{
   public class FieldViewModel: IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Length { get; set; }
        public bool NotNull { get; set; }
        public bool IsForeignKey { get; set; }
        public Guid TypeId { get; set; }
        public Guid CatalogId { get; set; }
        public int FieldValuesCount { get; set; }
        public ICollection<FieldValue> FieldValues { get; set; }
        public void CreateMappings(Profile configuration) =>
            configuration.CreateMap<Field, FieldViewModel>()
                .ForMember(d => d.FieldValuesCount, o => o.MapFrom(src => src.FieldValues.Count));
    }
}
