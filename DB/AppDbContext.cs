using System;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<FieldValue> FieldValue { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
