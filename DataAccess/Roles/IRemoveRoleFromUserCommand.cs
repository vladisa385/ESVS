using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface IRemoveRoleFromUserCommand
    {
        Task ExecuteAsync(Guid roleId, Guid userId);
    }
}
