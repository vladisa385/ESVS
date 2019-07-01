using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ESVS.Application.Fields.Commands.UpdateField
{
    public class UpdateFieldCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Length { get; set; }
        public bool NotNull { get; set; }
        public bool IsForeignKey { get; set; }
        public Guid TypeId { get; set; }
    }
}
