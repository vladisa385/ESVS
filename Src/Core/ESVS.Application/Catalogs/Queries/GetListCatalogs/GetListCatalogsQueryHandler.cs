using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using ESVS.Application.Catalogs.Queries.GetCatalog;
using ESVS.Application.Infrastructure.Query;
using ESVS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ESVS.Application.Catalogs.Queries.GetListCatalogs
{
    public class GetListCatalogsQueryHandler:BaseListQueryHandler<GetListCatalogsQuery,CatalogViewModel>
    {
        private readonly IESVSDbContext _context;

        public GetListCatalogsQueryHandler(IESVSDbContext context)
        {
            _context = context;
        }

        protected override IQueryable<CatalogViewModel> ApplyFilter(IQueryable<CatalogViewModel> query, GetListCatalogsQuery filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);

            if (filter.Name != null)
                query = query.Where(p => p.Name.Contains(filter.Name));

            if (filter.Type != null)
                query = query.Where(p => p.Type.Contains(filter.Type));

            if (filter.Text != null)
                query = query.Where(p => p.Text.Contains(filter.Text));

            if (filter.ParentId != null)
                query = query.Where(p => p.ParentCatalogId == filter.ParentId);

            if (filter.ChildCatalogs != null)
            {
                if (filter.ChildCatalogs.From != null)
                    query = query.Where(p => p.ChildCatalogsCount >= filter.ChildCatalogs.From);

                if (filter.ChildCatalogs.To != null)
                    query = query.Where(p => p.ChildCatalogsCount <= filter.ChildCatalogs.To);
            }
            if (filter.Fields != null)
            {
                if (filter.Fields.From != null)
                    query = query.Where(p => p.FieldsCount >= filter.Fields.From);

                if (filter.Fields.To != null)
                    query = query.Where(p => p.FieldsCount <= filter.Fields.To);
            }
            return query;
        }

        protected override IQueryable<CatalogViewModel> GetQuery() => 
            _context.Catalogs.ProjectTo<CatalogViewModel>();
    }
}
