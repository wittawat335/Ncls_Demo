using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.App_Start;
using NCLS.WEB.Entities;
using NCLS.WEB.Models.ViewModels.Bucket;
using NCLS.WEB.Services;
using NCLS.WEB.Services.Contract;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    [SessionTimeout]
    public class BucketController : BaseController
    {
        private readonly IBucketService _service;
        Common cm = new Common();

        public BucketController()
        {
            this._service = new BucketService();
        }

        // GET: Bucket
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult _Search(string Code, string BucketName, decimal? OvdStart, decimal? OvdEnd, string Status)
        {
            try
            {
                var model = _service.Search(Code, BucketName, OvdStart, OvdEnd, Status);

                return PartialView(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult _Details(string mode, string code)
        {
            BucketMaintenance model = new BucketMaintenance();
            try
            {
                model.Bucket = _service.Detail(code);
                model.mode = mode;

                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Save(M_BUCKET Bucket, string mode)
        {
            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;

            try
            {
                if (mode.Equals(Constants.Mode.New))
                {
                    if (_service.CheckDuplicate(Bucket.BUCKET_CODE))
                    {
                        _service.Add(Bucket);
                        result = Constants.Result.True;
                    }
                    else
                    {
                        message = Constants.Msg.Duplicate;
                    }
                }
                else
                {

                    _service.Update(Bucket, cm.UserLogin, cm.SystemDate);
                    result = Constants.Result.True;
                }

                if (result.Equals(Constants.Result.True))
                {
                    message = Constants.Msg.SaveSucc;
                }


                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}