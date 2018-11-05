using System;
using System.Threading.Tasks;
using ViewModel.Roles;

namespace DataAccess.Roles
{
    public interface IAddRoleToUserCommand
    {
        Task<RoleResponse> ExecuteAsync(Guid roleId, Guid userId);
    }
}
