using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.FieldValues
{
    public class FieldValuesResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid FieldId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
