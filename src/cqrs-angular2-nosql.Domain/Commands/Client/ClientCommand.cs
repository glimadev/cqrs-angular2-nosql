using cqrs_angular2_nosql.Domain.Core.Commands;
using System;

namespace cqrs_angular2_nosql.Domain.Commands
{
    public abstract class ClientCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}
