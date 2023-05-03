using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.Entities;
using NCLS.WEB.Models;
using NCLS.WEB.Models.ViewModels.User;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    public class CommonController : BaseController
    {
        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                base.Dispose(disposing);
        }

        public ActionResult _Modal()
        {
            return PartialView();
        }

        public ActionResult _NavMenu()
        {

            try
            {
                var menuByRole = db.SP_GET_MENU_BY_ROLE(cm.UserRole).ToList();
                return PartialView(menuByRole);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult _RoleList()
        {
            try
            {
                List<Role> model = cm.GetListRole(cm.UserLogin).Where(x => x.RoleFlag == true).ToList();
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult _Loading()
        {
            return PartialView();
        }

        public ActionResult _TopBar()
        {
            return PartialView();
        }

        public ActionResult _Notification()
        {
            Notification model = new Notification();
            try
            {
                //--- check notification by user

                //   if (cm.UserDataLevel.Equals(Constants.DataLevel.All))
                {
                    var listOfNoti = new List<Notification>();
                    var nt = new ItemNotification();

                    if (cm.IsPermission(Constants.ProgramCode.CourtFees, Constants.ActCode.CourtFeesApprove))
                    {
                        //     1. Court Fee 
                        nt = new ItemNotification();
                        nt.Count = db.T_EXPENSE_H.Where(x => x.EXPENSE_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.EXPENSE_TYPE == Constants.ExpenseType.CourtFees).Count();
                        nt.Header = "Court Fee";
                        nt.Detail = "Please Approve Court Fee";
                        nt.NoticeDate = cm.UnDateTimeStringNull(db.T_EXPENSE_H.Where(x => x.EXPENSE_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.EXPENSE_TYPE == Constants.ExpenseType.CourtFees).Max(x => x.EXPENSE_UPDATE_DATE));
                        nt.Url = Url.Content("~/CourtFees/Index/1");
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);
                    }

                    if (cm.IsPermission(Constants.ProgramCode.OtherExpense, Constants.ActCode.OtherExpenseApprove))
                    {
                        //2. Other Expense 
                        nt = new ItemNotification();
                        nt.Count = db.T_EXPENSE_H.Where(x => x.EXPENSE_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.EXPENSE_TYPE == Constants.ExpenseType.OtherExpense).Count();
                        nt.Header = "Other Expense";
                        nt.Detail = "Please Approve Other Expense";
                        nt.NoticeDate = cm.UnDateTimeStringNull(db.T_EXPENSE_H.Where(x => x.EXPENSE_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.EXPENSE_TYPE == Constants.ExpenseType.OtherExpense).Max(x => x.EXPENSE_UPDATE_DATE));
                        nt.Url = Url.Content("~/OtherExpense/Index/1");
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);
                    }
                    if (cm.IsPermission(Constants.ProgramCode.JDLegalCase, Constants.ActCode.JDLegalCaseApprove))
                    {
                        //3. Verdict Debtor (Legal Case)     
                        nt = new ItemNotification();
                        nt.Count = db.T_JUDGMENTDEBTOR_H.Where(x => x.JD_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.JD_TYPE == Constants.JudgmentType.Contract && x.JD_STATUS == Constants.Status.Active).Count();
                        nt.Header = "Verdict Debtor (Legal Case)";
                        nt.Detail = "Please Approve Verdict Debtor (Legal Case)";
                        nt.NoticeDate = cm.UnDateTimeStringNull(db.T_JUDGMENTDEBTOR_H.Where(x => x.JD_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.JD_TYPE == Constants.JudgmentType.Contract).Max(x => x.JD_UPDATE_DATE));
                        nt.Url = Url.Content("~/JudgmentDebtor/LegalCase/1");
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);
                    }
                    /*      if (cm.IsPermission(Constants.ProgramCode.JDCheque, Constants.ActCode.JDChequeApprove))
                          {
                              //4. Verdict Debtor (Cheque)       
                              nt = new ItemNotification();
                              nt.Count = db.T_JUDGMENTDEBTOR_H.Where(x => x.JD_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.JD_TYPE == Constants.JudgmentType.Cheque && x.JD_STATUS == Constants.Status.Active).Count();
                              nt.Header = "Verdict Debtor (Cheque)";
                              nt.Detail = "Please Approve Verdict Debtor (Cheque)";
                              nt.NoticeDate = cm.UnDateTimeStringNull(db.T_JUDGMENTDEBTOR_H.Where(x => x.JD_APPROVE_FLAG == Constants.ApproveStatus.Pending && x.JD_TYPE == Constants.JudgmentType.Cheque).Max(x => x.JD_UPDATE_DATE));
                              nt.Url = Url.Content("~/JudgmentDebtor/Cheque/1"); ;
                              model.CountItem = model.CountItem + nt.Count;
                              model.NotificationList.Add(nt);
                          }
                     * */
                    if (cm.IsPermission(Constants.ProgramCode.SuggesttoWriteoff, Constants.ActCode.SuggesttoWriteoffApprove))
                    {
                        //5. Suggest to Write off 
                        nt = new ItemNotification();
                        nt.Count = db.T_WRITEOFF_H.Where(x => x.WRITEOFF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Count();
                        nt.Header = "Suggest to Write off";
                        nt.Detail = "Please Approve Suggest to Write off ";
                        nt.NoticeDate = cm.UnDateTimeStringNull(db.T_WRITEOFF_H.Where(x => x.WRITEOFF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Max(x => x.WRITEOFF_UPDATE_DATE));
                        nt.Url = Url.Content("~/WriteOff/Suggest/1");
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);
                    }
                    if (cm.IsPermission(Constants.ProgramCode.BankruptcyFraud, Constants.ActCode.BankruptcyFraudApprove))
                    {
                        //6. Bankruptcy/Fraud  
                        nt = new ItemNotification();
                        nt.Count = db.T_BANKRUPTCY_FRAUD_H.Where(x => x.BF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Count();

                        nt.Header = "Bankruptcy/Fraud";
                        nt.Detail = "Please Approve Bankruptcy/Fraud";
                        nt.NoticeDate = cm.UnDateTimeStringNull(db.T_BANKRUPTCY_FRAUD_H.Where(x => x.BF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Max(x => x.BF_UPDATE_DATE));
                        nt.Url = Url.Content("~/BankrupcyFraud/Index/1");
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);

                    }

                    if (cm.IsPermission(Constants.ProgramCode.TodoList, Constants.ActCode.TodoListAdd))
                    {
                        //7. Cancel Legal  
                        nt = new ItemNotification();
                        string roleCode = "", adminCode = "";
                        cm.SetDataLevel(ref adminCode, ref roleCode);
                        nt.Count = db.SP_SEARCH_CANCEL_JOB_LEGAL(adminCode, roleCode).Count();

                        nt.Header = "Cancel Legal";
                        nt.Detail = "Repossess success, please cancel this case";
                        //  nt.NoticeDate = cm.UnDateTimeStringNull(db.T_BANKRUPTCY_FRAUD_H.Where(x => x.BF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Max(x => x.BF_UPDATE_DATE));
                        nt.Url = " modalPOST('Cancel Legal', 'TodoList', '_CancelLegal', '', 100)";
                        nt.typeModalPupup = true;
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);

                        //8. Todolist DocFlag 
                        nt = new ItemNotification();
                        nt.Count = db.SP_SEARCH_TODOLIST("", "", "", "", "",
                                                     "", adminCode, "", null, null,
                                                     null, null, "", roleCode, "2").Count();

                        nt.Header = "Legal Case";
                        nt.Detail = "Please prepare the document for legal case";
                        // nt.NoticeDate = cm.UnDateTimeStringNull(db.T_BANKRUPTCY_FRAUD_H.Where(x => x.BF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Max(x => x.BF_UPDATE_DATE));
                        nt.Url = Url.Content("~/TodoList/Index/2");
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);

                    }

                    if (cm.IsPermission(Constants.ProgramCode.ReceiveCar, Constants.ActCode.ReceiveCarEdit))
                    {
                        //7. Cancel Repo  
                        nt = new ItemNotification();
                        string roleCode = "", adminCode = "";
                        cm.SetDataLevel(ref adminCode, ref roleCode);
                        nt.Count = db.SP_SEARCH_CANCEL_JOB_REPO(adminCode, roleCode).Count();
                        nt.Header = "Cancel Repo";
                        nt.Detail = "Installment Paid, please cancel this case";
                        //  nt.NoticeDate = cm.UnDateTimeStringNull(db.T_BANKRUPTCY_FRAUD_H.Where(x => x.BF_APPROVE_FLAG == Constants.ApproveStatus.Pending).Max(x => x.BF_UPDATE_DATE));
                        nt.Url = " modalPOST('Cancel Repo', 'TodoList', '_CancelRepo', '', 100)";
                        nt.typeModalPupup = true;
                        model.CountItem = model.CountItem + nt.Count;
                        model.NotificationList.Add(nt);


                    }
                }

                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult _PageBar(string progCode)
        {
            string toReturn = "";
            //toReturn +="<ul class="page-breadcrumb">";
            //for (int i =1;i<=xx;i++)
            //{
            //toReturn +="<li>";
            //if has icon
            //toReturn +="<i class="xx.PROG_ICON"></i>";

            //toReturn +="<span>To-do List</span>";

            //if (i!=xx.lenght)
            //toReturn +="<i class="fa fa-angle-right"></i>";
            //toReturn +="</li>";
            //}
            //toReturn +=</ul>

            return Content(toReturn);
        }
        public FileResult DownloadLegalAttachment(string fileName)
        {
            try
            {
                var fileDir = Server.MapPath("~/TempFiles/Attachment/LegalCase/");
                var filePath = System.IO.Path.Combine(fileDir, fileName);
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}