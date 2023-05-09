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
    public class LogInController : Controller
    {
        // GET: LogIn
        private SafoaContext db = new SafoaContext();

        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Failed(bool error)
        {
            ViewBag.ShowError = true;
            return Index();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(string username, string password)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return null;
            }
            if (Session["uid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }


            var usr = db.Users.Where(P => P.UserName == username).FirstOrDefault();
            db = new SafoaContext();
            SystemMonitor log = new SystemMonitor();
            if (usr != null && password == usr.Password)
            {
                log.Notes = "Loged in successfuly";

                db.SystemMonitors.Add(log);

                FormsAuthentication.SetAuthCookie(username, false);
                Session.Add("uid", usr.Id);
                Session.Add("userName", usr.Name);
                Session.Add("LastScopeId", usr.LastScopeId);
                if (usr.LastScopeId != null)
                {
                    Session.Add("scopeId", usr.LastScopeId);
                }
                else
                {
                    db = new SafoaContext();
                    var scope = db.UserScopes.Where(p => p.UserId == usr.Id).FirstOrDefault();
                    if (scope != null)
                    {
                        Session.Add("scopeId", scope.FoundationId);
                    }

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db = new SafoaContext();
                log.Notes = "Login attempt failed";

                db.SystemMonitors.Add(log);

                ViewBag.ShowError = true;
                return RedirectToAction("Failed", new { error = true });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}