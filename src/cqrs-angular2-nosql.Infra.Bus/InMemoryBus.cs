using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Core.Commands;
using cqrs_angular2_nosql.Domain.Core.Events;
using cqrs_angular2_nosql.Domain.Core.Notifications;
using SimpleInjector;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Infra.Bus
{
    /// <summary>
    /// Bus em memoria para o recebimento de commands em fila
    /// </summary>
    public sealed class InMemoryBus : IBus
    {
        private static Container Container = ContainerHandler.ContainerHandler.container;

        /// <summary>
        /// Recebe o comando e o envia para ser executado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theCommand"></param>
        /// <returns></returns>
        public async Task SendCommand<T>(T theCommand) where T : Command
        {
            await Publish(theCommand);
        }

        /// <summary>
        /// Encaminha o comando para a interface que o implementa
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async Task Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetInstance(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            await ((IHandler<T>)obj).Handle(message);
        }

        /// <summary>
        /// Eventos são acionados após comando serem processados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent"></param>
        /// <returns></returns>
        public async Task RaiseEvent<T>(T theEvent) where T : Event
        {
            await Publish(theEvent);
        }
    }
}
