using ESVS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using ESVS.Domain.Entities;


namespace ESVS.Persistence
{
    public class ESVSDbContext : DbContext, IESVSDbContext
    {
        public ESVSDbContext(DbContextOptions<ESVSDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ESVSDbContext).Assembly);

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
