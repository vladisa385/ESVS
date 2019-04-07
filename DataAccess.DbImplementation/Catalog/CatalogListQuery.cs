﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Catalog;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using ViewModel.Catalogs;

namespace DataAccess.DbImplementation.Catalog
{
    public class CatalogListQuery : ICatalogListQuery
    {
        private readonly AppDbContext _context;

        public CatalogListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;
        }

        private IQueryable<CatalogResponse> ApplyFilter(IQueryable<CatalogResponse> query, CatalogFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }
            if (filter.Type != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }
            if (filter.Text != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }
            if (filter.ParentId != null)
            {
                query = query.Where(p => p.ParentId == filter.ParentId);
            }
            return query;
        }

        public async Task<ListResponse<CatalogResponse>> RunAsync(CatalogFilter filter, ListOptions options)
        {
            IQueryable<CatalogResponse> query = _context.Catalogs.Include("Catalogs")
                .ProjectTo<CatalogResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CatalogResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }
    }
}
