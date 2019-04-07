using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Field
{
    public class CannotCreateFieldException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateFieldException(IEnumerable<IdentityError> errors) : base("Field cannot be created")
        {
            Errors = errors;
        }
    }
}
