using System;
using MediatR;

namespace ESVS.Application.Users.Queries.GetUser
{
    public class GetUserQuery:IRequest<UserViewModel>
    {
        public Guid Id { get; set; }
    }
}