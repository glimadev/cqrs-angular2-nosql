using cqrs_angular2_nosql.Domain.Core.Commands;
using cqrs_angular2_nosql.Domain.Core.Events;

namespace cqrs_angular2_nosql.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
