using cqrs_angular2_nosql.Domain.Commands.Validations;
using System;

namespace cqrs_angular2_nosql.Domain.Commands
{
    public class RemoveClientCommand : ClientCommand
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
