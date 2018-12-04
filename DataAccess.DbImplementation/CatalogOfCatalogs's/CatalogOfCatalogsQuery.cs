using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Roles;
using DB;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModel.Roles;
using ViewModel;

namespace DataAccess.DbImplementation
{
    public class CatalogOfCatalogsQuery : ICatalogOfCatalogsQuery
    {
        private readonly AppDbContext _context;
        public CatalogOfCatalogsQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CatalogOfCatalogsResponse> RunAsync(Guid catalogofcatalogsId)
        {
            CatalogOfCatalogsResponse response = await _context.CatalogOfCatalogs
                .ProjectTo<CatalogOfCatalogsResponse>()
                .FirstOrDefaultAsync(p => p.Id == catalogofcatalogsId);
            return response;
        }
    }
}
