using System;
using MediatR;

namespace ESVS.Application.Fields.Queries.GetField
{
    public class GetFieldQuery : IRequest<FieldViewModel>
    {
        public Guid Id { get; set; }
    }
}