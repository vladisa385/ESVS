using System;
using ESVS.Application.Infrastructure.Query;
using MediatR;

namespace ESVS.Application.Users.Queries.GetAllUsers
{
    public class GetListUsersQuery : IRequest<ListResponse<UserViewModel>>, IListQuery
    {
        public ListOptions Options { get; set; }
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
    }
}