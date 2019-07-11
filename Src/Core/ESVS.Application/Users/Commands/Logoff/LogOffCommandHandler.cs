using System.Threading;
using System.Threading.Tasks;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ESVS.Application.Users.Commands.Logoff
{
    public class LogOffCommandHandler:IRequestHandler<LogOffCommand,Unit>
    {
        private readonly SignInManager<User> _signInManager;

        public LogOffCommandHandler(SignInManager<User> signInManager) => 
            _signInManager = signInManager;

        public async Task<Unit> Handle(LogOffCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}