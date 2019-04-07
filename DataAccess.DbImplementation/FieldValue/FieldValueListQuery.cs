using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class FieldValueListQuery : IFieldValueListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public FieldValueListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<FieldValueResponse> ApplyFilter(IQueryable<FieldValueResponse> query, FieldValueFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Value != null)
            {
                query = query.Where(p => p.Value.StartsWith(filter.Value));
            }

            return query;
        }

        public async Task<ListResponse<FieldValueResponse>> RunAsync(FieldValueFilter filter, ListOptions options)
        {
            IQueryable<FieldValueResponse> query = _context.FieldValues.Include("FieldValue")
                .ProjectTo<FieldValueResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<FieldValueResponse>
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
