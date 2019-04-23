using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Catalog
{
    public class CannotCreateCatalogException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateCatalogException(IEnumerable<IdentityError> errors) : base("Catalog of catalogs cannot be created")
        {
            Errors = errors;
        }
    }
}
