using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Catalog
    {
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentId { get; set; }

        public Catalog Parent { get; set; }

        public ICollection<Field> Fields { get; set; }

        public ICollection<Catalog> ChildCatalogs { get; set; }


    }
}
