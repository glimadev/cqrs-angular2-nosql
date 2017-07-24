
using cqrs_angular2_nosql.Domain.Commands.Validations;
using FluentValidation.Results;

namespace cqrs_angular2_nosql.Domain.Commands
{
    public class RegisterClientCommand : ClientCommand
    {
        public RegisterClientCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
