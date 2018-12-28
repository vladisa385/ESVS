using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class FieldValue
    {
        [Required]
        public Guid Id { get; set; }
        public Field Field { get; set; }
        [Required]
        public Guid FieldId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
