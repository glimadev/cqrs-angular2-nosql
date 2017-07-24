using cqrs_angular2_nosql.App_Start;
using cqrs_angular2_nosql.Infra.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
[assembly: ApplicationShutdownMethod(typeof(SimpleInjectorInitializer), "Shutdown")]

namespace cqrs_angular2_nosql.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            //container.RegisterPerWebRequest(() =>
            //{
            //    if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
            //    {
            //        return new OwinContext().Authentication;
            //    }
            //    return HttpContext.Current.GetOwinContext().Authentication;

            //});

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            SetContainer(container);
        }

        private static void SetContainer(Container container)
        {
            BootStrapper.SetContainer(container);
        }

        public static void Shutdown()
        {

        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}