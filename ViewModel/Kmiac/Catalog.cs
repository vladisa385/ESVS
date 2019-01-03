using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Kmiac
{
    public class Catalog
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public Catalog Parent { get; set; }


        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentGuid { get; set; }

    }
}
