using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Users
{
    public class UserCredentialsException : Exception
    {


        public IEnumerable<IdentityError> Errors { get; set; }
        public UserCredentialsException(IEnumerable<IdentityError> errors) : base("User cannot be created or updated")
        {
            Errors = errors;
        }
        public UserCredentialsException() : base("Invalid login or password")
        { }
    }
}
