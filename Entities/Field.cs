using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Field
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type Type { get; set; }

        public Guid TypeId { get; set; }

        public Guid CatalogId { get; set; }

        public Catalogs Catalog { get; set; }
    }
}
