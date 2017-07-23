using cqrs_angular2_nosql.Domain.Core.Events;
using System.Collections.Generic;

namespace cqrs_angular2_nosql.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
