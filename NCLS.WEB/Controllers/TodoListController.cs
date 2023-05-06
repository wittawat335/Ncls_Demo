using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.App_Start;
using NCLS.WEB.Entities;
using NCLS.WEB.Models.ViewModels.TodoList;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    [SessionTimeout]
    public class TodoListController : BaseController
    {
        // GET: /TodoList/
        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();
        public ActionResult Index(string id = "0")
        {
            TodoListSearch model = new TodoListSearch();
            try
            {
                model.DefaultCase = id;
                model.AdminList = cm.GetListUserByRole();
                model.OAList = cm.GetListOA();
                model.LegalCaseList = cm.GetListLegalCaseByGroup();
                model.TrafficList = GetListTraffic();
                model.LegalStatusList = cm.GetListLegalStatusByCase("");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult _Search(string refNo, string contractNo, string custCode, string caseCode, string cuseStatus, string trafficCode, string adminCode, string oaCode, DateTime? adminDateStart, DateTime? adminDateEnd, DateTime? oaDateStart, DateTime? oaDateEnd, string succStatus, string searchDefault = "0")
        {
            string roleCode = "";
            List<SP_SEARCH_TODOLIST_Result> model = new List<SP_SEARCH_TODOLIST_Result>();
            DateTime dt = new DateTime();

            try
            {

                cm.SetDataLevel(ref adminCode, ref roleCode);

                if (adminDateStart > adminDateEnd)
                {
                    return Json(new { result = Constants.Result.False, msg = Constants.Msg.AdminDateFail }, JsonRequestBehavior.AllowGet);
                }
                else if (oaDateStart > oaDateEnd)
                {
                    return Json(new { result = Constants.Result.False, msg = Constants.Msg.OADateFail }, JsonRequestBehavior.AllowGet);
                }

                model = db.SP_SEARCH_TODOLIST(refNo, contractNo, custCode, caseCode, cuseStatus,
                     trafficCode, adminCode, oaCode, adminDateStart, adminDateEnd,
                     oaDateStart, oaDateEnd, succStatus, roleCode, searchDefault).ToList();

                //if (searchDefault.Equals("0"))
                //{
                //    model = db.SP_SEARCH_TODOLIST(refNo, contractNo, custCode, caseCode, cuseStatus,
                //      trafficCode, adminCode, oaCode, adminDateStart, adminDateEnd,
                //      oaDateStart, oaDateEnd, succStatus, roleCode).ToList();
                //}
                //else if (searchDefault.Equals("1"))
                //{
                //    model = model = db.SP_SEARCH_TODOLIST(refNo, contractNo, custCode, caseCode, cuseStatus,
                //         trafficCode, adminCode, oaCode, adminDateStart, adminDateEnd,
                //         oaDateStart, oaDateEnd, succStatus, roleCode).ToList();
                //}
                //if (searchDefault.Equals("2"))
                //{
                //    if (adminDateStart > adminDateEnd)
                //    {
                //        return Json(new { result = Constants.Result.False, msg = Constants.Msg.AdminDateFail }, JsonRequestBehavior.AllowGet);
                //    }
                //    else if (oaDateStart > oaDateEnd)
                //    {
                //        return Json(new { result = Constants.Result.False, msg = Constants.Msg.OADateFail }, JsonRequestBehavior.AllowGet);
                //    }

                //    model = db.SP_SEARCH_TODOLIST(refNo, contractNo, custCode, caseCode, cuseStatus,
                //         trafficCode, adminCode, oaCode, adminDateStart, adminDateEnd,
                //         oaDateStart, oaDateEnd, succStatus, roleCode).ToList();
                //}


                Session[Constants.SessionTempName.TodolistExport] = model;

                return PartialView(model);

            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public ActionResult _Details(string refNo)
        {

            TodoListMaintenance model = new TodoListMaintenance();
            try
            {
                var job = db.SP_SEARCH_JOB(refNo).FirstOrDefault(); ;

                model.RefNo = refNo;
                model.CaseCode = job.JOB_CASE_CODE;
                model.ContractNo = job.JOB_CONTRACT_NO;
                model.DocFlag = job.JOB_DOC_FLAG == "1" ? true : false;
                model.OACode = job.JOB_OA_CODE;
                model.OADummy = job.JOB_OA_CODE;
                var doc = db.SP_SEARCH_DOCUMENT_BY_REF(refNo, model.CaseCode);

                foreach (var x in doc)
                {
                    var item = new Document();
                    item.DocJobId = model.RefNo;
                    item.DocContractNo = model.ContractNo;
                    item.DocCode = x.DOC_CODE;
                    item.DocName = x.MASTER_NAME_TH;
                    item.DocSuccFlag = x.TDOC_SUCC_FLAG == "1" ? true : false;
                    item.DocFailFlag = x.TDOC_FAIL_FLAG == "1" ? true : false;
                    item.DocReasonCode = x.TDOC_REASON_CODE;
                    item.DocRemark = x.TDOC_REMARK;
                    item.DocReq = x.DOC_REQ_FLAG == "1" ? true : false;
                    model.DocumentList.Add(item);
                }

                model.OAList = cm.GetListOA();
                model.ReasonList = cm.GetListByMasterType(Constants.MasterType.ReasonType);



                return PartialView(model);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult _SendOA(string refNo)
        {

            TodoListMaintenance model = new TodoListMaintenance();
            try
            {
                var job = db.SP_SEARCH_JOB(refNo).FirstOrDefault(); ;

                model.RefNo = refNo;
                model.CaseCode = job.JOB_CASE_CODE;
                model.ContractNo = job.JOB_CONTRACT_NO;
                model.DocFlag = job.JOB_DOC_FLAG == "1" ? true : false;
                model.OACode = job.JOB_OA_CODE;
                model.OADummy = job.JOB_OA_CODE;
                var doc = db.SP_SEARCH_DOCUMENT_BY_REF(refNo, model.CaseCode);

                foreach (var x in doc)
                {
                    var item = new Document();
                    item.DocJobId = model.RefNo;
                    item.DocContractNo = model.ContractNo;
                    item.DocCode = x.DOC_CODE;
                    item.DocName = x.MASTER_NAME_TH;
                    item.DocSuccFlag = x.TDOC_SUCC_FLAG == "1" ? true : false;
                    item.DocFailFlag = x.TDOC_FAIL_FLAG == "1" ? true : false;
                    item.DocReasonCode = x.TDOC_REASON_CODE;
                    item.DocRemark = x.TDOC_REMARK;
                    item.DocReq = x.DOC_REQ_FLAG == "1" ? true : false;
                    model.DocumentList.Add(item);
                }

                model.OAList = cm.GetListOA();
                model.ReasonList = cm.GetListByMasterType(Constants.MasterType.ReasonType);



                return PartialView(model);

            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public ActionResult Save(List<Document> Doc, string txtRefNo, string ddlOACode, string txtCaseCode)//, bool? chSendOA
        {
            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;

            try
            {

                SetData(Doc);
                // SetData(Doc,txtRefNo, chSendOA.HasValue, ddlOACode, txtCaseCode);
                SetData(Doc, txtRefNo, ddlOACode, txtCaseCode);
                result = Constants.Result.True;
                message = Constants.Msg.SaveSucc;

                if (result.Equals(Constants.Result.True))
                {
                    cm.InsertLog(db, Constants.Mode.Edit, txtRefNo, Constants.ProgramCode.TodoList);
                    db.SaveChanges();

                }

                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }


        }

        public bool CheckDocument(List<Document> Doc)
        {
            bool result = true;
            try
            {
                foreach (var x in Doc)
                {
                    if (x.DocReq)
                    {
                        if (!x.DocSuccFlag)
                        {
                            result = false;
                            break;
                        }

                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SetData(List<Document> doc)
        {
            try
            {

                foreach (var x in doc)
                {
                    var xx = db.T_DOCUMENT.Find(x.DocJobId, x.DocCode);
                    if (xx != null)
                    {
                        db.T_DOCUMENT.Remove(xx);
                    }
                    T_DOCUMENT d = new T_DOCUMENT();
                    d.TDOC_JOB_ID = x.DocJobId;
                    d.TDOC_CONTRACT_NO = x.DocContractNo;
                    d.TDOC_DOC_CODE = x.DocCode;
                    d.TDOC_SUCC_FLAG = x.DocSuccFlag == true ? "1" : "0";
                    d.TDOC_FAIL_FLAG = x.DocFailFlag == true ? "1" : "0";
                    d.TDOC_REASON_CODE = x.DocReasonCode;
                    d.TDOC_REMARK = x.DocRemark;
                    d.TDOC_CREATE_BY = cm.UserLogin;
                    d.TDOC_CRREATE_DATE = cm.SystemDate;
                    d.TDOC_UPDATE_BY = cm.UserLogin;
                    d.TDOC_UPDATE_DATE = cm.SystemDate;
                    d.TDOC_STATUS = Constants.Status.Active;
                    db.T_DOCUMENT.Add(d);
                }
            }

            catch (Exception)
            {
                throw;
            }

        }
        public void SetData(List<Document> Doc, string refNo, string oaCode, string caseCode)//bool sendOA
        {
            try
            {

                var x = db.M_LEGAL_CASE.Find(caseCode);

                if (x.CASE_TABLE.Equals(Constants.TableJob.T_JOB_LEGAL))
                {
                    var legal = db.T_JOB_LEGAL.Find(refNo);
                    legal.JOB_OA_CODE = oaCode;
                    legal.JOB_ASSIGN_OA_DATE = cm.SystemDate;
                    legal.JOB_DOC_FLAG = CheckDocument(Doc) == true ? "1" : "0";
                    legal.JOB_UPDATE_BY = cm.UserLogin;
                    legal.JOB_UPDATE_DATE = cm.SystemDate;
                }
                else if (x.CASE_TABLE.Equals(Constants.TableJob.T_JOB_REPO))
                {
                    var repo = db.T_JOB_REPO.Find(refNo);
                    repo.JOB_DOC_FLAG = CheckDocument(Doc) == true ? "1" : "0";
                    repo.JOB_OA_CODE = oaCode;
                    repo.JOB_ASSIGN_OA_DATE = cm.SystemDate;
                    repo.JOB_UPDATE_BY = cm.UserLogin;
                    repo.JOB_UPDATE_DATE = cm.SystemDate;
                }


            }

            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult searchRefNo(string q)
        {

            try
            {
                var m = db.SP_SEARCH_JOB(q);

                return Json(m.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ActionResult searchCustomer(string q)
        {
            try
            {
                var m = db.SP_SEARCH_CUSTOMER(q);
                return Json(m.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult _ddlStatus(string legalCase)
        {
            try
            {

                var m = cm.GetListLegalStatusByCase(legalCase).ToList() ?? new List<SP_SEARCH_STATUS_BY_CASE_Result>();


                return PartialView(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TrafficType> GetListTraffic()
        {
            List<TrafficType> list = new List<TrafficType>();
            TrafficType item = new TrafficType();
            try
            {

                item.CODE = Constants.Color.GreenCode;
                item.TEXT = Constants.Color.Green;
                list.Add(item);

                item = new TrafficType();
                item.CODE = Constants.Color.YellowCode;
                item.TEXT = Constants.Color.Yellow;
                list.Add(item);

                item = new TrafficType();
                item.CODE = Constants.Color.RedCode;
                item.TEXT = Constants.Color.Red;
                list.Add(item);


                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult _CancelLegal()
        {
            string roleCode = "", adminCode = "";
            try
            {
                roleCode = cm.UserRole;
                if (cm.UserDataLevel == "3" || cm.UserDataLevel == "2")
                {
                    adminCode = "";
                }
                else
                {
                    adminCode = cm.UserLogin;
                }
                cm.SetDataLevel(ref adminCode, ref roleCode);
                var model = db.SP_SEARCH_CANCEL_JOB_LEGAL(adminCode, roleCode).ToList();

                return PartialView(model);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult _CancelRepo()
        {
            string roleCode = "", adminCode = "";
            try
            {
                roleCode = cm.UserRole;
                if (cm.UserDataLevel == "3" || cm.UserDataLevel == "2")
                {
                    adminCode = "";
                }
                else
                {
                    adminCode = cm.UserLogin;
                }
                cm.SetDataLevel(ref adminCode, ref roleCode);
                var model = db.SP_SEARCH_CANCEL_JOB_REPO(adminCode, roleCode).ToList();

                return PartialView(model);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult SaveCancelLegal(List<UseCheckCancel> Item)
        {
            string result = Constants.Result.False;
            string msg = Constants.Msg.SaveFail;
            try
            {
                var temp = Item.Where(x => x.CheckCancel == true).ToList();

                if (temp.Count > 0)
                {
                    foreach (var m in temp)
                    {
                        T_JOB_LEGAL job = db.T_JOB_LEGAL.FirstOrDefault(x => x.JOB_ID == m.JOB_ID
                                           && x.JOB_STATUS == Constants.Status.Active);
                        job.JOB_STATUS = Constants.Status.Inactive;
                        job.JOB_UPDATE_DATE = cm.SystemDate;
                        job.JOB_UPDATE_BY = cm.UserLogin;
                    }
                    db.SaveChanges();
                    result = Constants.Result.True;
                    msg = Constants.Msg.SaveSucc;
                }
                else
                {
                    result = Constants.Result.False;
                    msg = Constants.Msg.DataBlank;

                }
                return Json(new { result = result, msg = msg }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { result = result, msg = msg }, JsonRequestBehavior.AllowGet);
                throw;

            }
        }

        [HttpPost]
        public ActionResult SaveCancelRepo(List<UseCheckCancel> Item)
        {
            string result = Constants.Result.False;
            string msg = Constants.Msg.SaveFail;
            try
            {
                var temp = Item.Where(x => x.CheckCancel == true).ToList();

                if (temp.Count > 0)
                {
                    foreach (var m in temp)
                    {
                        T_JOB_REPO job = db.T_JOB_REPO.FirstOrDefault(x => x.JOB_ID == m.JOB_ID
                                           && x.JOB_STATUS == Constants.Status.Active);
                        job.JOB_STATUS = Constants.Status.Inactive;
                        job.JOB_REPO_STATUS = Constants.RepoStatus.Re03;
                        job.JOB_UPDATE_DATE = cm.SystemDate;
                        job.JOB_UPDATE_BY = cm.UserLogin;
                    }
                    db.SaveChanges();
                    result = Constants.Result.True;
                    msg = Constants.Msg.SaveSucc;
                }
                else
                {
                    result = Constants.Result.False;
                    msg = Constants.Msg.DataBlank;

                }
                return Json(new { result = result, msg = msg }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { result = result, msg = msg }, JsonRequestBehavior.AllowGet);
                throw;

            }
        }

        public FileResult DownloadFile()
        {
            DataTable dt = cm.ToDataTable((List<SP_SEARCH_TODOLIST_Result>)Session[Constants.SessionTempName.TodolistExport]);

            //Ex
            //dt.Columns.Remove("XX1");
            //dt.Columns["XX2"].ColumnName = "Re2";

            dt.Columns.Remove("JOB_CASE_CODE");
            dt.Columns.Remove("JOB_CASE_COLOR");
            dt.Columns.Remove("JOB_LEGAL_STATUS");
            dt.Columns.Remove("JOB_REPO_STATUS");
            dt.Columns.Remove("JOB_CASE_STATUS_COLOR");
            dt.Columns.Remove("JOB_OA_CODE");
            dt.Columns["JOB_CASE_NAME"].ColumnName = "Legal Case";
            dt.Columns["JOB_ID"].ColumnName = "Ref No.";
            dt.Columns["JOB_CONTRACT_NO"].ColumnName = "Contract No/Cheque No";
            dt.Columns["JOB_CUST_NAME"].ColumnName = "Borrower Name";
            dt.Columns["JOB_BRAND"].ColumnName = "Brand";
            dt.Columns["JOB_MODEL"].ColumnName = "Model";
            dt.Columns["JOB_PLATE_NO"].ColumnName = "Plate No";
            dt.Columns["JOB_OS_AMT_COL"].ColumnName = "Outstanding Balance";
            dt.Columns["JOB_OVD_DAY_COL"].ColumnName = "Overdue Days";
            dt.Columns["JOB_ADMIN_NAME"].ColumnName = "Admin";
            dt.Columns["JOB_ASSIGN_ADMIN_DATE"].ColumnName = "Assign Date(Admin)";
            dt.Columns["JOB_OA_NAME"].ColumnName = "Legal OA";
            dt.Columns["JOB_ASSIGN_OA_DATE"].ColumnName = "Assign Date(OA)";
            dt.Columns["JOB_STEP_DATE"].ColumnName = "Step Date";
            dt.Columns["JOB_HANDLE_DAY"].ColumnName = "Handle Day";
            dt.Columns["JOB_DOC_FLAG"].ColumnName = "Document";
            dt.Columns["JOB_LEGAL_STATUS_NAME"].ColumnName = "Legal Status";
            dt.Columns["JOB_REPO_STATUS_NAME"].ColumnName = "Repo Status";

            var fileExt = Constants.Config.TempFileDownloadExcelExt;
            var fileName = "ToDoList_" + cm.SystemDate.ToString("yyyyMMddHHmmss") + fileExt;
            var fileDir = Server.MapPath(Constants.Config.TempFileDownloadPath + fileName);

            return DownloadFileExcel(cm.ExportExcel(dt, fileDir));
        }
    }
}