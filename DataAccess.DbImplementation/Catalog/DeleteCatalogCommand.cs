using System;
using System.Threading.Tasks;
using DataAccess.Catalog;
using DB;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbImplementation.Catalog
{
    public class DeleteCatalogCommand : IDeleteCatalogCommand
    {
        private readonly AppDbContext _context;

        public DeleteCatalogCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid catalogId)
        {
            var catalogToDelete = await _context.Catalogs.FirstOrDefaultAsync(p => p.Id == catalogId);

            if (catalogToDelete != null)
            {
                _context.Catalogs.Remove(catalogToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
