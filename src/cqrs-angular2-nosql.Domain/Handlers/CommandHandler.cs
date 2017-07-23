using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Core.Commands;
using cqrs_angular2_nosql.Domain.Core.Notifications;

namespace cqrs_angular2_nosql.Domain.Handlers
{
    public class CommandHandler
    {
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            //commit
            //if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema salbando seus dados."));

            return false;
        }
    }
}
