using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DataAccess.DbImplementation
{
    public class CatalogOfCatalogsListQuery : ICatalogOfCatalogsListQuery
    {
        /*private readonly AppDbContext _context;
        public CatalogOfCatalogsListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<CatalogOfCatalogsResponse> ApplyFilter(IQueryable<CatalogOfCatalogsResponse> query, CatalogOfCatalogsFilter filter)
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

        public async Task<ListResponse<CatalogOfCatalogsResponse>> RunAsync(CatalogOfCatalogsFilter filter, ListOptions options)
        {
            IQueryable<CatalogOfCatalogsResponse> query = _context.Users //nado CatalogOfCatalogss
                .ProjectTo<CatalogOfCatalogsResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CatalogOfCatalogsResponse>
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
        public CatalogOfCatalogsListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<CatalogOfCatalogsResponse> ApplyFilter(IQueryable<CatalogOfCatalogsResponse> query, CatalogOfCatalogsFilter filter)
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

        public async Task<ListResponse<CatalogOfCatalogsResponse>> RunAsync(CatalogOfCatalogsFilter filter, ListOptions options)
        {
            IQueryable<CatalogOfCatalogsResponse> query = _context.CatalogOfCatalogs.Include("CatalogOfCatalogs")
                .ProjectTo<CatalogOfCatalogsResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CatalogOfCatalogsResponse>
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
