using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.Entities;
using NCLS.WEB.Models.ViewModels.SpecialCase;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    public class SpecialCaseController : Controller
    {

        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult searchRefNo(string q)
        {
            try
            {
                var m = db.T_JOB_LEGAL.Where(x => x.JOB_ID.Contains(q)).Where(x => x.JOB_CASE == "LC001"
                       || x.JOB_CASE == "LC002"
                       || x.JOB_CASE == "LC003"
                       || x.JOB_CASE == "LC004"
                       || x.JOB_CASE == "LC005"
                       || x.JOB_CASE == "LC006"
                       || x.JOB_CASE == "LC007"
                       || x.JOB_CASE == "LC008"
                       || x.JOB_CASE == "LC009"
                       || x.JOB_CASE == "LC010"
                       || x.JOB_CASE == "LC012"
                       || x.JOB_CASE == "LC013"
                       || x.JOB_CASE == "LC014").Select(x => new { x.JOB_ID });

                return Json(m.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult _Edit(string mode, string refNo)
        {
            if (mode == null) mode = "Add";
            if (refNo == null) refNo = "";
            var spCase = new SpecialCase();
            AddChequeTEMP = new List<AddCheque>();
            spCase.Other.Admin = cm.UserLogin;
            spCase.Cheque.Admin = cm.UserLogin;
            ViewBag.SpCase = "Other";
            ViewBag.Mode = mode;
            ViewBag.DocStatus = "0";
            if (mode == "Edit")
            {
                var tJob = db.T_JOB_LEGAL.Where(x => x.JOB_ID == refNo).FirstOrDefault();
                if (tJob.JOB_CASE == "LC012")
                    ViewBag.SpCase = "Cheque";
                else
                    ViewBag.SpCase = "Other";
                if (tJob != null)
                {
                    spCase.RefNo = tJob.JOB_ID;
                    spCase.LegalCase = tJob.JOB_CASE;
                    spCase.ContractNo = tJob.JOB_CONTRACT_NO;
                    if (spCase.LegalCase == "LC012")
                    {
                        ViewBag.DocStatus = tJob.JOB_DOC_FLAG;
                        spCase.Other.HasData = false;
                        spCase.Cheque.HasData = true;
                        spCase.Cheque.Admin = tJob.JOB_ADMIN_CODE;
                        spCase.Cheque.PayerName = tJob.JOB_CUST_NAME;
                        spCase.Cheque.CitizenId = tJob.JOB_CARD_NO;
                        spCase.Cheque.Address = tJob.JOB_CUST_ADDRESS;
                        spCase.Cheque.RequestDate = tJob.JOB_REQUEST_DATE;
                        spCase.Cheque.Remark = tJob.JOB_REMARK;

                        //db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == spCase.RefNo)
                        //    .ToList().ForEach(x => spCase.Cheque.ListOfCheque.Add(new AddCheque
                        //    {
                        //        BankCode = x.CHQ_BANK_ID,
                        //        BankName = x.CHQ_BANK_NAME,
                        //        BorrowerName = x.CHQ_BORROWER_NAME,
                        //        BranchName = x.CHQ_BRANCH_NAME,
                        //        ChequeAmount = (x.CHQ_EMI_AMOUNT == null) ? 0 : (decimal)x.CHQ_EMI_AMOUNT,
                        //        ChequeDate = x.CHQ_DEPOSIT_DATE,
                        //        ChequeNo = x.CHQ_CHEQUE_NO,
                        //        ContractNo = x.CHQ_CONTRACT_NO
                        //    }));


                        db.SP_SEARCH_SPECIAL_CASE_CHEQUE_LIST(spCase.RefNo).ToList().ForEach(x => AddChequeTEMP.Add(new AddCheque
                        {
                            BankCode = x.CHQ_BANK_ID,
                            BankName = x.CHQ_BANK_NAME,
                            BorrowerName = x.CHQ_BORROWER_NAME,
                            BranchName = x.CHQ_BRANCH_NAME,
                            ChequeAmount = (x.CHQ_EMI_AMOUNT == null) ? 0 : (decimal)x.CHQ_EMI_AMOUNT,
                            ChequeDate = x.CHQ_DEPOSIT_DATE,
                            ChequeNo = x.CHQ_CHEQUE_NO,
                            ContractNo = x.CHQ_CONTRACT_NO
                        }
                            ));

                        db.T_LEGAL_ATTACHMENT.Where(x => x.ATTACH_JOB_ID == spCase.RefNo)
                            .ToList().ForEach(x => spCase.Cheque.ListOfAttach.Add(new Attachment
                            {
                                FileName = x.ATTACH_FILE_NAME,
                                Description = x.ATTACH_DESCRIPTION
                            }));
                    }
                    else
                    {
                        ViewBag.DocStatus = tJob.JOB_DOC_FLAG;
                        spCase.Other.HasData = true;
                        spCase.Cheque.HasData = false;
                        spCase.Other.Admin = tJob.JOB_ADMIN_CODE;
                        spCase.Other.RequestDate = tJob.JOB_REQUEST_DATE;
                        spCase.Other.LegalOA = tJob.JOB_OA_CODE;
                        spCase.Other.AssignOADate = tJob.JOB_ASSIGN_OA_DATE;
                        spCase.Other.AMLOrderNo = tJob.JOB_AML_ORDER_NO;
                        spCase.Other.ShortFall = tJob.JOB_SHORT_FALL;
                        spCase.Other.CarReceivePlace = tJob.JOB_CAR_RECEIVE_PLACE;
                        spCase.Other.Requestor = tJob.JOB_REQUESTOR;
                        spCase.Other.TheCompanyPlan = tJob.JOB_COMPANY_PLAN;
                        spCase.Other.OrderedReh = tJob.JOB_ORDERED_REH;
                        spCase.Other.ReceiveOrderDate = tJob.JOB_RECEIVE_ORDER_DATE;
                        spCase.Other.AnnounceDate = tJob.JOB_ANNOUNCE_DATE;
                        spCase.Other.AppointedDate = tJob.JOB_APPOINTED_DATE;
                        spCase.Other.LastDueDate = tJob.JOB_LAST_DUE_DATE;
                        spCase.Other.PlaintiffName = tJob.JOB_PLAINTIFF_NAME;
                        spCase.Other.Insurer = tJob.JOB_INSURER_NAME;
                        spCase.Other.AssuredAmount = tJob.JOB_ASSURED_AMOUNT;
                        spCase.Other.TotalLossAmount = tJob.JOB_TOTAL_LOSS_AMOUNT;
                        spCase.Other.Remark = tJob.JOB_REMARK;
                        spCase.Other.CarReceiveDate = tJob.JOB_CAR_RECEIVE_DATE;
                        spCase.Other.LegalCase = tJob.JOB_CASE_OTHER;
                        spCase.Other.AMLOrderDate = tJob.JOB_AML_ORDER_DATE;
                        db.T_LEGAL_ATTACHMENT.Where(x => x.ATTACH_JOB_ID == spCase.RefNo)
                       .ToList().ForEach(x => spCase.Other.ListOfAttach.Add(new Attachment
                       {
                           FileName = x.ATTACH_FILE_NAME,
                           Description = x.ATTACH_DESCRIPTION
                       }));
                    }
                }
            }
            return PartialView(spCase);
        }

        public ActionResult _AddContract()
        {
            return PartialView();
        }

        public ActionResult _SearchData(string contractNo, string chequeNo, string admin, string legalOA
                                        , string refNo, string caseType, string legalCase, string status)
        {
            try
            {
                var listOfSp = db.SP_SEARCH_SPECIAL_CASE(contractNo, chequeNo, admin, legalOA, refNo, caseType, legalCase, status).ToList();
                //foreach (var item in listOfSp)
                //{
                //    if (item.LegalCase == "คดีเช็ค")
                //    {
                //        var strCheque = "";
                //        var chqList = db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == item.RefNo)
                //            .Select(x => x.CHQ_CHEQUE_NO).Distinct().ToList();
                //        foreach (var chq in chqList)
                //        {
                //            if (strCheque == "")
                //                strCheque = chq;
                //            else
                //                strCheque = strCheque + ", " + chq;
                //        }
                //        item.ContractOrCheque = strCheque;
                //    }
                //}
                return PartialView(listOfSp);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public JsonResult CheckDuplicateAdd(string contractNo, string legalCase)
        {
            try
            {
                var listDate = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == legalCase).ToList();
                var result = "";
                if (listDate.Count() > 0)
                {
                    result = "true";
                }
                else
                {
                    result = "false";
                }
                return Json(new { result = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = "" });
            }
        }
        public JsonResult GenerateRefNo(string contractNo, string legalCase, string checkDup)
        {
            DateTime? dt;
            string r3ID = "";
            var contract = db.S_CONTRACT.Where(x => x.CONTRACT_NO == contractNo).FirstOrDefault();
            var r3 = db.T_JOB_R3.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_STATUS == "A").ToList();

            if (!r3.Count.Equals(0))
            {
                dt = r3.FirstOrDefault().JOB_R3_RECEVIE_DATE;
                r3ID = r3.FirstOrDefault().JOB_ID;
            }


            string RefNo = "";
            var prefix = "";
            if (legalCase == "LC012")
            {
                //--- LC012 Cheque เช็ค
                prefix = "LGC" + cm.SystemDate.ToString("yyyyMM") + "-";
            }
            else
            {
                //--- คดีอื่นๆนอกจากเช็ค
                prefix = "LGS" + contractNo + "-";

                var listData = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == legalCase).ToList();

                if (checkDup == Constants.Status.Inactive)
                {
                    if (listData.Count > 0)
                    {
                        foreach (var m in listData)
                        {
                            m.JOB_STATUS = Constants.Status.Inactive;
                        }
                    }
                }


            }


            var jobList = db.T_JOB_LEGAL
                .Where(x => x.JOB_ID.Contains(prefix))
                .Select(x => x).OrderByDescending(x => x.JOB_ID)
                .ToList();
            RefNo = prefix + (jobList.Count + 1).ToString("000");

            T_JOB_LEGAL job = new T_JOB_LEGAL();

            job.JOB_ID = RefNo;
            job.JOB_CASE = legalCase;
            job.JOB_CONTRACT_NO = contractNo;
            job.JOB_CASE_OTHER = "";
            job.JOB_CASE_TYPE = "";
            job.JOB_LEGAL_STATUS = "";
            job.JOB_REPO_STATUS = "";
            job.JOB_BASE_COUNT = 1;
            job.JOB_REALLOCATE_FLAG = "0";
            if (!cm.IsNullOrEmpty(contract))
            {
                job.JOB_CUST_CODE = contract.CUST_CODE;
                job.JOB_CUST_NAME = contract.CUST_NAME_TH;
                job.JOB_CUST_TYPE = contract.CUSTOMER_TYPE;
                job.JOB_CUST_ADDRESS = contract.ADDRESS_LINE1 + " " + contract.ADDRESS_LINE2 + " " + contract.ADDRESS_LINE3;
                job.JOB_CARD_NO = contract.ID_NUMBER;
                job.JOB_ADMIN_CODE = cm.UserLogin;
                job.JOB_OA_CODE = "";
                //JOB_DUE_DATE =,
                // JOB_DUE_DAY =
                // JOB_INST_AMT =
                job.JOB_INST_PAID = contract.PAID_AMT;
                job.JOB_PAID_TERM = contract.PAID_TERM;
                job.JOB_OS_AMT = contract.OUTSTANDING_BALANCE;
                job.JOB_OVD_AMT = contract.ARREARS_AMOUNT;
                job.JOB_OVD_DAY = cm.UnInt32Null(contract.OVERDUE_DAY);
                job.JOB_OVD_TERM = contract.OVERDUE_TERM;
                job.JOB_BRAND = contract.BRAND;
                job.JOB_MODEL = contract.MODEL;
                job.JOB_PLATE_NO = contract.PLATE_NO;
                job.JOB_ASSET_DESC = contract.BRAND + " " + contract.MODEL + " " + contract.PLATE_NO + " " + contract.PLATE_PROVINCE;
                // JOB_EXPIRE_DATE =
                job.JOB_CONTRACT_LIST = contractNo;
            }
            job.JOB_DOC_FLAG = "0";
            job.JOB_ASSIGN_ADMIN_DATE = cm.SystemDate;
            // JOB_ASSIGN_OA_DATE =
            job.JOB_ASSIGN_REMARK = "Create Job By Menu";
            // JOB_FILING_DATE =
            // JOB_AML_ORDER_NO =
            // JOB_AML_ORDER_DATE =
            // JOB_ANNOUNCE_DATE =
            // JOB_APPOINT_DATE =
            // JOB_LAST_DUE_DATE =
            // JOB_RECEIVE_ORDER_DATE =
            // JOB_REQUEST_DATE =
            // JOB_CAR_RECEIVE_PLACE =
            //JOB_CAR_RECEIVE_DATE =
            //  JOB_INSURER_NAME =
            // JOB_ORDERED_REH =
            // JOB_PLAINTIFF_NAME =
            // JOB_REMARK =
            //JOB_REQUESTOR =
            // JOB_COMPANY_PLAN =
            // JOB_ASSURED_AMOUNT =
            // JOB_AMOUNT_CLAIMED =
            // JOB_SHORT_FALL =
            // JOB_TOTAL_LOSS_AMOUNT =

            // JOB_CHEQUE_LIST =
            // JOB_MAILING_DATE =dt;
            //  JOB_DEBTOR_STATUS =
            // JOB_BLACK_CODE =
            // JOB_RED_CODE =
            // JOB_ATTORNEY_STATUS =
            // JOB_COURT_CODE =
            // JOB_COURT_FEE =
            // JOB_POLICE_STATION =
            //  JOB_SUBMISSION_DATE =
            //JOB_SUBMISSION_AMOUNT =
            // JOB_CONTRACT_TERMINATED_DATE =
            // JOB_LACK_OF_BENEFIT =
            //  JOB_CHEQUE_NO =
            //  JOB_NOTIFY_CHEQUE_DATE =
            // JOB_PARTY_IN_LAW_SUIT =
            // JOB_APPOINTED_DATE =
            // JOB_ASSIGNED_DATE =
            //  JOB_ATTORNEY_DATE =
            //  JOB_NOTICE_DATE =
            //  JOB_WITNESS_DATE =
            //  JOB_WITNESS_TIME =
            //  JOB_LAWYER_FEE =
            //  JOB_SECOND_LAWYER_FEE =
            // JOB_ENFORCEMENT_DATE =
            //  JOB_BANKRUPTCY_DATE =
            // JOB_BANKRUPTCY_DISCHARGED_DATE =
            // JOB_POL_NO =
            // JOB_STOLEN_NO =
            // JOB_APPOINTMENT_CHECK_DATE =
            // JOB_OA_ENFORCEMENT =
            //JOB_SUBMIT_ENFORCEMENT_DATE =
            // JOB_OA_ASSET_SEARCH =
            // JOB_SUBMIT_INVEST_DATE =
            // JOB_ENFORCEMENT_EFF_DATE =
            // JOB_CASH_RECEIVE_DATE =
            // JOB_SEIZE_DATE =
            // JOB_REPORT_DATE =
            // JOB_JUDGMENT_DATE =
            // JOB_WITHDRAW_DATE =
            // JOB_EXECUTION_DATE =
            // JOB_EXECUTION_END_DATE =
            // JOB_DETAILS =
            job.JOB_R3_ID = r3ID;
            job.JOB_STEP_DATE = cm.SystemDate;
            job.JOB_CREATE_BY = cm.UserLogin;
            job.JOB_CREATE_DATE = cm.SystemDate;
            job.JOB_UPDATE_BY = cm.UserLogin;
            job.JOB_UPDATE_DATE = cm.SystemDate;
            job.JOB_STATUS = Constants.Status.Active;

            db.T_JOB_LEGAL.Add(job);
            db.SaveChanges();
            return Json(new { refNo = RefNo });
        }

        [HttpPost]
        public JsonResult SaveData(SpecialCase spCase)
        {
            try
            {
                var job = db.T_JOB_LEGAL.Where(x => x.JOB_ID == spCase.RefNo).FirstOrDefault();
                var CheckTracking = db.T_LEGAL_TRACKING.Where(x => x.LEGAL_JOB_ID == spCase.RefNo).FirstOrDefault();


                if (CheckTracking == null)
                {
                    T_LEGAL_TRACKING tracking = new T_LEGAL_TRACKING();

                    tracking.LEGAL_JOB_ID = spCase.RefNo;
                    tracking.LEGAL_SEQ_NO = 1;
                    tracking.LEGAL_CASE = spCase.LegalCase;
                    tracking.LEGAL_CONTRACT_NO = spCase.ContractNo;
                    tracking.LEGAL_TRACKING_DATE = cm.SystemDate;
                    tracking.LEGAL_TRACKING_BY = cm.UserLogin;
                    tracking.LEGAL_CAR_RECEIVED_PLACE = spCase.Other.CarReceivePlace;
                    tracking.LEGAL_APPOINTED_DATE = spCase.Other.AppointedDate;
                    tracking.LEGAL_CREATE_DATE = cm.SystemDate;
                    tracking.LEGAL_CREATE_BY = cm.UserLogin;
                    tracking.LEGAL_UPDATE_DATE = cm.SystemDate;
                    tracking.LEGAL_UPDATE_BY = cm.UserLogin;

                    db.T_LEGAL_TRACKING.Add(tracking);
                }

                if (spCase.LegalCase == "LC012")
                {
                    //--------- Save คดีเช็ค ---------------
                    job.JOB_CASE_TYPE = "CT001";
                    job.JOB_CUST_NAME = spCase.Cheque.PayerName;
                    job.JOB_CARD_NO = spCase.Cheque.CitizenId;
                    job.JOB_CUST_ADDRESS = spCase.Cheque.Address;
                    job.JOB_ADMIN_CODE = spCase.Cheque.Admin;
                    job.JOB_UPDATE_BY = cm.UserLogin;
                    job.JOB_UPDATE_DATE = cm.SystemDate;
                    job.JOB_STATUS = "A";
                    job.JOB_REMARK = spCase.Cheque.Remark;
                    job.JOB_REQUEST_DATE = spCase.Cheque.RequestDate;
                    job.JOB_DOC_FLAG = "0";
                    //--- Attachment Save ตั้งแต่ตอน Upload
                    //db.T_LEGAL_ATTACHMENT.Where(x => x.ATTACH_JOB_ID == spCase.RefNo)
                    //    .ToList().ForEach(x => db.T_LEGAL_ATTACHMENT.Remove(x));
                    //var i = 0;
                    //foreach (var att in spCase.Cheque.ListOfAttach)
                    //{
                    //    i++;
                    //    db.T_LEGAL_ATTACHMENT.Add(new T_LEGAL_ATTACHMENT()
                    //    {
                    //        ATTACH_JOB_ID = spCase.RefNo,
                    //        ATTACH_BY = cm.UserLogin,
                    //        ATTACH_DATE = cm.SystemDate,
                    //        ATTACH_FILE_NAME = att.FileName,
                    //        ATTACH_DESCRIPTION = att.Description,
                    //        ATTACH_SEQUENCE = i
                    //    });
                    //}


                    var strChq = "";
                    var strContract = "";
                    db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == spCase.RefNo)
                        .ToList().ForEach(x => db.T_CHEQUE_DETAIL.Remove(x));
                    foreach (var chq in AddChequeTEMP)
                    {
                        if (strChq == "") strChq = chq.ChequeNo;
                        else strChq = strChq + ", " + chq.ChequeNo;



                        var chequeContractNoList = chq.ContractNo.Split(',').ToList();
                        foreach (var contract in chequeContractNoList)
                        {
                            string custName = "";
                            var contract_no = contract.Replace(" ", "");
                            var conData = db.S_CONTRACT.Where(x => x.CONTRACT_NO == contract_no).FirstOrDefault();
                            if (!cm.IsNullOrEmpty(conData))
                            {
                                custName = conData.CUST_NAME_TH;
                            }


                            db.T_CHEQUE_DETAIL.Add(new T_CHEQUE_DETAIL()
                            {
                                CHQ_JOB_ID = spCase.RefNo,
                                CHQ_CONTRACT_NO = contract_no,
                                CHQ_ACCOUNT_NO = "",
                                CHQ_BANK_ID = chq.BankCode,
                                CHQ_BANK_NAME = chq.BankName,
                                CHQ_BORROWER_NAME = custName,
                                CHQ_BRANCH_NAME = chq.BranchName,
                                CHQ_EMI_AMOUNT = chq.ChequeAmount,
                                CHQ_CHEQUE_NO = chq.ChequeNo,
                                CHQ_DEPOSIT_DATE = chq.ChequeDate
                            });

                        }

                    }

                    var contractNoList = db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == spCase.RefNo).Select(f => f.CHQ_CONTRACT_NO).Distinct().ToList();
                    foreach (var contract in contractNoList)
                    {
                        if (strContract == "") strContract = contract;
                        else strContract = strContract + ", " + contract;
                    }


                    job.JOB_CONTRACT_LIST = strContract;
                    job.JOB_CHEQUE_LIST = strChq;
                    job.JOB_CONTRACT_NO = "";

                    db.SaveChanges();
                }
                else
                {
                    //--------- Save คดีอื่นๆนอกเหนือจากเช็ค ---------------
                    if (spCase.LegalCase == "LC003" || spCase.LegalCase == "LC004" || spCase.LegalCase == "LC005")
                        job.JOB_CASE_TYPE = "CT002";
                    else
                        job.JOB_CASE_TYPE = "CT001";

                    job.JOB_STATUS = "A";
                    job.JOB_ADMIN_CODE = spCase.Other.Admin;
                    job.JOB_OA_CODE = spCase.Other.LegalOA;
                    job.JOB_ASSIGN_OA_DATE = spCase.Other.AssignOADate;
                    job.JOB_AML_ORDER_NO = spCase.Other.AMLOrderNo;
                    job.JOB_AML_ORDER_DATE = spCase.Other.AMLOrderDate;
                    job.JOB_ANNOUNCE_DATE = spCase.Other.AnnounceDate;
                    // job.JOB_APPOINT_DATE = spCase.Other.ap;
                    job.JOB_APPOINTED_DATE = spCase.Other.AppointedDate;
                    job.JOB_LAST_DUE_DATE = spCase.Other.LastDueDate;
                    job.JOB_RECEIVE_ORDER_DATE = spCase.Other.ReceiveOrderDate;
                    job.JOB_REQUEST_DATE = spCase.Other.RequestDate;
                    job.JOB_CAR_RECEIVE_PLACE = spCase.Other.CarReceivePlace;
                    job.JOB_CAR_RECEIVE_DATE = spCase.Other.CarReceiveDate;
                    job.JOB_INSURER_NAME = spCase.Other.Insurer;
                    job.JOB_ORDERED_REH = spCase.Other.OrderedReh;
                    job.JOB_PLAINTIFF_NAME = spCase.Other.PlaintiffName;
                    job.JOB_CASE_OTHER = spCase.Other.LegalCase;
                    job.JOB_REMARK = spCase.Other.Remark;
                    job.JOB_REQUESTOR = spCase.Other.Requestor;
                    job.JOB_COMPANY_PLAN = spCase.Other.TheCompanyPlan;
                    job.JOB_ASSURED_AMOUNT = spCase.Other.AssuredAmount;
                    job.JOB_SHORT_FALL = spCase.Other.ShortFall;
                    job.JOB_TOTAL_LOSS_AMOUNT = spCase.Other.TotalLossAmount;
                    job.JOB_UPDATE_BY = cm.UserLogin;
                    job.JOB_UPDATE_DATE = cm.SystemDate;
                    job.JOB_DOC_FLAG = "0";
                    //--- Attachment Save ตั้งแต่ตอน Upload
                    //var i = 0;
                    //foreach (var att in spCase.Cheque.ListOfAttach)
                    //{
                    //    i++;
                    //    db.T_LEGAL_ATTACHMENT.Add(new T_LEGAL_ATTACHMENT()
                    //    {
                    //        ATTACH_JOB_ID = spCase.RefNo,
                    //        ATTACH_BY = cm.UserLogin,
                    //        ATTACH_DATE = cm.SystemDate,
                    //        ATTACH_FILE_NAME = att.FileName,
                    //        ATTACH_DESCRIPTION = att.Description,
                    //        ATTACH_SEQUENCE = i
                    //    });
                    //}

                    db.SaveChanges();
                }

                return Json(new { message = "Save data success", result = "1" });
            }
            catch (Exception)
            {
                return Json(new { message = "Save data fail", result = "0" });
            }
        }

        [HttpPost]
        //public JsonResult SaveChequeList(List<AddCheque> chequeList, string refNo)
        //{
        //    try
        //    {

        //        var strChq = "";
        //        var strContract = "";
        //        db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == refNo)
        //            .ToList().ForEach(x => db.T_CHEQUE_DETAIL.Remove(x));
        //        foreach (var chq in chequeList)
        //        {
        //            if (strChq == "") strChq = chq.ChequeNo;
        //            else strChq = strChq + ", " + chq.ChequeNo;

        //            if (strContract == "") strContract = chq.ContractNo;
        //            else strContract = strContract + ", " + chq.ContractNo;
        //            var contractNoList = chq.ContractNo.Split(',').ToArray();
        //            foreach (var contract in contractNoList)
        //            {
        //                db.T_CHEQUE_DETAIL.Add(new T_CHEQUE_DETAIL()
        //                {
        //                    CHQ_JOB_ID = refNo,
        //                    CHQ_CONTRACT_NO = contract,
        //                    CHQ_ACCOUNT_NO = "",
        //                    CHQ_BANK_ID = chq.BankCode,
        //                    CHQ_BANK_NAME = chq.BankName,
        //                    CHQ_BORROWER_NAME = "",
        //                    CHQ_BRANCH_NAME = chq.BranchName,
        //                    CHQ_EMI_AMOUNT = chq.ChequeAmount,
        //                    CHQ_CHEQUE_NO = chq.ChequeNo,
        //                    CHQ_DEPOSIT_DATE = chq.ChequeDate
        //                });

        //            }

        //        }

        //        var job = db.T_JOB_LEGAL.Where(x => x.JOB_ID == refNo).FirstOrDefault();
        //        job.JOB_CONTRACT_LIST = strContract;
        //        job.JOB_CHEQUE_LIST = strChq;
        //        job.JOB_CONTRACT_NO = "";
        //        db.SaveChanges();
        //        return Json(new { message = "Save data success", result = "1" });
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public ActionResult _SectionOther()
        {
            return PartialView();
        }

        public ActionResult _SectionCheque()
        {
            return PartialView();
        }

        public ActionResult _SelectContract(string mode)
        {
            ViewBag.Mode = mode;
            return PartialView();
        }

        public ActionResult _SelectCustomer()
        {
            return PartialView();
        }

        public ActionResult _SelectCheque()
        {
            return PartialView();
        }


        #region Session temp
        private List<AddCheque> AddChequeTEMP
        {
            get
            {
                if (Session["AddChequeTEMP"] == null)
                {
                    List<AddCheque> dt = new List<AddCheque>();
                    Session["AddChequeTEMP"] = dt;
                }
                return (List<AddCheque>)Session["AddChequeTEMP"];
            }
            set
            {
                Session["AddChequeTEMP"] = value;
            }
        }

        [HttpPost]
        public ActionResult _ChequeListTableDetail(string mode = "", int row = -1)
        {
            try
            {
                List<AddCheque> model = new List<AddCheque>();

                if (mode.Equals(Constants.Mode.Delete))
                {
                    AddChequeTEMP.RemoveAt(row);

                }

                model = AddChequeTEMP;

                return PartialView("_AddChequeList", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult ChequeListEdit(int row = -1, string mode = Constants.Mode.Add)
        {
            AddCheque model = new AddCheque();
            try
            {
                if (!row.Equals(-1))
                {
                    model = AddChequeTEMP[row];

                }
                ViewBag.row = row;
                ViewBag.mode_detail = mode;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        [HttpPost]
        public ActionResult CheckDuplicateCheque(string chequeNo)
        {

            string result = Constants.Result.False;

            var data = AddChequeTEMP.FirstOrDefault(x => x.ChequeNo == chequeNo.Trim());

            if (!cm.IsNullOrEmpty(data))
                result = Constants.Result.True;
            else
                result = Constants.Result.False;

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult _AddChequeList(int row = -1, string mode = "", string refNo = "", string chequeNo = "", decimal chequeAmount = 0, string chequeBankCode = "", string chequeBankName = ""
         , string chequeBranchName = "", string chequeContractList = "", string chequeRemark = "", DateTime? chequeDate = null)

        {
            try
            {

                //if Update data delete row at 
                if (mode.Equals(Constants.Mode.Edit))
                {
                    AddChequeTEMP.RemoveAt(row);
                }

                // var listOfChq = new List<AddCheque>();


                var item = new AddCheque();
                item.ContractNo = chequeContractList;

                var listOfContract = chequeContractList.Split(',').ToList();
                string BorrowerNameList = "";
                int count = 0;
                foreach (var contract in listOfContract)
                {

                    var contract_no = contract.Replace(" ", "");
                    var conData = db.S_CONTRACT.Where(x => x.CONTRACT_NO == contract_no).FirstOrDefault();
                    if (!cm.IsNullOrEmpty(conData))
                    {
                        BorrowerNameList += conData.CUST_NAME_TH;
                        if (listOfContract.Count() > 0 && count < listOfContract.Count() - 1)
                        {
                            BorrowerNameList += ",";
                        }
                    }
                    count++;
                }
                item.BorrowerName = BorrowerNameList;
                item.BankCode = chequeBankCode;
                item.BankName = chequeBankName;
                item.BranchName = chequeBranchName;
                item.ChequeAmount = chequeAmount;
                item.ChequeDate = chequeDate;
                item.ChequeNo = chequeNo;
                item.Remark = chequeRemark;
                AddChequeTEMP.Add(item);

                return PartialView(AddChequeTEMP);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult SpecialCaseReject(List<CheckListReject> Use)
        {
            string result = Constants.Result.False;
            string message = Constants.Msg.RejectFail;
            try
            {
                var listUse = Use.Where(x => x.CheckBox == true);
                foreach (var u in listUse)
                {
                    var m = db.T_JOB_LEGAL.Where(x => x.JOB_ID == u.RefNo).First();
                    m.JOB_STATUS = Constants.Status.Inactive;
                    m.JOB_UPDATE_BY = cm.UserLogin;
                    m.JOB_UPDATE_DATE = cm.SystemDate;
                    //cm.InsertLog(db, Constants.Mode.Reject, u.PaymentNo, Constants.ProgramCode.CourtFees);
                }

                db.SaveChanges();

                return Json(new { result = Constants.Result.True, message = Constants.Msg.RejectSucc }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SearchContract(string term, string listContract)
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult SearchCustomer(string term)
        {
            var custList = db.S_CUSTOMER_DETAIL
                 .Where(x => (x.FIRST_NAME_LCL + " " + x.LAST_NAME_LCL).Contains(term))
                 .Select(x => new
                 {
                     id = x.CUSTOMER_CODE,
                     text = x.FIRST_NAME_LCL + " " + x.LAST_NAME_LCL
                 }).ToList();
            return Json(custList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchCheque(string term)
        {
            var listCheque = AddChequeTEMP.Select(f => f.ChequeNo).ToArray();


            var chequeList = db.S_CONTRACT_CHEQUE
                 .Where(x => (x.CHEQUE_NO).Contains(term) && x.CHEQUE_CLEARING_CD != "Passed" && !listCheque.Contains(x.CHEQUE_NO))
                 .Select(x => new
                 {
                     id = x.CHEQUE_NO,
                     text = x.CHEQUE_NO + " : " + x.BANK_ID
                 }).ToList();
            return Json(chequeList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustDetail(string custCode)
        {
            var custName = "";
            var citizenId = "";
            var address = "";

            custName = db.S_CUSTOMER_DETAIL
                .Where(x => x.CUSTOMER_CODE == custCode)
                .Select(x => x.FIRST_NAME_LCL + " " + x.LAST_NAME_LCL).FirstOrDefault();

            citizenId = db.S_CUSTOMER_DETAIL
                .Where(x => x.CUSTOMER_CODE == custCode)
                .Select(x => x.ID_NUMBER).FirstOrDefault();

            address = db.S_CONTRACT_CUST_ADDRESS
                .Where(x => x.CUST_CODE == custCode && x.ADDR_TYPE == "Registered Address")
                .Select(x => x.ADDRESS_LINE1 + " "
                    + x.ADDRESS_LINE2 + " "
                    + x.ADDRESS_LINE3 + " "
                    + x.ADDRESS_LINE4 + " "
                    + x.POSTAL).FirstOrDefault();

            return Json(new { custName = custName, citizenId = citizenId, address = address });
        }

        public JsonResult GetChequeDetail(string chequeNo)
        {
            var chqDetail = db.S_CONTRACT_CHEQUE
                .Where(x => x.CHEQUE_NO == chequeNo && x.CHEQUE_CLEARING_CD != "Passed")
                .AsEnumerable()
                .Select(x => new
                {
                    chequeNo = x.CHEQUE_NO,
                    chequeDate = cm.DateDisplay(x.CHEQUE_DEPOSIT_DATE).Replace('-', '/'),
                    chequeAmount = cm.DecimalDisplay(x.EMI_AMNT),
                    bankName = x.BANK_ID,
                    bankCode = db.M_MASTER
                        .Where(o => o.MASTER_TYPE == "Bank" && o.MASTER_NAME_EN == x.BANK_ID)
                        .Select(o => o.MASTER_CODE).FirstOrDefault(),
                    branchName = x.BRANCH_ID
                }).FirstOrDefault();
            return Json(chqDetail);
        }

        public JsonResult GetContractListByCheque(string chequeNo)
        {
            var listOfContract = db.S_CONTRACT_CHEQUE
                    .Where(x => x.CHEQUE_NO == chequeNo && x.CHEQUE_CLEARING_CD != "Passed")
                    .Select(x => x.CONTRACT_NO)
                    .AsEnumerable();
            string strContract = "";
            foreach (string item in listOfContract)
            {
                if (item != "")
                {
                    if (ValidateContractList(item.Trim(), strContract))
                    {
                        if (strContract == "")
                            strContract = item.Trim();
                        else
                            strContract += ", " + item.Trim();
                    }
                }
            }
            return Json(new { contractList = strContract });
        }

        private bool ValidateContractList(string currentContract, string contractList)
        {
            try
            {
                var pass = true;
                //--- Check duplicate
                foreach (var item in contractList.Split(','))
                {
                    if (item.Trim().Equals(currentContract))
                    {
                        return false;
                    }
                }

                //--- Validate arrears amount > 1 monthly installment
                var ovdTerm = db.S_CONTRACT
                    .Where(x => x.CONTRACT_NO == currentContract)
                    .Select(x => x.OVERDUE_TERM).FirstOrDefault();
                //if (ovdTerm > 1)
                //{
                //    return true; *** ตอนนี้ยังไม่ได้คำนวณ field OVERDUE_TERM ทำให้ value ยังไม่ถูกต้อง
                //}
                return pass;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult _AddAttach(string refNo, string desc)
        {

            try
            {

                var attachVm = new Attachment();
                HttpPostedFileBase postFile = null;
                if (Request.Files.Count > 0)
                {
                    postFile = Request.Files[0];
                    var fileName = "";
                    var lastName = "";
                    var fileDir = Server.MapPath("~/TempFiles/Attachment/LegalCase/");
                    if (!Directory.Exists(fileDir))
                    {
                        Directory.CreateDirectory(fileDir);
                    }

                    //--- รูปแบบการเก็บ refNo + '-Att00x'
                    var refFiles = Directory.GetFiles(fileDir).Where(x => x.Contains(refNo))
                        .OrderByDescending(x => x).FirstOrDefault();

                    lastName = postFile.FileName.Split('.').Last();

                    if (cm.CheckExtensionFile(lastName))
                    {

                        if (refFiles == null)
                        {
                            fileName = refNo + "-Att" + (1).ToString("000") + "." + postFile.FileName.Split('.').Last();

                        }
                        else
                        {
                            var lastSeq = (refFiles.Split('\\').Last().Replace(refNo + "-Att", "").Split('.').First());
                            fileName = refNo + "-Att" + (cm.UnInt32Null(lastSeq) + 1).ToString("000")
                                + "." + postFile.FileName.Split('.').Last();
                        }

                        postFile.SaveAs(Path.Combine(fileDir, fileName));

                        var lastSeqIndb = db.T_LEGAL_ATTACHMENT.Where(x => x.ATTACH_JOB_ID == refNo)
                            .OrderByDescending(x => x.ATTACH_SEQUENCE).Select(x => x.ATTACH_SEQUENCE).FirstOrDefault();
                        if (lastSeqIndb < 0) lastSeqIndb = 0;
                        lastSeqIndb++;
                        db.T_LEGAL_ATTACHMENT.Add(new T_LEGAL_ATTACHMENT
                        {
                            ATTACH_JOB_ID = refNo,
                            ATTACH_DATE = cm.SystemDate,
                            ATTACH_BY = cm.UserLogin,
                            ATTACH_DESCRIPTION = desc,
                            ATTACH_FILE_NAME = fileName,
                            ATTACH_SEQUENCE = lastSeqIndb
                        });
                        db.SaveChanges();
                        attachVm.FileName = fileName;
                        attachVm.Description = desc;

                        return PartialView(attachVm);

                    }
                    else
                    {

                        return Json(new { result = Constants.Result.False, Msg = Constants.Msg.UploadNotFormat });
                    }



                }
                else
                {
                    return Json(new { result = Constants.Result.False, Msg = Constants.Msg.DataNotFound });
                }

            }
            catch (Exception)
            {

                return Json(new { result = Constants.Result.False, Msg = Constants.Msg.DataNotFound });

            }
        }

        public JsonResult DeleteAttach(string fileName)
        {
            try
            {
                db.T_LEGAL_ATTACHMENT.Remove(db.T_LEGAL_ATTACHMENT.Where(x => x.ATTACH_FILE_NAME == fileName).FirstOrDefault());
                db.SaveChanges();
                var fileDir = Server.MapPath("~/TempFiles/Attachment/LegalCase/");
                if (System.IO.File.Exists(Path.Combine(fileDir, fileName)))
                {
                    System.IO.File.Delete(Path.Combine(fileDir, fileName));
                }
                return Json(new { result = 1 });
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}