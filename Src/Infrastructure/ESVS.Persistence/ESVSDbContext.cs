using System;
using ESVS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using ESVS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Type = ESVS.Domain.Entities.Type;


namespace ESVS.Persistence
{
    public class ESVSDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IESVSDbContext
    {
        public ESVSDbContext(DbContextOptions<ESVSDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
             modelBuilder.ApplyConfigurationsFromAssembly(typeof(ESVSDbContext).Assembly);
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Type> Types { get; set; }
        public void UpdateEntity<T,TX>(T entity,TX mappedEntity) where T : class => 
            Entry(entity).CurrentValues.SetValues(mappedEntity);
    }
}
