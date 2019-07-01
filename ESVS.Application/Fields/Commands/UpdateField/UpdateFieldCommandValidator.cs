using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ESVS.Application.Fields.Commands.UpdateField
{
    public class UpdateFieldCommandValidator : AbstractValidator<UpdateFieldCommand>
    {
        public UpdateFieldCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Caption).NotEmpty();
            RuleFor(x => x.Length).NotEmpty();
            RuleFor(x => x.NotNull).NotEmpty();
            RuleFor(x => x.IsForeignKey).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
