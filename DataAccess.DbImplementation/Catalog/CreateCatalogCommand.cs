using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Catalog;
using DB;
using ViewModel;
using ViewModel.Catalogs;

namespace DataAccess.DbImplementation.Catalog
{
    public class CreateCatalogCommand : ICreateCatalogCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCatalogCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<CatalogResponse> ExecuteAsync(CreateCatalogRequest request)
        {
            var catalog = _mapper.Map<CreateCatalogRequest, Entities.Catalog>(request);
            await _context.AddAsync(catalog);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Catalog, CatalogResponse>(catalog);
        }
    }
}
