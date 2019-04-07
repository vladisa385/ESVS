using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ViewModel.FieldValues;

namespace ViewModel.Fields
{
    public class FieldResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public bool NotNull { get; set; }
        [Required]
        public bool IsForeignKey { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public Guid CatalogId { get; set; }

        public int FieldValuesCount { get; set; }

        public ICollection<FieldValuesResponse> FieldValues { get; set; }
    }
}
