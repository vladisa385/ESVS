using System;
using ESVS.Application.Catalogs.Queries.GetCatalog;
using ESVS.Application.Extensions;
using ESVS.Application.Infrastructure.Query;
using MediatR;

namespace ESVS.Application.Catalogs.Queries.GetListCatalogs
{
    public class GetListCatalogsQuery:IRequest<ListResponse<CatalogViewModel>>,IListQuery
    {
        public ListOptions Options { get; set; } = new ListOptions();
        public Guid? Id { get; set; }
        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentId { get; set; }

        public RangeFilter<int> ChildCatalogs { get; set; }

        public RangeFilter<int> Fields { get; set; }
    }
}