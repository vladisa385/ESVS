using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Field
    {
        [Required]
        public Guid Id { get; set; }

        [MinLength(5), MaxLength(40)]
        public string Name { get; set; }

        public int Lenght { get; set; }

        [Required]
        public bool CanBeNull { get; set; }

        public Type Type { get; set; }

        [Required]
        public Guid TypeId { get; set; }

        [Required]
        public Guid CatalogId { get; set; }

        public Catalog Catalog { get; set; }

        public ICollection<FieldValue> Values { get; set; }
    }
}
