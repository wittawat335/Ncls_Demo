using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.App_Start;
using NCLS.WEB.Entities;
using NCLS.WEB.Models.ViewModels.AssignRepoOA;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    [SessionTimeout]
    public class AssignRepoOaController : BaseController
    {
        private NCLSEntities db = new NCLSEntities();
        Common cm = new Common();
        //
        // GET: /AssignRepoOa/

        private List<AssignRepoOAViewModel> AssignTemp
        {
            get
            {
                if (Session[Constants.SessionTempName.AssignTempOa] == null)
                {
                    List<AssignRepoOAViewModel> dt = new List<AssignRepoOAViewModel>();
                    Session[Constants.SessionTempName.AssignTempOa] = dt;
                }
                return (List<AssignRepoOAViewModel>)Session[Constants.SessionTempName.AssignTempOa];
            }
            set { Session[Constants.SessionTempName.AssignTempOa] = value; }
        }

        public ActionResult DestroySession()
        {
            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;

            Session[Constants.SessionTempName.AssignTempOa] = null;
            if (Session[Constants.SessionTempName.AssignTempOa] == null)
            {
                result = Constants.Result.True;
            }

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _AssignRepo(List<AssignRepoOAViewModel> model)
        {
            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;
            try
            {
                if (!model.Count().Equals(0))
                {
                    foreach (var x in model.Where(x => x.Flag == true))
                    {
                        var sp = db.SP_SEARCH_ASSIGN_REPO("", x.ContractNo, null, null, "", null, null, "", "", "", "").ToList();
                        foreach (var mx in sp)
                        {
                            var m = new AssignRepoOAViewModel();
                            m.JobId = x.JobId;
                            m.ContractNo = x.ContractNo;
                            m.CitizenId = x.CitizenId;
                            m.AreaCode = x.AreaCode;
                            m.BorrowerName = x.BorrowerName;
                            m.AssignDate = mx.JOB_ASSIGN_OA_DATE;
                            m.OutstandingBalance = x.OutstandingBalance;
                            m.PreviousRepoOa = x.PreviousRepoOa;

                            AssignTemp.Add(m);
                        }

                    }
                    ViewBag.result = Constants.Result.True;
                    ViewBag.AssignDate = db.M_PARAMETER.Where(x => x.PARA_CODE == Constants.ParaCode.ParaX14 && x.PARA_STATUS == Constants.ApproveStatus.Approved)
                 .Select(x => x.PARA_VALUE).First();

                }

                return PartialView();
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult _SendToOA(List<AssignRepoOAViewModel> model)
        {
            List<AssignRepoOAViewModel> temp = new List<AssignRepoOAViewModel>();

            try
            {

                temp = AssignTemp;
                return PartialView(temp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult _Search(string oaCode, string mode, string contractNo, decimal? osStart, decimal? osEnd, string docStatus, string area, DateTime? assignDateForm, DateTime? assignDateTo, string oa)
        {
            List<SP_SEARCH_ASSIGN_REPO_Result> model = new List<SP_SEARCH_ASSIGN_REPO_Result>();
            string adminCode = "";
            string roleCode = "";

            try
            {
                cm.SetDataLevel(ref adminCode, ref roleCode);


                if (assignDateForm > assignDateTo)
                {
                    return Json(new { result = Constants.Result.False, msg = Constants.Msg.IssueDateFail }, JsonRequestBehavior.AllowGet);
                }


                else
                {
                    model = db.SP_SEARCH_ASSIGN_REPO(oaCode, contractNo, osStart, osEnd, docStatus, assignDateForm, assignDateTo, area, oa, adminCode, roleCode).ToList();
                }
                Session[Constants.SessionTempName.AssignRepoExport] = model;

                if (!string.IsNullOrEmpty(mode))
                {
                    ViewBag.mode = Constants.Result.True;
                }

                return PartialView(model);

            }
            catch (Exception e)
            {

                throw;
            }


        }

        [HttpPost]
        public ActionResult _SearchGen(string oaCode, string contractNo, decimal? osStart, decimal? osEnd, string docStatus, string province, DateTime? assignDateForm, DateTime? assignDateTo)
        {
            List<SP_SEARCH_ASSIGN_REPO_GEN_Result> model = new List<SP_SEARCH_ASSIGN_REPO_GEN_Result>();
            string adminCode = "";
            string roleCode = "";

            try
            {
                cm.SetDataLevel(ref adminCode, ref roleCode);


                if (assignDateForm > assignDateTo)
                {
                    return Json(new { result = Constants.Result.False, msg = Constants.Msg.IssueDateFail }, JsonRequestBehavior.AllowGet);
                }


                else
                {
                    model = db.SP_SEARCH_ASSIGN_REPO_GEN(oaCode, contractNo, osStart, osEnd, docStatus, assignDateForm, assignDateTo, province, adminCode, roleCode).ToList();


                }

                return PartialView(model);

            }
            catch (Exception e)
            {

                throw;
            }


        }

        public ActionResult Save(List<AssignRepoOAViewModel> model, string oaCode, DateTime? assignDate, string mode)
        {

            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;
            mode = Constants.Mode.Edit;
            try
            {
                if (!model.Count().Equals(0))
                {
                    foreach (var m in model)
                    {
                        ViewBag.ID = m.JobId;
                    }
                    setData(model, oaCode, assignDate);
                    result = Constants.Result.True;
                    if (result == Constants.Result.True)
                    {
                        cm.InsertLog(db, mode, ViewBag.ID, Constants.ProgramCode.SuggesttoWriteoff);
                        db.SaveChanges();
                        result = Constants.Result.True;
                    }
                }

                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                result = Constants.Result.False;
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        public void setData(List<AssignRepoOAViewModel> model, string oaCode, DateTime? assignDate)
        {
            try
            {

                foreach (var m in model)
                {
                    int expiredDay;
                    var mm = db.T_JOB_REPO.Find(m.JobId);
                    var contract = db.S_CONTRACT.FirstOrDefault(x => x.CONTRACT_NO == m.ContractNo);
                    var oa = db.M_OA.FirstOrDefault(x => x.OA_CODE == oaCode);
                    var oaGroup = db.M_OA_GROUP.FirstOrDefault(x => x.OAGROUP_CODE == oa.OA_GROUP_CODE);
                    if (oa != null)
                    {
                        expiredDay = cm.UnInt32Null(oaGroup.OAGROUP_EXPIRED_DAY);
                    }
                    else
                    {
                        expiredDay = 0;
                    }

                    if (mm.JOB_ID != null)
                    {
                        //CHECK OA is EXist
                        if (!string.IsNullOrEmpty(mm.JOB_OA_CODE) || mm.JOB_OA_CODE != "")
                        {
                            var repoInsert = new T_JOB_REPO();

                            //SET OLD ID IS Inactive
                            if (mm != null)
                            {
                                mm.JOB_STATUS = Constants.Status.Inactive;
                                mm.JOB_UPDATE_BY = cm.UserLogin;
                                mm.JOB_UPDATE_DATE = cm.SystemDate;
                            }
                            //Insert & Gen New ID
                            repoInsert.JOB_ID = db.SP_GEN_REPO_ID(Constants.FormatGenRepoId.JobId, m.ContractNo).First();
                            repoInsert.JOB_CONTRACT_NO = m.ContractNo;
                            repoInsert.JOB_CASE = mm.JOB_CASE;
                            repoInsert.JOB_LEGAL_STATUS = mm.JOB_LEGAL_STATUS;
                            repoInsert.JOB_REPO_STATUS = mm.JOB_REPO_STATUS;
                            repoInsert.JOB_BASE_COUNT = 1; // 1
                            repoInsert.JOB_REALLOCATE_FLAG = "0"; // 0
                            if (mm != null)
                            {
                                repoInsert.JOB_CUST_CODE = mm.JOB_CUST_CODE;
                                repoInsert.JOB_CUST_NAME = mm.JOB_CUST_NAME;
                                repoInsert.JOB_CUST_TYPE = mm.JOB_CUST_TYPE;
                                repoInsert.JOB_CARD_NO = mm.JOB_CARD_NO;
                                repoInsert.JOB_ADMIN_CODE = mm.JOB_ADMIN_CODE;
                                repoInsert.JOB_DUE_DATE = mm.JOB_DUE_DATE;
                                repoInsert.JOB_DUE_DAY = mm.JOB_DUE_DAY;
                                repoInsert.JOB_INST_AMT = mm.JOB_INST_AMT;
                                repoInsert.JOB_ASSIGN_ADMIN_DATE = mm.JOB_ASSIGN_ADMIN_DATE;
                                repoInsert.JOB_ASSIGN_OA_DATE = mm.JOB_ASSIGN_OA_DATE;
                                repoInsert.JOB_ASSIGN_REMARK = mm.JOB_ASSIGN_REMARK;
                                repoInsert.JOB_R3_SEND_DATE = mm.JOB_R3_SEND_DATE;
                                repoInsert.JOB_R3_RECEVIE_DATE = mm.JOB_R3_RECEVIE_DATE;
                            }

                            repoInsert.JOB_OA_CODE = oaCode; //writeStatus


                            if (contract != null)
                            {
                                repoInsert.JOB_BUCKET = contract.BUCKET_CODE; // Contract
                                repoInsert.JOB_INST_PAID = contract.PAID_AMT; //Contract
                                repoInsert.JOB_PAID_TERM = contract.PAID_TERM; //Contract
                                repoInsert.JOB_OS_AMT = contract.OUTSTANDING_BALANCE; //Contract
                                repoInsert.JOB_OVD_AMT = contract.ARREARS_AMOUNT; //Contract
                                repoInsert.JOB_OVD_DAY = Convert.ToInt32(contract.OVERDUE_DAY); //Contract
                                repoInsert.JOB_OVD_TERM = contract.OVERDUE_TERM; //Contract
                                repoInsert.JOB_BRAND = contract.BRAND; //Contract
                                repoInsert.JOB_MODEL = contract.MODEL; //Contract
                                repoInsert.JOB_PLATE_NO = contract.PLATE_NO; //Contract
                                repoInsert.JOB_ASSET_DESC = contract.BRAND + ' ' + contract.MODEL + ' ' +
                                                            contract.PLATE_NO; //Contract
                                repoInsert.JOB_PROVINCE_CODE = contract.PROVINCE_ID; //Contract
                            }
                            else
                            {
                                repoInsert.JOB_BUCKET = mm.JOB_BUCKET; // Contract
                                repoInsert.JOB_INST_PAID = mm.JOB_INST_PAID; //Contract
                                repoInsert.JOB_PAID_TERM = mm.JOB_PAID_TERM; //Contract
                                repoInsert.JOB_OS_AMT = mm.JOB_OS_AMT; //Contract
                                repoInsert.JOB_OVD_AMT = mm.JOB_OVD_AMT; //Contract
                                repoInsert.JOB_OVD_DAY = mm.JOB_OVD_DAY; //Contract
                                repoInsert.JOB_OVD_TERM = mm.JOB_OVD_TERM; //Contract
                                repoInsert.JOB_BRAND = mm.JOB_BRAND; //Contract
                                repoInsert.JOB_MODEL = mm.JOB_MODEL; //Contract
                                repoInsert.JOB_PLATE_NO = mm.JOB_PLATE_NO; //Contract
                                repoInsert.JOB_ASSET_DESC = mm.JOB_ASSET_DESC; //Contract
                                repoInsert.JOB_PROVINCE_CODE = mm.JOB_PROVINCE_CODE; //Contract
                            }
                            repoInsert.JOB_EXPIRE_DATE = assignDate.Value.AddDays(expiredDay);
                            repoInsert.JOB_DOC_FLAG = "1"; //1

                            repoInsert.JOB_OA_SUCCESS = null; // null
                            repoInsert.JOB_CAR_PARK = null;  // null
                            repoInsert.JOB_REPO_DATE = null; // null
                            repoInsert.JOB_TRANS_DATE = null; // null
                            repoInsert.JOB_MILEAGE = null; // null
                            repoInsert.JOB_REPO_TYPE = null; // null
                            repoInsert.JOB_CHARGE_DATE = null; // null
                            repoInsert.JOB_FEE_EXPENSE = null; // null
                            repoInsert.JOB_REPO_EXPENSE = null; // null
                            repoInsert.JOB_OTHER_EXPENSE = null; // null
                            repoInsert.JOB_RECEIVE_REMARK = null; // null
                            repoInsert.JOB_OTHER_EXPENSE = null; // null
                            repoInsert.JOB_RECEIVE_REMARK = null; // null
                            repoInsert.JOB_NOTI_FLAG = null; // null
                            repoInsert.JOB_RPS_DATE = null; // null

                            repoInsert.JOB_R3_ID = mm.JOB_R3_ID;
                            repoInsert.JOB_STEP_DATE = cm.SystemDate; // sysdate
                            repoInsert.JOB_CREATE_BY = cm.UserLogin; // login
                            repoInsert.JOB_CREATE_DATE = cm.SystemDate; // sysdate
                            repoInsert.JOB_UPDATE_BY = cm.UserLogin; // login
                            repoInsert.JOB_UPDATE_DATE = cm.SystemDate; // sysdate
                            repoInsert.JOB_STATUS = Constants.Status.Active;
                            repoInsert.JOB_ASSIGN_OA_DATE = assignDate;

                            db.T_JOB_REPO.Add(repoInsert);
                        }
                        else
                        {
                            //Update OLD ID
                            mm.JOB_ASSIGN_OA_DATE = assignDate;
                            mm.JOB_OA_CODE = oaCode;
                            mm.JOB_UPDATE_BY = cm.UserLogin;
                            mm.JOB_UPDATE_DATE = cm.SystemDate;
                        }
                    }


                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public JsonResult ContractNoSearch(string term)
        {
            var contractList = db.T_JOB_REPO
                   .Where(x => (x.JOB_CONTRACT_NO + x.JOB_CUST_NAME).Contains(term) && x.JOB_STATUS == Constants.Status.Active && x.JOB_REPO_STATUS != Constants.RepoStatus.Re02 && x.JOB_REPO_STATUS != Constants.RepoStatus.Re04)
                   .Select(x => new
                   {
                       id = x.JOB_CONTRACT_NO,
                       text = x.JOB_CONTRACT_NO + " : " + x.JOB_CUST_NAME
                   }).ToList();
            return Json(contractList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _GenerateDoc(List<AssignRepoOAViewModel> model)
        {
            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;
            try
            {
                foreach (var m in model)
                {
                    var mm = db.T_JOB_REPO.FirstOrDefault(x => x.JOB_CONTRACT_NO == m.ContractNo);
                    mm.JOB_GEN_FLAG = Constants.ReceiveFlag.ReceiveTrue;
                }
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public FileResult DownloadFile()
        {

            DataTable dt = cm.ToDataTable((List<SP_SEARCH_ASSIGN_REPO_Result>)Session[Constants.SessionTempName.AssignRepoExport]);

            dt.Columns.Remove("NAME_OA_SUCCESS");
            dt.Columns.Remove("JOB_CUST_CODE");
            dt.Columns.Remove("JOB_DOC_FLAG");
            dt.Columns.Remove("JOB_PROVINCE_CODE");
            dt.Columns.Remove("PROVINCE_CODE");
            dt.Columns.Remove("JOB_ID");

            dt.Columns["JOB_CONTRACT_NO"].ColumnName = "Contract No";

            dt.Columns["JOB_CARD_NO"].ColumnName = "Citizen ID";
            dt.Columns["JOB_CUST_NAME"].ColumnName = "Borrower Name";
            dt.Columns["NAME_OA_CODE"].ColumnName = "Previous Repo OA";
            dt.Columns["TOTAL_OS_BALANCE"].ColumnName = "Outstanding Balance";

            dt.Columns["JOB_ASSIGN_OA_DATE"].ColumnName = "Assign Date";
            dt.Columns["PROVINCE_NAME"].ColumnName = "Area";
            var fileDir = Server.MapPath("~/TempFiles/Download/AssignRepoOA_" + cm.SystemDate.ToString("yyyyMMddHHmmss") + ".xls");
            return DownloadFileExcel(cm.ExportExcel(dt, fileDir));
        }
    }
}