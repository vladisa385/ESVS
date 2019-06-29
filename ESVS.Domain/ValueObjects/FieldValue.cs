using System;
using System.Collections.Generic;
using ESVS.Domain.Entities;
using ESVS.Domain.Infrastructure;

namespace ESVS.Domain.ValueObjects
{
    public class FieldValue : ValueObject
    {
        private FieldValue(Field field, string value)
        {
            Field = field;
            Date = DateTime.Now;
            Value = value;
        }

        public Field Field { get; }
        public DateTime Date { get; }
        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Field;
            yield return Date;
            yield return Value;
        }
    }
}