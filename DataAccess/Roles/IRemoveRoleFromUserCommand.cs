using System;
using System.Threading.Tasks;

namespace DataAccess.Roles
{
    public interface IRemoveRoleFromUserCommand
    {
        Task ExecuteAsync(Guid roleId, Guid userId);
    }
}
