using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Core.Events;
using cqrs_angular2_nosql.Domain.Core.Notifications;
using cqrs_angular2_nosql.Domain.Handlers;
using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Models;

namespace cqrs_angular2_nosql.Domain.Commands.Handlers
{
    public class ClientCommandHandler : CommandHandler,
        IHandler<RegisterClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBus Bus;

        public ClientCommandHandler(
            IClientRepository clientRepository,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications)
            : base(bus, notifications)
        {
            _clientRepository = clientRepository;
            Bus = bus;
        }

        public void Handle(RegisterClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(message.Name);

            if (_clientRepository.FirstOrDefaultAsync(c => c.Email == client.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desse cliente já foi cadastrado."));
                return;
            }

            _clientRepository.AddOrUpdateAsync(client);
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
