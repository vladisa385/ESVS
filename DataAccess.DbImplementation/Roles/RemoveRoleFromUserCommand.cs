using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Roles;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.DbImplementation.Roles
{


    public class RemoveRoleFromUserCommand : IRemoveRoleFromUserCommand
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RemoveRoleFromUserCommand(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task ExecuteAsync(Guid roleId, Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role != null)
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
            }

        }
    }
}
