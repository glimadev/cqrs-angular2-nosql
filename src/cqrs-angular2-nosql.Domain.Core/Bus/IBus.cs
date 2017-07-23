using cqrs_angular2_nosql.Domain.Core.Commands;

namespace cqrs_angular2_nosql.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
    }
}
