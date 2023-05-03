using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.Models.ViewModels.Error;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    public class ErrorController : BaseController
    {
        Common cm = new Common();
        public ViewResult Error()
        {
            ErrorMaintenance model = new ErrorMaintenance();
            //  Response.StatusCode = cm.UnInt32Null(ErrorCode);
            model.ErrorPage = cm.ErrorPage;
            // model.ErrorCode = ErrorCode;
            model.ErrorMsg = cm.ErrorMsg;


            cm.WriteLogError(model.ErrorMsg);

            return View(model);

            // Response.StatusCode = (int)HttpStatusCode.NotFound;
            //      return View(model);
        }


    }
}