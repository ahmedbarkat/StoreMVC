using Safoa.DAL;
using Safoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Safoa.Controllers
{
    public class HomeController : BaseController
    {
        private SafoaContext db = new SafoaContext();
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                int userId = (int)Session["uid"];
                var scopes = db.UserScopes.Where(P => P.UserId == userId).ToList();
                ViewBag.Scopes = db.Foundations.ToList();
                ViewBag.LastScopeId = Session["LastScopeId"];
                ViewBag.UserScopes = scopes;
                ViewBag.UserName = Session["userName"];

            }

            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }
    }
}
