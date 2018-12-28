using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class CannotCreateCatalogsExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateCatalogsExeption(IEnumerable<IdentityError> errors) : base("Catalog of catalogs cannot be created")
        {
            Errors = errors;
        }
    }
}
