using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ESVS.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand:IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
