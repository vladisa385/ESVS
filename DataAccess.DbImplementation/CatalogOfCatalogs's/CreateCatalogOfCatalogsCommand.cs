using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Roles;
using DataAccess.Users;
using DB;
using Entities;
using Microsoft.AspNetCore.Identity;
using ViewModel.Roles;
using ViewModel;


namespace DataAccess.DbImplementation
{
    public class CreateCatalogOfCatalogsCommand : ICreateCatalogOfCatalogsCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCatalogOfCatalogsCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<CatalogOfCatalogsResponse> ExecuteAsync(CreateCatalogOfCatalogsRequest request)
        {
            var catalogofcatalogs = _mapper.Map<CreateCatalogOfCatalogsRequest, CatalogOfCatalogs>(request);
            await _context.AddAsync(catalogofcatalogs);
            await _context.SaveChangesAsync();
            return _mapper.Map<CatalogOfCatalogs, CatalogOfCatalogsResponse>(catalogofcatalogs);
        }
    }
}
