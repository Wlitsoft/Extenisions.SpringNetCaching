using System.Web.Mvc;
using DistributedCache.MVC4WebAppQuickStart.Services;
using Spring.Context;
using Spring.Context.Support;

namespace DistributedCache.MVC4WebAppQuickStart.Controllers
{
    public class PersonController : Controller
    {
        private static readonly IPersonService PersonService;

        static PersonController()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            PersonService = ctx.GetObject<IPersonService>("PersonService");
        }

        public ActionResult SayHello()
        {
            string result = PersonService.SayHello();
            return Content(result);
        }
    }
}