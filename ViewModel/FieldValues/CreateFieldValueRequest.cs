using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.FieldValues
{
    public class CreateFieldValueRequest
    {
        [Required]
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "ID поля")]
        public Guid FieldId { get; set; }
        [Required]
        [Display(Name = "Время")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}
