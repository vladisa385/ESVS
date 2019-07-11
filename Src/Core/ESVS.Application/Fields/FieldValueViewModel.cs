using System;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;

namespace ESVS.Application.Fields
{
    public class FieldValueViewModel:IHaveCustomMapping
    {
        public DateTime Date { get; set; }
        public string Value { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<FieldValue, FieldValueViewModel>();
    }
}