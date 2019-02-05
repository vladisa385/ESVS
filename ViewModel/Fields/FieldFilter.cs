using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.Fields
{
    public class FieldFilter
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public int Length { get; set; }

        public bool NotNull { get; set; }

        public bool IsForeignKey { get; set; }

        public string Type { get; set; }

        public Guid CatalogId { get; set; }

        //public Catalog Catalog { get; set; }
    }
}
