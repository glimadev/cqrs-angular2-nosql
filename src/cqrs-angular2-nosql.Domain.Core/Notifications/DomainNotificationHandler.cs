using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Core.Notifications
{
    /// <summary>
    /// Handlers dos eventos do command
    /// </summary>
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public async Task Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public IEnumerable<string> GetNotificationsMessages()
        {
            return _notifications.Select(x => x.Value).ToArray();
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
