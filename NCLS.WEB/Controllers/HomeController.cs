using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    public class HomeController : BaseController
    {
        Common cm = new Common();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string msg = "")
        {
            if (!cm.IsNullOrEmpty(msg))
                ViewBag.msg = Constants.Msg.SessionExp;
            else
                ViewBag.msg = msg;

            Session.Remove(Constants.SessionKey.LoginInfo);
            Session.Remove(Constants.SessionKey.Menu);
            FormsAuthentication.SignOut();

            return PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                base.Dispose(disposing);
        }
    }
}