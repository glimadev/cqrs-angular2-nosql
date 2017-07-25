using FluentValidation;

namespace cqrs_angular2_nosql.Domain.Commands.Validations
{
    public class UpdateClientCommandValidation : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .Length(2, 150).WithMessage("Nome deve ter entre 2 e 150 caracteres");
        }
    }
}
