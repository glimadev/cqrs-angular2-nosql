using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Core.Events;
using cqrs_angular2_nosql.Domain.Core.Notifications;
using cqrs_angular2_nosql.Domain.Handlers;
using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Models;
using System;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Commands.Handlers
{
    public class ClientCommandHandler : CommandHandler,
        IHandler<RegisterClientCommand>,
        IHandler<UpdateClientCommand>,
        IHandler<RemoveClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBus _bus;

        public ClientCommandHandler(
            IClientRepository clientRepository,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications)
            : base(bus, notifications)
        {
            _clientRepository = clientRepository;
            _bus = bus;
        }

        public async Task Handle(RegisterClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(Guid.NewGuid().ToString(), message.Name, message.Email);

            if ((await _clientRepository.FirstOrDefaultAsync(c => c.Email == client.Email)) != null)
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desse cliente já foi cadastrado."));

                return;
            }

            await _clientRepository.AddOrUpdateAsync(client);
        }

        public async Task Handle(UpdateClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(message.Id.ToString(), message.Name, message.Email);

            var existing = await _clientRepository.FirstOrDefaultAsync(c => c.Email == message.Email);

            if (existing != null && (existing.id != client.id))
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desse cliente já foi cadastrado."));

                return;
            }

            await _clientRepository.AddOrUpdateAsync(client);
        }

        public async Task Handle(RemoveClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);

                return;
            }

            await _clientRepository.DeleteLogicAsync(message.Id.ToString());
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
