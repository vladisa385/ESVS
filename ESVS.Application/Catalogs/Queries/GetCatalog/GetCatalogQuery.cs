using System;
using MediatR;

namespace ESVS.Application.Catalogs.Queries.GetCatalog
{
    public class GetCatalogQuery:IRequest<CatalogViewModel>
    {
        public Guid Id { get; set; }
    }
}