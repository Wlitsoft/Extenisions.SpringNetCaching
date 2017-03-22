using System.Web.Mvc;

namespace DistributedCache.MVC4WebAppQuickStart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("index");
        }
    }

}