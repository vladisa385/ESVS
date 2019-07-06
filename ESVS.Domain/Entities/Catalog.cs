using System;
using System.Collections.Generic;

namespace ESVS.Domain.Entities
{
    public class Catalog
    {
        public Catalog()
        {
            Fields = new HashSet<Field>();
            ChildCatalogs = new HashSet<Catalog>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

         public Guid ParentCatalogId { get; set; }

        public Catalog ParentCatalog { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Field> Fields { get; }

        public ICollection<Catalog> ChildCatalogs { get; }

    }
}
