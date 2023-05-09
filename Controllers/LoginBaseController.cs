using Safoa.DAL;
using Safoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safoa.Controllers
{
    public class LoginBase : Controller
    {
        public int userId;
        public SystemMonitor log;
        private SafoaContext db = new SafoaContext();

        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            string referrer = "";

            if (ctx.RequestContext.HttpContext.Request.UrlReferrer != null)
            {
                referrer = ctx.RequestContext.HttpContext.Request.UrlReferrer.Authority.ToString();
            }

            log = new SystemMonitor
            {
                Controller = ctx.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = ctx.ActionDescriptor.ActionName,
                Paramters = string.Join(";", ctx.ActionParameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)).ToArray()),
                Browser = ctx.RequestContext.HttpContext.Request.Browser.Browser + " " + ctx.RequestContext.HttpContext.Request.Browser.Version.ToString(),
                Ip = ctx.HttpContext.Request.UserHostAddress
            };
            log.Paramters += referrer != "" ? ";Referrer=" + referrer : "";
            log.Paramters += ";Url=" + ctx.RequestContext.HttpContext.Request.Url.AbsolutePath;

            log.Notes = "No Session";

            db.SystemMonitors.Add(log);



        }
    }
}