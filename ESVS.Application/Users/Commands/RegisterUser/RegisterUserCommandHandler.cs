using System;
using System.Threading;
using System.Threading.Tasks;
using ESVS.Application.Exceptions;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ESVS.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler: IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                Email = request.Email,
                UserName = request.Email,
            };
            var result = await _userManager.CreateAsync(entity, request.Password);
            if (!result.Succeeded)
                throw new UserCredentialsException(result.Errors);
            await _signInManager.SignInAsync(entity, false);
            return entity.Id;
        }
    }
}