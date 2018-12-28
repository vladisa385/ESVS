using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class FieldValue
    {
        public Guid Id { get; set; }
        public Field Field { get; set; }
        public Guid FieldId { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }
    }
}
