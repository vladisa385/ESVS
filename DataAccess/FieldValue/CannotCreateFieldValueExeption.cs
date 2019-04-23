using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.FieldValue
{
    public class CannotCreateFieldValuesException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateFieldValuesException(IEnumerable<IdentityError> errors) : base("FieldValue cannot be created")
        {
            Errors = errors;
        }
    }
}
