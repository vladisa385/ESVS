using System.Threading.Tasks;
using ViewModel.Roles;
using ViewModel.Users;

namespace DataAccess.Roles
{
    public interface ICreateRoleCommand
    {
        Task<RoleResponse> ExecuteAsync(CreateRoleRequest roleName);
    }
}
