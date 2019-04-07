using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Catalog;
using DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using ViewModel.Catalogs;

namespace DataAccess.DbImplementation.Catalog
{
    public class UpdateCatalogCommand : IUpdateCatalogCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateCatalogCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CatalogResponse> ExecuteAsync(Guid catalogId, UpdateCatalogRequest request)
        {
            Entities.Catalog foundCatalogs = await _context.Catalogs.FirstOrDefaultAsync(t => t.Id == catalogId);
            if (foundCatalogs == null) return _mapper.Map<Entities.Catalog, CatalogResponse>(null);
            Entities.Catalog mappedCatalogs = _mapper.Map<UpdateCatalogRequest, Entities.Catalog>(request);
            mappedCatalogs.Id = catalogId;
            _context.Entry(foundCatalogs).CurrentValues.SetValues(mappedCatalogs);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Catalog, CatalogResponse>(foundCatalogs);
        }
    }
}
