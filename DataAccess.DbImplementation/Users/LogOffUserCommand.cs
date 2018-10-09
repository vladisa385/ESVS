using System.Threading.Tasks;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.DbImplementation.Users
{
    public class LogOffUserCommand : ILogOffUserCommand
    {
        private readonly SignInManager<User> _signInManager;

        public LogOffUserCommand(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task ExecuteAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
