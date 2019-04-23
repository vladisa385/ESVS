using System;

namespace ViewModel.FieldValues
{
    public class FieldValuesFilter
    {
        public Guid? Id { get; set; }

        public Guid? FieldId { get; set; }

        public RangeFilter<DateTime> Date { get; set; }

        public string Value { get; set; }
    }
}
