using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Roles
{
    public class CannotCreateRoleException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateRoleException(IEnumerable<IdentityError> errors) : base("Role cannot be created")
        {
            Errors = errors;
        }
    }
}
