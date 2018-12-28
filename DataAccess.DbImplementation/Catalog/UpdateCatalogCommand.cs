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
            Catalogs foundCatalogs = await _context.Catalogs.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundCatalogs != null)
            {
                Catalogs mappedCatalogs = _mapper.Map<UpdateCatalogsRequest, Catalogs>(request);
                mappedCatalogs.Id = typefoodId;
                _context.Entry(foundCatalogs).CurrentValues.SetValues(mappedCatalogs);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Catalogs, CatalogsResponse>(foundCatalogs);
        }
    }
}
