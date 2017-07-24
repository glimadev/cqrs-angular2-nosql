using cqrs_angular2_nosql.Application;
using cqrs_angular2_nosql.Domain.Commands;
using cqrs_angular2_nosql.Domain.Commands.Handlers;
using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Core.Events;
using cqrs_angular2_nosql.Domain.Core.Notifications;
using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Models;
using cqrs_angular2_nosql.Domain.Service;
using cqrs_angular2_nosql.Infra.Bus;
using cqrs_angular2_nosql.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Linq;
using System.Reflection;

namespace cqrs_angular2_nosql.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            #region [ Services and Repositories ]

            IocHelper.AutoMap(container, typeof(IClientService).Assembly, Lifestyle.Scoped);
            IocHelper.AutoMap(container, typeof(IClientApp).Assembly, Lifestyle.Scoped);
            IocHelper.AutoMap(container, typeof(IClientRepository).Assembly, Lifestyle.Scoped);

            container.Register(typeof(IBus), typeof(InMemoryBus), new WebRequestLifestyle());
            //container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), new WebRequestLifestyle());
            container.Register(typeof(IDomainNotificationHandler<>), typeof(DomainNotificationHandler), new WebRequestLifestyle());
            //.Register(typeof(IHandler<>), typeof(CommandHandler), new WebRequestLifestyle());

            container.Register<IClientRepository, ClientRepository>(new WebRequestLifestyle());
            container.Register<IHandler<RegisterClientCommand>, ClientCommandHandler>(new WebRequestLifestyle());
            container.Register<IRepository<Client>>(() => new Repository<Client>("ClientCollection"), Lifestyle.Scoped);

            #endregion

            SetContainer(container);
        }

        public static void SetContainer(Container container)
        {
            IoContainer.StContainer.container = container;
        }
    }

    public static class IocHelper
    {
        public static void AutoMap(this Container container, Assembly assembly, Lifestyle lifestyle)
        {
            container.ResolveUnregisteredType += (s, e) =>
            {
                if (e.UnregisteredServiceType.IsInterface && !e.Handled)
                {
                    Type[] concreteTypes = (
                        from type in assembly.GetTypes()
                        where !type.IsAbstract && !type.IsGenericType
                        where e.UnregisteredServiceType.IsAssignableFrom(type)
                        select type)
                        .ToArray();

                    if (concreteTypes.Length == 1)
                    {
                        e.Register(lifestyle.CreateRegistration(concreteTypes[0],
                            container));
                    }
                }
            };
        }
    }
}