using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Catalog
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(100), MaxLength(1000)]
        public string Description { get; set; }

        public Guid? ParentId { get; set; }

        public Catalog Parent { get; set; }

        public ICollection<Field> Fields { get; set; }

        public ICollection<Catalog> ChildCatalogs { get; set; }

    }
}
