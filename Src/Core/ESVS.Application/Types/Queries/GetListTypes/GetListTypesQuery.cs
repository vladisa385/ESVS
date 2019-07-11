using System;
using ESVS.Application.Infrastructure.Query;
using MediatR;

namespace ESVS.Application.Types.Queries.GetListTypes
{
    public class GetListTypesQuery:IRequest<ListResponse<TypeViewModel>>,IListQuery
    {
        public ListOptions Options { get; set; } = new ListOptions();

        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}