using cqrs_angular2_nosql.Domain.Core.Commands;
using cqrs_angular2_nosql.Domain.Core.Events;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Core.Bus
{
    public interface IBus
    {
        Task SendCommand<T>(T theCommand) where T : Command;
        Task RaiseEvent<T>(T theEvent) where T : Event;
    }
}
