using cqrs_angular2_nosql.Domain.Commands.Client;
using cqrs_angular2_nosql.Domain.Commands.Client.Validations;
using FluentValidation.Results;

namespace cqrs_angular2_nosql.Domain.Commands
{
    public class RegisterClientCommand : ClientCommand
    {
        public RegisterClientCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
