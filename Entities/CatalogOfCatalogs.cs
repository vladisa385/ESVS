using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Catalog
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CatalogDescription { get; set; }

        public Guid? ParentId { get; set; }

        public Catalog Parent { get; set; }

    }
}
