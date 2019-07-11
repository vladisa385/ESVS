using System;
using System.Collections.Generic;

namespace ESVS.Domain.Entities
{
    public class Field
    {
        public Field() => 
            FieldValues = new HashSet<FieldValue>();
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public int? Length { get; set; }

        public bool IsForeignKey { get; set; }

        public bool NotNull { get; set; }

        public Guid TypeId { get; set; }

        public Type Type { get; set; }
        public Guid CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<FieldValue> FieldValues { get; set; }
    }
}
