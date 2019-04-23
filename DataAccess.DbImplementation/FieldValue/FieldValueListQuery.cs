using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class FieldValueListQuery : IFieldValuesListQuery
    {
        private readonly AppDbContext _context;

        public FieldValueListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;
        }

        private IQueryable<FieldValuesResponse> ApplyFilter(IQueryable<FieldValuesResponse> query, FieldValuesFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Value != null)
            {
                query = query.Where(p => p.Value.Contains(filter.Value));
            }

            if (filter.FieldId != null)
            {
                query = query.Where(p => p.FieldId == filter.FieldId);
            }

            if (filter.Date != null)
            {
                if (filter.Date.From != null)
                {
                    query = query.Where(p => p.Date >= filter.Date.From);
                }

                if (filter.Date.To != null)
                {
                    query = query.Where(p => p.Date <= filter.Date.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<FieldValuesResponse>> RunAsync(FieldValuesFilter filter, ListOptions options)
        {
            IQueryable<FieldValuesResponse> query = _context.FieldValues
                .ProjectTo<FieldValuesResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<FieldValuesResponse>
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
