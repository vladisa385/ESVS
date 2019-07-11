using FluentValidation;

namespace ESVS.Application.Fields.Commands.AddFieldValue
{
    public class AddFieldValueCommandValidator : AbstractValidator<AddFieldValueCommand>
    {
        public AddFieldValueCommandValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.FieldId).NotEmpty();
        }
    }
}