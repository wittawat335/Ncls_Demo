using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.App_Start;
using NCLS.WEB.Entities;
using NCLS.WEB.Models.ViewModels.BankrupcyFraudC;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    [SessionTimeout]
    public class BankrupcyFraudController : BaseController
    {
        Common cm = new Common();
        NCLSEntities db = new NCLSEntities();
        //
        // GET: /BankrupcyFraud/
        public ActionResult Index(string id = "0")
        {
            ViewBag.Noti = id;
            ViewBag.ddlApprovalStatus = cm.GetListApproveStatus();
            return View();
        }

        [HttpPost]
        public ActionResult _Bankrupcy(string mode, string code)
        {
            List<SP_SEARCH_BANKRUPTCY_BY_DOC_Result> model = new List<SP_SEARCH_BANKRUPTCY_BY_DOC_Result>();

            try
            {
                if (mode == Constants.Mode.Edit)
                {
                    ViewBag.Mode = Constants.Mode.Edit;
                }
                model = db.SP_SEARCH_BANKRUPTCY_BY_DOC(code).ToList();

                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult _Fraud(string mode, string code)
        {
            List<SP_SEARCH_FRAUD_BY_DOC_Result> model = new List<SP_SEARCH_FRAUD_BY_DOC_Result>();

            try
            {
                if (mode == Constants.Mode.Edit)
                {
                    ViewBag.Mode = Constants.Mode.Edit;
                }
                model = db.SP_SEARCH_FRAUD_BY_DOC(code).ToList();
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }



        #region BankrupcyFraud

        [HttpPost]
        public ActionResult _SearchBankAndFraud(string docNo, string type, string approveStatus, DateTime? createDateFrom, DateTime? createDateTo, string admin)
        {
            List<SP_SEARCH_BANKRUPTCY_FRAUD_Result> model = new List<SP_SEARCH_BANKRUPTCY_FRAUD_Result>();
            string adminCode = "";
            string roleCode = "";

            try
            {
                cm.SetDataLevel(ref adminCode, ref roleCode);
                model = db.SP_SEARCH_BANKRUPTCY_FRAUD(docNo, approveStatus, createDateFrom, createDateTo, type, admin, roleCode).ToList();


                return PartialView(model);

            }
            catch (Exception e)
            {

                throw;
            }


        }

        #region Upload && Download
        [HttpPost]
        public ActionResult _Upload()
        {
            return PartialView();
        }

        #region Fruad
        [HttpPost]
        public ActionResult ImportExcelFraud()
        {
            List<WriteOffUploadViewModel> model = new List<WriteOffUploadViewModel>();
            HttpPostedFileBase files = null;

            string message = Constants.Msg.UploadCompleted;
            string result = Constants.Result.False;

            var dt = new DataTable();
            var msg = "";

            try
            {
                if (Request.Files.Count > 0)
                {
                    files = Request.Files[0];

                    //--- Validate File Type
                    var LastNameExcel = files.FileName.Split('.').Last();
                    if (!cm.CheckExcekFile(LastNameExcel))
                    {
                        msg = "Template Not Correct";

                        return Json(new { message = msg, result = result });
                    }
                    else
                    {
                        var fileName = cm.UserLogin + "_" + cm.SystemDate.ToString("yyyyMMddHHmmss") + "_" + "Fraud" + "." + LastNameExcel;
                        var savePath = Path.Combine(Server.MapPath("~/TempFiles"), fileName);
                        files.SaveAs(savePath);
                        ValidateFileFraud(savePath, ref model);
                        var complete = model.Count(x => x.Flag == 0);
                        var total = model.Count();
                        ViewBag.Error = model.Count(x => x.Flag == 1);
                        ViewBag.Complete = complete;
                        ViewBag.Total = total;
                        ViewBag.ModeSave = Constants.Result.False;
                        if (complete == total && total > 0)
                        {
                            message = Constants.Msg.UploadCompleted;
                            result = Constants.Result.True;
                            ViewBag.ModeSave = Constants.Result.True;

                        }
                        System.IO.File.Delete(savePath);

                        //ViewBag.model = model.OrderBy(x => x.).ToList();


                    }

                    return PartialView("_UploadShowFraud", model);
                }
                else
                {
                    msg = "File not found";
                    return Json(new { message = msg });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
            finally
            {
                dt.Dispose();
            }


        }

        //--- Validate Header Name   
        private string ValidateFileFraud(string pathFile, ref List<WriteOffUploadViewModel> model)
        {
            string result = Constants.Result.False;
            DataTable dt = new DataTable();
            string msg = "";
            try
            {
                dt = cm.ReadExcel(pathFile);

                //Check Columns
                if (!(dt.Columns[0].ColumnName.Equals("UploadType") &&
                dt.Columns[1].ColumnName.Equals("ContractNo")))
                {
                    msg = "Invalid column name";

                }

                if (msg == "")
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        WriteOffUploadViewModel forAdd = new WriteOffUploadViewModel();

                        forAdd.UploadType = dr[0].ToString();
                        forAdd.ContractNo = dr[1].ToString();

                        model.Add(forAdd);
                    }
                    //Check Blank
                    foreach (var m in model)
                    {
                        int e = 0;

                        if (m.UploadType == "")
                        {
                            e = 1;
                            m.Flag = 1;
                        }
                        else if (m.ContractNo == "")
                        {
                            m.Flag = 1;
                            e = 1;
                        }


                        if (e == 1)
                        {
                            m.MsgError = Constants.Msg.Blank;
                            msg = Constants.Msg.Blank;
                        }
                    }
                    //Check Contract Not Exist.
                    foreach (var m in model)
                    {
                        int a;
                        a = db.S_CONTRACT.Count(x => x.CONTRACT_NO == m.ContractNo);

                        if (a == 0)
                        {
                            m.Flag = 1;
                            if (m.MsgError != null)
                            {
                                m.MsgError = m.MsgError;
                            }
                            else
                            {
                                m.MsgError = Constants.Msg.CheckContract;
                            }
                            msg = Constants.Msg.CheckContract;
                        }
                    }

                }


                return msg;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void SetDataFraud(List<WriteOffUploadViewModel> model)
        {
            T_BANKRUPTCY_FRAUD_H bankruptcyFraudH = new T_BANKRUPTCY_FRAUD_H();
            string mode = Constants.Mode.Add;
            try
            {

                bankruptcyFraudH.BF_DOC_ID = db.SP_GEN_BANKRUPTCY_FRAUD__ID(Constants.FormatGenDocID.DocID).ToList().First();
                bankruptcyFraudH.BF_DATE = cm.SystemDate;
                bankruptcyFraudH.BF_TYPE = Constants.BankFraud_Type.Fraud;
                bankruptcyFraudH.BF_CREATE_DATE = cm.SystemDate;
                bankruptcyFraudH.BF_CREATE_BY = cm.UserLogin;
                bankruptcyFraudH.BF_UPDATE_BY = cm.UserLogin;
                bankruptcyFraudH.BF_UPDATE_DATE = cm.SystemDate;
                bankruptcyFraudH.BF_APPROVE_FLAG = Constants.ApproveStatus.Pending;
                bankruptcyFraudH.BF_STATUS = Constants.Status.Active;

                db.T_BANKRUPTCY_FRAUD_H.Add(bankruptcyFraudH);

                foreach (var m in model)
                {
                    T_BANKRUPTCY_FRAUD_D bankruptcyFraudD = new T_BANKRUPTCY_FRAUD_D();
                    bankruptcyFraudD.BFD_HID = bankruptcyFraudH.BF_DOC_ID;
                    bankruptcyFraudD.BFD_CONTRACT_NO = m.ContractNo;
                    bankruptcyFraudD.BFD_CREATE_BY = cm.UserLogin;
                    bankruptcyFraudD.BFD_CREATE_DATE = cm.SystemDate;
                    bankruptcyFraudD.BFD_UPDATE_BY = cm.UserLogin;
                    bankruptcyFraudD.BFD_UPDATE_DATE = cm.SystemDate;
                    bankruptcyFraudD.BFD_STATUS = Constants.Status.Active;

                    db.T_BANKRUPTCY_FRAUD_D.Add(bankruptcyFraudD);

                }
                cm.InsertLog(db, mode, "FraudExcel", Constants.ProgramCode.BankruptcyFraud);
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult SaveFraudUpload(List<WriteOffUploadViewModel> model)
        {

            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;
            try
            {
                if (!model.Count().Equals(0))
                {
                    SetDataFraud(model);
                    result = Constants.Result.True;
                }


                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        public Common.ExcelResult GetFraudFile()
        {
            return new Common.ExcelResult
            {
                FileName =
                "FraudFormatTemplate" + "_" + cm.SystemDate.ToString("yyyyMMddHHmmss") + ".xls",
                Path = Constants.UrlAction.PathDownloadTremplateFraud
            };
        }
        #endregion

        #region Bank
        [HttpPost]
        public ActionResult ImportExcelBank()
        {
            List<WriteOffUploadViewModel> model = new List<WriteOffUploadViewModel>();
            HttpPostedFileBase files = null;

            string message = Constants.Msg.UploadIncompleted;
            string result = Constants.Result.False;

            var dt = new DataTable();
            var msg = "";

            try
            {
                if (Request.Files.Count > 0)
                {
                    files = Request.Files[0];

                    //--- Validate File Type
                    var LastNameExcel = files.FileName.Split('.').Last();
                    if (!cm.CheckExcekFile(LastNameExcel))
                    {
                        msg = "Template Not Correct";

                        return Json(new { message = msg, result = result });
                    }
                    else
                    {
                        var fileName = cm.UserLogin + "_" + cm.SystemDate.ToString("yyyyMMddHHmmss") + "_" + "Bankrupcy" + "." + LastNameExcel;
                        var savePath = Path.Combine(Server.MapPath("~/TempFiles"), fileName);
                        files.SaveAs(savePath);
                        ValidateFileBank(savePath, ref model);
                        var complete = model.Count(x => x.Flag == 0);
                        var total = model.Count();
                        ViewBag.Error = model.Count(x => x.Flag == 1);
                        ViewBag.Complete = complete;
                        ViewBag.Total = total;
                        ViewBag.ModeSave = Constants.Result.False;
                        if (complete == total && total > 0)
                        {
                            message = Constants.Msg.UploadCompleted;
                            result = Constants.Result.True;
                            ViewBag.ModeSave = Constants.Result.True;

                        }
                        System.IO.File.Delete(savePath);

                        //ViewBag.model = model.OrderBy(x => x.).ToList();


                    }

                    return PartialView("_UploadShowBank", model);
                }
                else
                {
                    msg = "File not found";
                    return Json(new { message = msg });
                }
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = "DateTime Format Not Correct" }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                dt.Dispose();
            }


        }

        private string ValidateFileBank(string pathFile, ref List<WriteOffUploadViewModel> model)
        {
            string result = Constants.Result.False;
            DataTable dt = new DataTable();
            string msg = "";
            try
            {
                dt = cm.ReadExcel(pathFile);

                //Check Columns

                if (!(dt.Columns[9].ColumnName.Equals("เลขที่บัตรประชาชนจำเลย") &&
                dt.Columns[10].ColumnName.Equals("ชื่อ") &&
                dt.Columns[11].ColumnName.Equals("นามสกุล") &&
                dt.Columns[13].ColumnName.Equals("ชื่อศาล") &&
                dt.Columns[15].ColumnName.Equals("หมายเลขคดีแดง") &&
                dt.Columns[16].ColumnName.Equals("ชื่อโจทก์") &&
                dt.Columns[17].ColumnName.Equals("ชื่อจำเลย") &&
                dt.Columns[18].ColumnName.Equals("วันที่ศาลมีคำสั่งพิทักษ์ทรัพย์เด็ดขาด") &&
                dt.Columns[22].ColumnName.Equals("วันที่ครบกำหนดยื่นคำขอรับชำระหนี้") &&
                dt.Columns[23].ColumnName.Equals("วันที่ศาลมีคำสั่งเพิกถอนพิทักษ์ทรัพย์เด็ดขาด") &&
                dt.Columns[27].ColumnName.Equals("วันที่ประนอมหนี้ก่อนล้มละลาย") &&
                dt.Columns[31].ColumnName.Equals("วันที่ยกเลิกประนอมหนี้ก่อนล้มและพิพากษาให้ล้มละลาย") &&
                dt.Columns[35].ColumnName.Equals("วันที่ศาลมีคำสั่งพิพากษาให้ล้มละลาย") &&
                dt.Columns[39].ColumnName.Equals("วันที่ประนอมหนี้หลังล้มละลาย") &&
                dt.Columns[43].ColumnName.Equals("วันที่ยกเลิกประนอมหนี้หลังล้มและพิพากษาให้ล้ม") &&
                dt.Columns[47].ColumnName.Equals("วันที่ครบกำหนดยื่นคำขอรับชำระหนี้หลังล้ม") &&
                dt.Columns[48].ColumnName.Equals("วันที่ยกเลิกการล้มละลาย") &&
                dt.Columns[52].ColumnName.Equals("วันที่ปลดจากการเป็นบุคคลล้มละลาย") &&
                dt.Columns[57].ColumnName.Equals("วันที่ยกฟ้อง") &&
                dt.Columns[58].ColumnName.Equals("วันที่จำหน่ายคดี") &&
                dt.Columns[59].ColumnName.Equals("วันที่ฟ้อง")
                ))
                {
                    msg = "Invalid column name";

                }

                if (msg == "")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        WriteOffUploadViewModel forAdd = new WriteOffUploadViewModel();
                        forAdd.UploadType = "Bankruptcy";
                        forAdd.CitizenId = dr[9].ToString();
                        forAdd.Firstname = dr[10].ToString();
                        forAdd.Lastname = dr[11].ToString();
                        forAdd.Courtname = dr[13].ToString();
                        forAdd.Redcode = dr[15].ToString();
                        forAdd.ComplainantName = dr[16].ToString();
                        forAdd.DefendantName = dr[17].ToString();
                        if (!cm.IsNullOrEmpty((dr[18])))
                            forAdd.ReceivingOrderDate = DateTime.ParseExact(dr[18].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[22])))
                            forAdd.SubmitDueDate = DateTime.ParseExact(dr[22].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[23])))
                            forAdd.CancelReceivingOrderDate = DateTime.ParseExact(dr[23].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[27])))
                            forAdd.CompromiseBeforeDate = DateTime.ParseExact(dr[27].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[31])))
                            forAdd.CancelCompromiseBeforeDate = DateTime.ParseExact(dr[31].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[35])))
                            forAdd.OrderBankrupcyDate = DateTime.ParseExact(dr[35].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[39])))
                            forAdd.CompromiseAfterDate = DateTime.ParseExact(dr[39].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[43])))
                            forAdd.CancelCompromiseAfterDate = DateTime.ParseExact(dr[43].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[47])))
                            forAdd.SubmitAfterDueDate = DateTime.ParseExact(dr[47].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[48])))
                            forAdd.CancelBankrupcyDate = DateTime.ParseExact(dr[48].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[52])))
                            forAdd.DischangedBankrupcyDate = DateTime.ParseExact(dr[52].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[57])))
                            forAdd.DismissalDate = DateTime.ParseExact(dr[57].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[58])))
                            forAdd.DisposeCaseDate = DateTime.ParseExact(dr[58].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        if (!cm.IsNullOrEmpty((dr[59])))
                            forAdd.FilingDate = DateTime.ParseExact(dr[59].ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));

                        model.Add(forAdd);
                    }

                    foreach (var m in model)
                    {
                        int e = 0;

                        if (m.UploadType == "")
                        {
                            m.Flag = 1;
                            e = 1;
                        }

                        if (m.CitizenId == "")
                        {
                            m.Flag = 1;
                            e = 1;
                        }
                        if (e == 1)
                        {
                            m.MsgError = Constants.Msg.Blank;
                            msg = Constants.Msg.Blank;
                        }
                    }

                    //Check CitizenID Not Exist.
                    foreach (var m in model)
                    {
                        int a;
                        a = db.S_CUSTOMER_DETAIL.Count(x => x.ID_NUMBER == m.CitizenId);

                        if (a == 0)
                        {
                            m.Flag = 1;
                            if (m.MsgError != null)
                            {
                                m.MsgError = m.MsgError;
                            }
                            else
                            {
                                m.MsgError = Constants.Msg.CheckCitizenId;
                            }
                            msg = Constants.Msg.CheckCitizenId;
                        }
                    }

                }


                return msg;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public void SetDataBank(List<WriteOffUploadViewModel> model)
        {
            T_BANKRUPTCY_FRAUD_H bankruptcyFraudH = new T_BANKRUPTCY_FRAUD_H();
            string mode = Constants.Mode.Add;
            try
            {
                //var type = model.Select(x => x.UploadType).First();
                bankruptcyFraudH.BF_DOC_ID = db.SP_GEN_BANKRUPTCY_FRAUD__ID(Constants.FormatGenDocID.DocID).ToList().First();
                bankruptcyFraudH.BF_DATE = cm.SystemDate;
                bankruptcyFraudH.BF_TYPE = Constants.BankFraud_Type.Bankruptcy;
                bankruptcyFraudH.BF_CREATE_DATE = cm.SystemDate;
                bankruptcyFraudH.BF_CREATE_BY = cm.UserLogin;
                bankruptcyFraudH.BF_UPDATE_BY = cm.UserLogin;
                bankruptcyFraudH.BF_UPDATE_DATE = cm.SystemDate;
                bankruptcyFraudH.BF_APPROVE_FLAG = Constants.ApproveStatus.Pending;
                bankruptcyFraudH.BF_STATUS = Constants.Status.Active;

                db.T_BANKRUPTCY_FRAUD_H.Add(bankruptcyFraudH);
                //DateTime? dtx = null;
                foreach (var m in model)
                {
                    T_BANKRUPTCY_FRAUD_D bankruptcyFraudD = new T_BANKRUPTCY_FRAUD_D();
                    bankruptcyFraudD.BFD_HID = bankruptcyFraudH.BF_DOC_ID;
                    bankruptcyFraudD.BFD_CARD_NO = m.CitizenId;
                    bankruptcyFraudD.BFD_CREATE_BY = cm.UserLogin;
                    bankruptcyFraudD.BFD_CREATE_DATE = cm.SystemDate;
                    bankruptcyFraudD.BFD_UPDATE_BY = cm.UserLogin;
                    bankruptcyFraudD.BFD_UPDATE_DATE = cm.SystemDate;
                    bankruptcyFraudD.BFD_STATUS = Constants.Status.Active;
                    bankruptcyFraudD.BFD_FIRSTNAME = m.Firstname;
                    bankruptcyFraudD.BFD_LASTNAME = m.Lastname;
                    bankruptcyFraudD.BFD_COURTNAME = m.Courtname;
                    bankruptcyFraudD.BFD_REDCODE = m.Redcode;
                    bankruptcyFraudD.BFD_PLAINTIFF_NAME = m.ComplainantName;
                    bankruptcyFraudD.BFD_DEFENDANT_NAME = m.DefendantName;
                    bankruptcyFraudD.BFD_RECEIVING_ORDER_DATE = m.ReceivingOrderDate;
                    bankruptcyFraudD.BFD_SUBMIT_DUE_DATE = m.SubmitDueDate;
                    bankruptcyFraudD.BFD_CANCEL_RECEIVING_ORDER_DATE = m.CancelReceivingOrderDate;
                    bankruptcyFraudD.BFD_COMPROMISE_BEFORE_DATE = m.CompromiseBeforeDate;
                    bankruptcyFraudD.BFD_CANCEL_COMPROMISE_BAFORE_DATE = m.CancelCompromiseBeforeDate;
                    bankruptcyFraudD.BFD_ORDER_BANKRUPCTY_DATE = m.OrderBankrupcyDate;
                    bankruptcyFraudD.BFD_COMPROMISE_AFTER_DATE = m.CompromiseAfterDate;
                    bankruptcyFraudD.BFD_CANCEL_COMPROMISE_AFTER_DATE = m.CancelCompromiseAfterDate;
                    bankruptcyFraudD.BFD_SUBMIT_AFTER_DUE_DATE = m.SubmitAfterDueDate;
                    bankruptcyFraudD.BFD_CANCEL_BANKRUPTCY_DATE = m.CancelBankrupcyDate;
                    bankruptcyFraudD.BFD_DISCHANGED_BANKRUPTCY_DATE = m.DischangedBankrupcyDate;
                    bankruptcyFraudD.BFD_DISMISSAL_DATE = m.DismissalDate;
                    bankruptcyFraudD.BFD_DISPOSE_CASE_DATE = m.DisposeCaseDate;
                    bankruptcyFraudD.BFD_FILING_DATE = m.FilingDate;

                    db.T_BANKRUPTCY_FRAUD_D.Add(bankruptcyFraudD);

                }
                cm.InsertLog(db, mode, "BankruptcyExcel", Constants.ProgramCode.BankruptcyFraud);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult SaveBankUpload(List<WriteOffUploadViewModel> model)
        {

            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;
            try
            {
                if (!model.Count().Equals(0))
                {
                    SetDataBank(model);
                    result = Constants.Result.True;

                }


                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
        #endregion

        #region Select2
        public ActionResult SearchDoc(string q)
        {
            try
            {
                var m = db.T_BANKRUPTCY_FRAUD_H
               .Where(x => x.BF_DOC_ID.Contains(q)).Select(x => new { x.BF_DOC_ID }).Distinct();
                return Json(m.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Approve && Reject

        public ActionResult Approve(List<DocViewModel> model, string txtRemark)
        {

            string result = Constants.Result.False;
            string message = Constants.Msg.SaveFail;
            string mode = Constants.Mode.Approved;
            try
            {

                foreach (var m in model)
                {
                    ViewBag.ID = m.DocNo;
                    var mm = db.T_BANKRUPTCY_FRAUD_H.Find(m.DocNo);
                    var xx = db.T_BANKRUPTCY_FRAUD_D.Where(x => x.BFD_HID == m.DocNo && (x.BFD_CARD_NO == m.CitizenId || x.BFD_CONTRACT_NO == m.ContractNo)).ToList();
                    foreach (var x in xx)
                    {
                        x.BFD_REMARK = m.Remark;
                    }

                    mm.BF_APPROVE_BY = cm.UserLogin;
                    mm.BF_APPROVE_DATE = cm.SystemDate;
                    mm.BF_APPROVE_FLAG = Constants.ApproveStatus.Approved;

                }

                var id = ViewBag.ID;
                cm.InsertLog(db, mode, id, Constants.ProgramCode.SuggesttoWriteoff);
                db.SaveChanges();
                return Json(new { result = Constants.Result.True, message = Constants.Msg.SaveSucc }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Reject(List<DocViewModel> model)
        {

            string result = Constants.Result.False;
            string message = Constants.Msg.SaveFail;
            string mode = Constants.Mode.Reject;
            try
            {

                foreach (var m in model)
                {
                    ViewBag.ID = m.DocNo;
                    var mm = db.T_BANKRUPTCY_FRAUD_H.Find(m.DocNo);
                    var xx = db.T_BANKRUPTCY_FRAUD_D.Where(x => x.BFD_HID == m.DocNo && (x.BFD_CARD_NO == m.CitizenId || x.BFD_CONTRACT_NO == m.ContractNo)).ToList();
                    foreach (var x in xx)
                    {
                        x.BFD_REMARK = m.Remark;
                    }
                    mm.BF_APPROVE_BY = cm.UserLogin;
                    mm.BF_APPROVE_DATE = cm.SystemDate;
                    mm.BF_APPROVE_FLAG = Constants.ApproveStatus.Rejected;
                    mm.BF_STATUS = Constants.Status.Inactive;
                }

                var id = ViewBag.ID;
                cm.InsertLog(db, mode, id, Constants.ProgramCode.SuggesttoWriteoff);
                db.SaveChanges();
                return Json(new { result = Constants.Result.True, message = Constants.Msg.SaveSucc }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
        #endregion
    }
}