using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ESVS.Application.Catalogs.Commands.UpdateCatalog
{
    public class UpdateCatalogCommandValidator: AbstractValidator<UpdateCatalogCommand>
    {
        public UpdateCatalogCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Type).MinimumLength(5);
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.Text).MinimumLength(5);
        }
    }
}