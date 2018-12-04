using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Roles;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ViewModel.Roles;
using ViewModel;
using DB;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbImplementation
{
    public class UpdateCatalogOfCatalogsCommand : IUpdateCatalogOfCatalogsCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateCatalogOfCatalogsCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<CatalogOfCatalogsResponse> ExecuteAsync(Guid typefoodId, UpdateCatalogOfCatalogsRequest request)
        {
            CatalogOfCatalogs foundCatalogOfCatalogs = await _context.CatalogOfCatalogs.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundCatalogOfCatalogs != null)
            {
                CatalogOfCatalogs mappedCatalogOfCatalogs = _mapper.Map<UpdateCatalogOfCatalogsRequest, CatalogOfCatalogs>(request);
                mappedCatalogOfCatalogs.Id = typefoodId;
                _context.Entry(foundCatalogOfCatalogs).CurrentValues.SetValues(mappedCatalogOfCatalogs);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<CatalogOfCatalogs, CatalogOfCatalogsResponse>(foundCatalogOfCatalogs);
        }
    }
}
