using System.Web;
using System.Web.Mvc;

namespace cqrs_angular2_nosql
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
