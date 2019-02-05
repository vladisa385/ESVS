using System;
using System.Threading.Tasks;
using ViewModel.Roles;

namespace DataAccess.Roles
{
    public interface IUpdateRoleCommand
    {
        Task<RoleResponse> ExecuteAsync(UpdateRoleRequest request);
    }
}
