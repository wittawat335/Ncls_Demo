using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCLS.DOMAIN.Entities;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    public class BaseController : Controller
    {
        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();
        string _screenName = "";
        string _methodName = "";
        protected override void OnException(ExceptionContext filterContext)
        {
            try
            {

                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                cm.ErrorPage = filterContext.RouteData.Values["controller"].ToString() + "/" + filterContext.RouteData.Values["action"].ToString();
                cm.ErrorMsg = ex.Message.ToString();

            }
            catch (Exception ex)
            {

            }
        }
        public ActionResult ExpExcl(DataTable dt)
        {

            var grid = new GridView();
            grid.DataSource = dt;
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachement; filename=data.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }
        public FileResult DownloadFileExcel(string fileName)
        {
            try
            {
                //  var fileDir = Server.MapPath("~/TempFiles/Download/LegalCase/");
                //   var filePath = System.IO.Path.Combine(fileDir, fileName);
                byte[] fileBytes = System.IO.File.ReadAllBytes(fileName);

                //Delete File
                System.IO.File.Delete(fileName);

                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(fileName));
            }
            catch (Exception)
            {

                throw;
            }

        }
        #region Select2
        public JsonResult SearchContract(string term, string listContract)
        {
            try
            {
                if (!string.IsNullOrEmpty(listContract) || listContract == "")
                {
                    var listCon = listContract.Split(',').ToArray();
                    var contractList = db.S_CONTRACT
                    .Where(x => (x.CONTRACT_NO + x.CUST_NAME_TH).Contains(term) && !listCon.Contains(x.CONTRACT_NO))
                    .Select(x => new
                    {
                        id = x.CONTRACT_NO,
                        text = x.CONTRACT_NO + " : " + x.CUST_NAME_TH
                    }).ToList();
                    return Json(contractList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var overDueDay = Convert.ToInt32(cm.GetParameterByCode(Constants.ParaCode.ParaX19));
                    var contractList = db.S_CONTRACT
                     .Where(x => (x.CONTRACT_NO + x.CUST_NAME_TH).Contains(term) && x.OVERDUE_DAY >= overDueDay)
                     .Select(x => new
                     {
                         id = x.CONTRACT_NO,
                         text = x.CONTRACT_NO + " : " + x.CUST_NAME_TH
                     }).ToList();
                    return Json(contractList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult ContractNoRepoSearch(string term)
        {
            var contractList = db.T_JOB_REPO
                   .Where(x => (x.JOB_CONTRACT_NO + x.JOB_CUST_NAME).Contains(term))
                   .Select(x => new
                   {
                       id = x.JOB_CONTRACT_NO,
                       text = x.JOB_CONTRACT_NO + " : " + x.JOB_CUST_NAME
                   }).ToList();
            return Json(contractList, JsonRequestBehavior.AllowGet);
        }

        #endregion
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (filterContext.ActionDescriptor.ActionName != "Login")
        //    {
        //     string   _screenName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //        _methodName = filterContext.ActionDescriptor.ActionName;

        //        //if (USERINFO == null)
        //        //{
        //        //    filterContext.Result = new RedirectToRouteResult(
        //        //                       new RouteValueDictionary
        //        //                   {
        //        //                       { "action", "Login" },
        //        //                       { "controller", "Home" }
        //        //                   });
        //        //}
        //        //else
        //        //{
        //        //    if (USERINFO.User_Login == null)
        //        //    {
        //        //        filterContext.Result = new RedirectToRouteResult(
        //        //                       new RouteValueDictionary
        //        //                   {
        //        //                       { "action", "Login" },
        //        //                       { "controller", "Home" }
        //        //                   });
        //        //    }
        //        //}
        //    }
        //    // your logging stuff here
        //  //  base.OnActionExecuting(filterContext);
        //}

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    try
        //    {
        //        Exception ex = filterContext.Exception;
        //        filterContext.ExceptionHandled = true;


        //        //End

        //        Exception e = filterContext.Exception;
        //        //Log Exception e
        //        filterContext.ExceptionHandled = true;
        //        filterContext.Result = new ViewResult()
        //        {
        //            ViewName = "Error"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        filterContext.Result = new JsonResult
        //        {
        //            Data = new { success = false, Error = ex.Message.ToString() },
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //}

    }
}