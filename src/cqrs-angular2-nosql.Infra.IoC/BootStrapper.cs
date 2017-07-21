using SimpleInjector;

namespace cqrs_angular2_nosql.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            #region [ Context ]

            //var registration = Lifestyle.Scoped.CreateRegistration<AllGiftsContext>(container);

            //container.AddRegistration(typeof(IDataContextAsync), registration);

            #endregion

            #region [ Services and Repositories ]

            //container.Register(typeof(IRepositoryAsync<>), typeof(Repository<>), new WebRequestLifestyle());

            #endregion
        }
    }
}
