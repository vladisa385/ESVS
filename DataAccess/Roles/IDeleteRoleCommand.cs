using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface IDeleteRoleCommand
    {
        Task ExecuteAsync(Guid roleId);
    }
}
