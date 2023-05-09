using System.Web.Mvc;

namespace Safoa.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
