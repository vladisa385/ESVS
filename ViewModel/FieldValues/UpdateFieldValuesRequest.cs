using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.FieldValues
{
    public class UpdateFieldValuesRequest
    {

        [Display(Name = "ID поля")]
        public Guid FieldId { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime Date { get; set; }
        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}
