using System.Web.Mvc;
using DistributedCache.MVC4WebAppQuickStart.Services;
using Spring.Context;
using Spring.Context.Support;

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