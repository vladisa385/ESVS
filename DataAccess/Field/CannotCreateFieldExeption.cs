using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Field
{
    public class CannotCreateFieldExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateFieldExeption(IEnumerable<IdentityError> errors) : base("Catalog of catalogs cannot be created")
        {
            Errors = errors;
        }
    }
}
