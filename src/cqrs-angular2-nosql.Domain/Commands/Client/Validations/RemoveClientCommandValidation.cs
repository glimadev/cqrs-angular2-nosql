using FluentValidation;
using System;

namespace cqrs_angular2_nosql.Domain.Commands.Validations
{
    public class RemoveClientCommandValidation : AbstractValidator<RemoveClientCommand>
    {
        public RemoveClientCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(new Guid()).WithMessage("Id inválido");
        }
    }
}
