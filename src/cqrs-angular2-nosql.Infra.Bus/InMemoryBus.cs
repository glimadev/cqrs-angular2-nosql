using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Core.Commands;
using cqrs_angular2_nosql.Domain.Core.Events;
using cqrs_angular2_nosql.Domain.Core.Notifications;
using SimpleInjector;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Infra.Bus
{
    public sealed class InMemoryBus : IBus
    {
        private static Container Container = ContainerHandler.ContainerHandler.container;

        public async Task SendCommand<T>(T theCommand) where T : Command
        {
            await Publish(theCommand);
        }

        private static async Task Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetInstance(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            await ((IHandler<T>)obj).Handle(message);
        }

        public async Task RaiseEvent<T>(T theEvent) where T : Event
        {
            await Publish(theEvent);
        }
    }
}
