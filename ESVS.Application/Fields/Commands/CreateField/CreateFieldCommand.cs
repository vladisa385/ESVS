using System;
using MediatR;

namespace ESVS.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Length { get; set; }
        public bool NotNull { get; set; }
        public bool IsForeignKey { get; set; }
        public Guid TypeId { get; set; }
        public Guid CatalogId { get; set; }
    }
}