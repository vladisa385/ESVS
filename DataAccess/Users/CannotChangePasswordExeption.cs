using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Users
{
    public class CannotChangePasswordExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotChangePasswordExeption(IEnumerable<IdentityError> errors) : base("Password cannot be changed")
        {
            Errors = errors;
        }
    }
}
