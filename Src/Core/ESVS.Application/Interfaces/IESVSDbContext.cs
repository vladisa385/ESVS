using System.Threading;
using System.Threading.Tasks;
using ESVS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESVS.Application.Interfaces
{
    public interface IESVSDbContext
    {
        DbSet<Catalog> Catalogs { get; set; }
        DbSet<Field> Fields { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Type> Types { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void UpdateEntity<T,TX>(T entity,TX mappedEntity) where T : class;
    }
}
