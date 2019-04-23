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

        public string Caption { get; set; }

        public int? Length { get; set; }

        public bool IsForeignKey { get; set; }

        public bool NotNull { get; set; }

        public string Type { get; set; }

        [Required]
        public Guid CatalogId { get; set; }

        public Catalog Catalog { get; set; }

        public ICollection<FieldValue> FieldValues { get; set; }
    }
}
