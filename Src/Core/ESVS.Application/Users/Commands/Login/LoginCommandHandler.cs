using System.Threading;
using System.Threading.Tasks;
using ESVS.Application.Exceptions;
using ESVS.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ESVS.Application.Users.Commands.Login
{
    public class LoginCommandHandler:IRequestHandler<LoginCommand,Unit>
    {
        private readonly SignInManager<User> _signInManager;

        public LoginCommandHandler(SignInManager<User> signInManager) => 
            _signInManager = signInManager;

        public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager
                .PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);

            if (!result.Succeeded)
                throw new UserCredentialsException();
            return Unit.Value;
        }
    }
}