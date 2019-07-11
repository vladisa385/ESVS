using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.DeleteCatalog
{
    public class DeleteCatalogCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
