using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class CannotCreateCatalogOfCatalogsExeption : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }
        public CannotCreateCatalogOfCatalogsExeption(IEnumerable<IdentityError> errors) : base("Catalog of catalogs cannot be created")
        {
            Errors = errors;
        }
    }
}
