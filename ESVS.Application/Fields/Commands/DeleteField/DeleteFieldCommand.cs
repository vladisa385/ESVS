using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ESVS.Application.Fields.Commands.DeleteField
{
    public class DeleteFieldCommand:IRequest
    {
         public Guid Id { get; set; }
    }
}
