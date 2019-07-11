using System;
using AutoMapper;
using ESVS.Application.Interfaces.Mapping;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Fields.Commands.AddFieldValue
{
    public class AddFieldValueCommand:IRequest<Guid>,IHaveCustomMapping
    {
        public Guid FieldId { get; set; }
        public string Value { get; set; }
        public void CreateMappings(Profile configuration) => 
            configuration.CreateMap<AddFieldValueCommand, FieldValue>();
    }
}