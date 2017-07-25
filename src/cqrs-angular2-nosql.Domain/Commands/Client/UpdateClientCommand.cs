using cqrs_angular2_nosql.Domain.Commands.Validations;
using FluentValidation.Results;

namespace cqrs_angular2_nosql.Domain.Commands
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
