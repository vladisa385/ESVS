using System;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.CreateCatalog
{
    public class CreateCatalogCommand:IRequest<Guid>
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentId { get; set; }
    }
}