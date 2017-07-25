using System.Web.Mvc;

namespace cqrs_angular2_nosql.Areas.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Website/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}