using System;
using System.Threading.Tasks;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbImplementation.Users
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserCommand(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task ExecuteAsync(Guid userId)
        {

            User userToDelete = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == userId);

            if (userToDelete != null)
            {
                await _userManager.DeleteAsync(userToDelete);
            }
        }
    }
}
