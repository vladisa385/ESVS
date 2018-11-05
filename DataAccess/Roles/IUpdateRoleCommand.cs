using System.Threading.Tasks;
using ViewModel.Roles;
using ViewModel.Users;

namespace DataAccess.Roles
{
    public interface IUpdateRoleCommand
    {
        Task<RoleResponse> ExecuteAsync(UpdateRoleRequest request);
    }
}
