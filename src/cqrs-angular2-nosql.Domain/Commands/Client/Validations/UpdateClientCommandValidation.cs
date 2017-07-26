using FluentValidation;

namespace cqrs_angular2_nosql.Domain.Commands.Validations
{
    public class UpdateClientCommandValidation : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Código não pode ser vazio");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .Length(2, 150).WithMessage("Nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail não pode ser vazio")
                .EmailAddress().WithMessage("E-mail deve ser valido");
        }
    }
}
