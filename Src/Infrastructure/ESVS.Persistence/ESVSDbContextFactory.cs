using ESVS.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ESVS.Persistence
{
    public class ESVSDbContextFactory : DesignTimeDbContextFactoryBase<ESVSDbContext>
    {
        protected override ESVSDbContext CreateNewInstance(DbContextOptions<ESVSDbContext> options) => 
            new ESVSDbContext(options);
    }
}
