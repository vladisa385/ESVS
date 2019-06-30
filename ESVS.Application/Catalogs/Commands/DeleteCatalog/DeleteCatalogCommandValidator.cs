using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ESVS.Application.Catalogs.Commands.DeleteCatalog
{
    public class DeleteCatalogCommandValidator:AbstractValidator<DeleteCatalogCommand>
    {
        public DeleteCatalogCommandValidator() => 
            RuleFor(x => x.Id).NotEmpty();
    }
}
