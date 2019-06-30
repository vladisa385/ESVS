using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.UpdateCatalog
{
    public class UpdateCatalogCommand:IRequest<Guid>, IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentId { get; set; }
    }
}
