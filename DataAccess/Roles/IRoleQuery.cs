using System;
using System.Threading.Tasks;
using ViewModel.Roles;
using ViewModel.Users;

namespace DataAccess.Roles
{
    public interface IRoleQuery
    {
        Task<RoleResponse> RunAsync(Guid roleId);
    }
}
