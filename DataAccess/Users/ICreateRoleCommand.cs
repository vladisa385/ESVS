using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface ICreateRoleCommand
    {
        Task ExecuteAsync(string roleName);
    }
}
