using System.Threading;
using System.Threading.Tasks;
using ESVS.Domain.Entities;

namespace ESVS.Application.Interfaces
{
    public interface IESVSDbContext
    {
        IRepository<Catalog> Catalogs { get; set; }
        IRepository<Field> Fields { get; set; }
        IRepository<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
