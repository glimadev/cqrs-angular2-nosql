using cqrs_angular2_nosql.AutoMapper;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace cqrs_angular2_nosql
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new AreaWebSiteViewEngine());
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        private class AreaWebSiteViewEngine : RazorViewEngine
        {
            public AreaWebSiteViewEngine()
            {
                base.ViewLocationFormats = new string[] {
                    "~/Areas/WebSite/Views/{1}/{0}.cshtml",
                    "~/Areas/WebSite/Views/Shared/{0}.cshtml"
                };

                base.PartialViewLocationFormats = base.ViewLocationFormats;
            }

            protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
            {
                var nameSpace = controllerContext.Controller.GetType().Namespace;
                return base.CreatePartialView(controllerContext, partialPath.Replace("%1", nameSpace));
            }

            protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
            {
                var nameSpace = controllerContext.Controller.GetType().Namespace;
                return base.CreateView(controllerContext, viewPath.Replace("%1", nameSpace), masterPath.Replace("%1", nameSpace));
            }

            protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
            {
                var nameSpace = controllerContext.Controller.GetType().Namespace;
                return base.FileExists(controllerContext, virtualPath.Replace("%1", nameSpace));
            }

        }

        private class CustomView : IView
        {
            private string _viewPhysicalPath;

            public CustomView(string ViewPhysicalPath)
            {
                _viewPhysicalPath = ViewPhysicalPath;
            }

            #region IView Members

            public void Render(ViewContext viewContext, System.IO.TextWriter writer)
            {
                //Load File
                string rawcontents = File.ReadAllText(_viewPhysicalPath);

                //Perform Replacements
                string parsedcontents = Parse(rawcontents, viewContext.ViewData);

                writer.Write(parsedcontents);
            }

            #endregion

            public string Parse(string contents, ViewDataDictionary viewdata)
            {
                return Regex.Replace(contents, "\\{(.+)\\}", m => GetMatch(m, viewdata));
            }

            public virtual string GetMatch(Match m, ViewDataDictionary viewdata)
            {
                if (m.Success)
                {
                    string key = m.Result("$1");
                    if (viewdata.ContainsKey(key))
                    {
                        return viewdata[key].ToString();
                    }
                }
                return string.Empty;
            }
        }
    }
}
