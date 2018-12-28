using System;
using System.Threading.Tasks;
using DataAccess.Roles;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbImplementation.Roles
{
    public class DeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly RoleManager<Role> _roleManager;

        public DeleteRoleCommand(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task ExecuteAsync(Guid roleId)
        {

            Role roleToDelete = await _roleManager.Roles.FirstOrDefaultAsync(p => p.Id == roleId);

            if (roleToDelete != null)
            {
                await _roleManager.DeleteAsync(roleToDelete);
            }
        }
    }
}
