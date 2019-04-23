using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Users;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using ViewModel.Users;

namespace DataAccess.DbImplementation.Users
{
    public class UsersListQuery : IUsersListQuery
    {
        private readonly AppDbContext _context;
        public UsersListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<UserResponse> ApplyFilter(IQueryable<UserResponse> query, UserFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.FirstName != null)
            {
                query = query.Where(p => p.FirstName.Contains(filter.FirstName));
            }
            if (filter.LastName != null)
            {
                query = query.Where(p => p.LastName.Contains(filter.LastName));
            }


            if (filter.Email != null)
            {
                query = query.Where(p => p.Email.Contains(filter.Email));
            }



            if (filter.Gender != null)
            {
                query = query.Where(p => p.Gender == filter.Gender);
            }
            return query;
        }

        public async Task<ListResponse<UserResponse>> RunAsync(UserFilter filter, ListOptions options)
        {
            IQueryable<UserResponse> query = _context.Users
                .ProjectTo<UserResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<UserResponse>
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

