using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.FieldValue
{
    public class CannotCreateFieldValueExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateFieldValueExeption(IEnumerable<IdentityError> errors) : base("FieldValue cannot be created")
        {
            Errors = errors;
        }
    }
}
