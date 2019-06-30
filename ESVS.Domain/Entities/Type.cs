using System;

namespace ESVS.Domain.Entities
{
    public class Type
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
