using System;

namespace ViewModel.Fields
{
    public class FieldFilter
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public RangeFilter<int> Length { get; set; }

        public RangeFilter<int> FieldValues { get; set; }

        public bool? NotNull { get; set; }

        public bool? IsForeignKey { get; set; }

        public string Type { get; set; }

        public Guid? CatalogId { get; set; }

    }
}
