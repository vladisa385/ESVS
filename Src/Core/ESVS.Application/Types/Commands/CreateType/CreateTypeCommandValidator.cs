using FluentValidation;

namespace ESVS.Application.Types.Commands.CreateType
{
    public class CreateTypeCommandValidator: AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeCommandValidator() => 
            RuleFor(x => x.Name).NotEmpty();
    }
}