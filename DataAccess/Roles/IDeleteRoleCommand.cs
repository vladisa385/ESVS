using System;
using System.Threading.Tasks;

namespace DataAccess.Roles
{
    public interface IDeleteRoleCommand
    {
        Task ExecuteAsync(Guid roleId);
    }
}
