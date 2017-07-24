using System.Web.Mvc;

namespace cqrs_angular2_nosql.Areas.API
{
    public class APIAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "API";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "API_default",
                "api/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}