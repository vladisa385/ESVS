using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Catalog;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;
using ViewModel.Catalogs;

namespace DataAccess.DbImplementation.Catalog
{
    public class CatalogQuery : ICatalogQuery
    {
        private readonly AppDbContext _context;
        public CatalogQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CatalogResponse> RunAsync(Guid catalogId)
        {
            CatalogResponse response = await _context.Catalogs
                .ProjectTo<CatalogResponse>()
                .FirstOrDefaultAsync(p => p.Id == catalogId);
            return response;
        }
    }
}
