using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Roles;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using ViewModel.Roles;

namespace DataAccess.DbImplementation.Roles
{
    public class RolesListQuery : IRolesListQuery
    {
        private readonly AppDbContext _context;
        public RolesListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<RoleResponse> ApplyFilter(IQueryable<RoleResponse> query, RoleFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }

            return query;
        }

        public async Task<ListResponse<RoleResponse>> RunAsync(RoleFilter filter, ListOptions options)
        {
            IQueryable<RoleResponse> query = _context.Roles
                .ProjectTo<RoleResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<RoleResponse>
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
