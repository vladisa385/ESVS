using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IRoleQuery
    {
        Task<RoleResponse> RunAsync(Guid roleId);
    }
}
