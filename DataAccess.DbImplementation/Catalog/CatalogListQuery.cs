using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DataAccess.DbImplementation
{
    public class CatalogsListQuery : ICatalogsListQuery
    {
        /*private readonly AppDbContext _context;
        public CatalogsListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<CatalogsResponse> ApplyFilter(IQueryable<CatalogsResponse> query, CatalogsFilter filter)
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

        public async Task<ListResponse<CatalogsResponse>> RunAsync(CatalogsFilter filter, ListOptions options)
        {
            IQueryable<CatalogsResponse> query = _context.Users //nado Catalogss
                .ProjectTo<CatalogsResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CatalogsResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }*/
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CatalogsListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<CatalogsResponse> ApplyFilter(IQueryable<CatalogsResponse> query, CatalogsFilter filter)
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

        public async Task<ListResponse<CatalogsResponse>> RunAsync(CatalogsFilter filter, ListOptions options)
        {
            IQueryable<CatalogsResponse> query = _context.Catalogs.Include("Catalogs")
                .ProjectTo<CatalogsResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CatalogsResponse>
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
