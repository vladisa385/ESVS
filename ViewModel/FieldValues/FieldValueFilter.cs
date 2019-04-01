using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.FieldValues
{
    public class FieldValueFilter
    {
        public Guid Id { get; set; }

        public Guid FieldId { get; set; }

        public DateTime Date { get; set; }

        public string Value { get; set; }
    }
}
