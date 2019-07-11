using System;
using System.Collections.Generic;

namespace ESVS.Domain.Entities
{
    public class FieldValue 
    {
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }

    }
}