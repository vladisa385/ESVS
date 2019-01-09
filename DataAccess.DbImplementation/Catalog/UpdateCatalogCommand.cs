using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Hosting;
using ViewModel;
using DB;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbImplementation
{
    public class UpdateCatalogsCommand : IUpdateCatalogsCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateCatalogsCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CatalogsResponse> ExecuteAsync(Guid typefoodId, UpdateCatalogsRequest request)
        {
            Catalog foundCatalogs = await _context.Catalogs.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundCatalogs == null) return _mapper.Map<Catalog, CatalogsResponse>(foundCatalogs);
            Catalog mappedCatalogs = _mapper.Map<UpdateCatalogsRequest, Catalog>(request);
            mappedCatalogs.Id = typefoodId;
            _context.Entry(foundCatalogs).CurrentValues.SetValues(mappedCatalogs);
            await _context.SaveChangesAsync();
            return _mapper.Map<Catalog, CatalogsResponse>(foundCatalogs);
        }
    }
}
