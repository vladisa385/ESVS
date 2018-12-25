using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Field
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public Type Type { get; set; }

        public Guid TypeId { get; set; }

        public Guid CatalogOfCatalogId { get; set; }

        public CatalogOfCatalogs CatalogOfCatalog { get; set; }
    }
}
