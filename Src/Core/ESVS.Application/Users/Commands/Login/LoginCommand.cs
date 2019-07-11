using MediatR;

namespace ESVS.Application.Users.Commands.Login
{
    public class LoginCommand:IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}