using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;

namespace ESVS.Application.Fields.Commands.DeleteField
{
    public class DeleteFieldCommandValidator:AbstractValidator<DeleteFieldCommand>

    {
    public DeleteFieldCommandValidator() =>
        RuleFor(x => x.Id).NotEmpty();
    }
}
