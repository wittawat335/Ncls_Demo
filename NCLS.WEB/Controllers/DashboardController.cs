using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.App_Start;
using NCLS.WEB.Entities;
using NCLS.WEB.Models.ViewModels.Dashboard;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    [SessionTimeout]
    public class DashboardController : BaseController
    {
        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();

        public ActionResult Index()
        {
            decimal xx = cm.CalculateMonth(1000, cm.SystemDate, cm.SystemDate.AddDays(3).AddMonths(3), 30);
            return View();
        }
        #region R3
        public ActionResult _ChartsR3()
        {
            try
            {
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult GetChartsR3()
        {

            try
            {
                List<Charts> objReturn = new List<Charts>();
                List<SP_DASHBOARD_R3_Result> objData = db.SP_DASHBOARD_R3().ToList();


                foreach (var x in objData)
                {
                    //objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE), color = x.COLOR });
                    objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE) });

                }



                return Json(objReturn, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _GetChartsR3Details(string type)
        {
            try
            {



                return PartialView();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Repo
        public ActionResult _ChartsRepo()
        {
            try
            {
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult GetChartsRepo()
        {

            try
            {
                List<Charts> objReturn = new List<Charts>();
                List<SP_DASHBOARD_REPO_Result> objData = db.SP_DASHBOARD_REPO().ToList();


                foreach (var x in objData)
                {
                    objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE), color = x.COLOR });

                }


                return Json(objReturn, JsonRequestBehavior.AllowGet);
                //  return Json(objReturn);

            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _GetChartsRepoDetails(string type)
        {
            try
            {



                return PartialView();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Doc
        public ActionResult _ChartsDoc()
        {
            try
            {
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult GetChartsDoc()
        {

            try
            {
                List<Charts> objReturn = new List<Charts>();
                List<SP_DASHBOARD_DOC_Result> objData = db.SP_DASHBOARD_DOC().ToList();


                foreach (var x in objData)
                {
                    objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE), color = x.COLOR });

                }


                return Json(objReturn, JsonRequestBehavior.AllowGet);
                // return Json(objReturn);

            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _GetChartsDocDetails(string type)
        {
            try
            {



                return PartialView();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Legal
        public ActionResult _ChartsLegal()
        {
            try
            {
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult GetChartsLegal()
        {

            try
            {
                List<Charts> objReturn = new List<Charts>();
                List<SP_DASHBOARD_LEGAL_Result> objData = db.SP_DASHBOARD_LEGAL().ToList();


                foreach (var x in objData)
                {
                    objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE), color = x.COLOR });

                }


                return Json(objReturn, JsonRequestBehavior.AllowGet);
                // return Json(objReturn);

            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _GetChartsLegalDetails(string type)
        {
            try
            {



                return PartialView();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region LegalStatus
        public ActionResult _ChartsLegalStatus()
        {
            try
            {
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult GetChartsLegalStatus(string type)
        {

            try
            {
                List<Charts> objReturn = new List<Charts>();
                List<SP_DASHBOARD_LEGALSTATUS_Result> objData = db.SP_DASHBOARD_LEGALSTATUS().ToList();


                foreach (var x in objData)
                {
                    objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE), color = x.COLOR });

                }

                return Json(objReturn, JsonRequestBehavior.AllowGet);

                //  return Json(objReturn);

            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _GetChartsLegalStatusDetails(string type)
        {
            try
            {



                return PartialView();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region LegalCase
        public ActionResult _ChartsLegalCase()
        {
            try
            {
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult GetChartsLegalCase(string type)
        {

            try
            {
                List<Charts> objReturn = new List<Charts>();
                List<SP_DASHBOARD_LEGALCASE_Result> objData = db.SP_DASHBOARD_LEGALCASE().ToList();


                foreach (var x in objData)
                {
                    objReturn.Add(new Charts() { id = x.ID, text = x.TEXT, value = cm.UnInt32Null(x.VALUE), color = x.COLOR });

                }


                return Json(objReturn, JsonRequestBehavior.AllowGet);
                //  return Json(objReturn);

            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _GetChartsLegalCaseDetails(string type)
        {
            try
            {



                return PartialView();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}