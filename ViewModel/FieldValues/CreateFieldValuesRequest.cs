using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.FieldValues
{
    public class CreateFieldValuesRequest
    {
        [Required]
        [Display(Name = "ID поля")]
        public Guid FieldId { get; set; }
        [Required]
        [Display(Name = "Дата изменения")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}
