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
        /// <summary>
        /// Injeções de dependências
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterServices(Container container)
        {
            #region [ Services and Repositories ]

            //Application
            IocHelper.AutoMap(container, typeof(IClientApp).Assembly, Lifestyle.Scoped);

            //Bus
            container.Register(typeof(IBus), typeof(InMemoryBus), new WebRequestLifestyle());

            //Service
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), new WebRequestLifestyle());
            IocHelper.AutoMap(container, typeof(IClientService).Assembly, Lifestyle.Scoped);

            //Command Handlers
            var registration = Lifestyle.Scoped.CreateRegistration<ClientCommandHandler>(container);
            container.AddRegistration(typeof(IHandler<RegisterClientCommand>), registration);
            container.AddRegistration(typeof(IHandler<UpdateClientCommand>), registration);
            container.AddRegistration(typeof(IHandler<RemoveClientCommand>), registration);

            //Event Handlers
            container.Register<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);

            //Repository
            container.Register<IClientRepository, ClientRepository>(new WebRequestLifestyle());
            container.Register<IRepository<Client>>(() => new Repository<Client>("ClientCollection"), Lifestyle.Scoped);

            #endregion

            SetContainer(container);
        }

        /// <summary>
        /// Seta o container handler em uma variavel estática
        /// </summary>
        /// <param name="container"></param>
        public static void SetContainer(Container container)
        {
            ContainerHandler.ContainerHandler.container = container;
        }
    }

    public static class IocHelper
    {
        /// <summary>
        /// Mapeia interfaces pelo mesmo namespace
        /// </summary>
        /// <param name="container"></param>
        /// <param name="assembly"></param>
        /// <param name="lifestyle"></param>
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