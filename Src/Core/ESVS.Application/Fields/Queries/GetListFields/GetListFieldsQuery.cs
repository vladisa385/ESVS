using System;
using System.Collections.Generic;
using System.Text;
using ESVS.Application.Extensions;
using ESVS.Application.Infrastructure.Query;
using MediatR;

namespace ESVS.Application.Fields.Queries.GetListFields
{
    public class GetListFieldsQuery:IRequest<ListResponse<FieldViewModel>>,IListQuery
    {
        public ListOptions Options { get; set; }

        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public RangeFilter<int> Length { get; set; }

        public RangeFilter<int> FieldValues { get; set; }

        public bool? NotNull { get; set; }

        public bool? IsForeignKey { get; set; }

        public Guid? TypeId { get; set; }

        public Guid? CatalogId { get; set; }
    }
}
