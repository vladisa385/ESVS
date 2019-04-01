using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.FieldValues
{
    public class UpdateFieldValueRequest
    {
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Display(Name = "ID поля")]
        public Guid FieldId { get; set; }
        [Display(Name = "Время")]
        public DateTime Date { get; set; }
        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}
