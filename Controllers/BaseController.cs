using Safoa.DAL;
using Safoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safoa.Controllers
{
    public class BaseController : Controller
    {
        public int userId;
        private SafoaContext db = new SafoaContext();
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {

            //Session.Timeout = 2;


            var fontOptions = new ViewDataDictionary();
            foreach (var param in new string[] { "Font", "FontSize", "Bold", "LineHeight", "NoWrap" })
            {
                var form = ctx.RequestContext.HttpContext.Request;
                if (form[param] != null)
                {
                    fontOptions[param] = form[param].ToString();
                }
            }
            if (fontOptions.Count > 0)
            {
                ViewBag.FontOptions = fontOptions;
            }
            SystemMonitor log = new SystemMonitor
            {
                Controller = ctx.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = ctx.ActionDescriptor.ActionName,
                Paramters = string.Join(";", ctx.ActionParameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)).ToArray()),
                Browser = ctx.RequestContext.HttpContext.Request.Browser.Browser + " " + ctx.RequestContext.HttpContext.Request.Browser.Version.ToString(),
                Ip = ctx.HttpContext.Request.UserHostAddress
            };
            if (!Session.IsNewSession && Session["uid"] != null)
            {
                userId = int.Parse(Session["uid"].ToString());
                log.UserId = userId;

                db.SystemMonitors.Add(log);
                db.SaveChanges();
                base.OnActionExecuting(ctx);
            }
            else
            {
                log.Notes = "No Session";
                log.Time = DateTime.Now;
                db.SystemMonitors.Add(log);
                db.SaveChanges();
                Response.StatusCode = 403;
                if (!Request.IsAjaxRequest())
                {
                    Response.Redirect("Login", true);
                }
                else
                {
                    Response.End();
                }
            }
        }

    }
}