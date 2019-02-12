using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;

//using DataAccess.Field;
using DataAccess.Field;
using ViewModel.Fields;

namespace DataAccess.DbImplementation.Field
{
   
        public class FieldListQuery : IFieldListQuery
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public FieldListQuery(AppDbContext tasksContext, IMapper mapper)
            {
                _context = tasksContext;
                _mapper = mapper;
            }

            private IQueryable<FieldResponse> ApplyFilter(IQueryable<FieldResponse> query, FieldFilter filter)
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

            public async Task<ListResponse<FieldResponse>> RunAsync(FieldFilter filter, ListOptions options)
            {
                IQueryable<FieldResponse> query = _context.Field.Include("Field")
                    .ProjectTo<FieldResponse>();
                query = ApplyFilter(query, filter);
                int totalCount = await query.CountAsync();
                if (options.Sort == null)
                {
                    options.Sort = "Id";
                }

                query = options.ApplySort(query);
                query = options.ApplyPaging(query);
                return new ListResponse<FieldResponse>
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
