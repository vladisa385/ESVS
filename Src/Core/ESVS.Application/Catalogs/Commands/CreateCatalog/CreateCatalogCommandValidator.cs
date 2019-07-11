using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ESVS.Application.Catalogs.Commands.CreateCatalog
{
    public class CreateCatalogCommandValidator: AbstractValidator<CreateCatalogCommand>
    {
        public CreateCatalogCommandValidator()
        {
            RuleFor(x => x.Type).MinimumLength(5);
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.Text).MinimumLength(5);
        }
    }
}
