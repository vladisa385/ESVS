using ESVS.Application.Catalogs.Commands.CreateCatalog;
using FluentValidation;

namespace ESVS.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommandValidator:AbstractValidator<CreateFieldCommand>
    {
        public CreateFieldCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Caption).NotEmpty();
            RuleFor(x => x.Length).NotEmpty();
            RuleFor(x => x.NotNull).NotEmpty();
            RuleFor(x => x.IsForeignKey).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.CatalogId).NotEmpty();
        }
    }
}