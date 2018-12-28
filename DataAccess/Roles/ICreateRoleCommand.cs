using System.Threading.Tasks;
using ViewModel.Roles;

namespace DataAccess.Roles
{
    public interface ICreateRoleCommand
    {
        Task<RoleResponse> ExecuteAsync(CreateRoleRequest roleName);
    }
}
