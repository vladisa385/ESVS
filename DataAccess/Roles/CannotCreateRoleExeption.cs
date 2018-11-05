using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Roles
{
    public class CannotCreateRoleExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateRoleExeption(IEnumerable<IdentityError> errors) : base("Role cannot be created")
        {
            Errors = errors;
        }
    }
}
