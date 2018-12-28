using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDeleteCatalogsCommand
    {
        Task ExecuteAsync(Guid catalogofcatalogsId);
    }
}
