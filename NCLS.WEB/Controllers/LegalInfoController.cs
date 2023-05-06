using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCLS.WEB.Entities;
using NCLS.WEB.Utility;
using NCLS.WEB.Models.ViewModels.LegalCase;

namespace NCLS.WEB.Controllers
{
    public class LegalInfoController : Controller
    {
        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();

        //------------------------------------
        //--- LC015	ฟ้องเรียกทรัพย์
        //--- LC016	ฟ้องขาดทุน
        //--- LC010	AMLO คดี ปปง
        //--- LC009	ONCB คดี ปปส
        //--- LC003 Embezzle ยักยอกทรัพย์
        //--- LC008	Exhibit ร้องคืนของกลาง
        //--- LC006 Bankruptcy ล้มละลาย
        //--- LC014 Claim เคลมประกัน
        //--- LC002 OCPB สคบ
        //--- LC001 Other คดีอื่นๆ
        //--- LC012 Cheque เช็ค
        //--- LC007	Rehabilitation ฟื้นฟูกิจการ
        //------------------------------------

        //public ActionResult LegalCase(string id = "")
        //{

        //    var legalVm = new LegalCase();
        //    legalVm.DefaultRefNo = id;
        //    legalVm.ContractNo = "";
        //    if (id != "")
        //    {
        //        var jobLegal = db.T_JOB_LEGAL.Where(x => x.JOB_ID == id).FirstOrDefault();
        //        legalVm.ContractNo = (jobLegal.JOB_CONTRACT_NO == null) ? "" : jobLegal.JOB_CONTRACT_NO;
        //        if (legalVm.ContractNo == "")
        //        {
        //            var chqContract = db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == id).FirstOrDefault();
        //            legalVm.ContractNo = (chqContract == null) ? "" : chqContract.CHQ_CONTRACT_NO;
        //        }
        //    }
        //    return View(legalVm);
        //}

        //public ActionResult Cheque(string id)
        //{
        //    return View();
        //}

        //public ActionResult _LegalCase(string contractNo, string defaultRefNo)
        //{
        //    try
        //    {
        //        var legalVm = new LegalCase();
        //        if (!string.IsNullOrEmpty(contractNo))
        //        {
        //            var listOfJob = db.T_JOB_LEGAL.Where(x => (x.JOB_STATUS == "A") && (x.JOB_CONTRACT_NO == contractNo || x.JOB_ID == defaultRefNo))
        //                .Select(x => x).ToList();
        //            legalVm.ContractNo = contractNo;
        //            legalVm.DefaultRefNo = defaultRefNo;
        //            foreach (var job in listOfJob)
        //            {
        //                if (job.JOB_CASE == Constants.LegalCase.LC015)
        //                {
        //                    //--- LC015	ฟ้องเรียกทรัพย์
        //                    legalVm.RecallCase.HasData = true;
        //                    legalVm.RecallCase.RefNo = job.JOB_ID;
        //                    legalVm.RecallCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.RecallCase.LegalCase = Constants.LegalCase.LC015;
        //                    //legalVm.RecallCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();
        //                    //legalVm.RecallCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();

        //                    //if (!legalVm.RecallCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.RecallCase.totalCourtFee = legalVm.RecallCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.RecallCase.totalReceiveBack = legalVm.RecallCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.RecallCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.RecallCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.RecallCase.totalExpensePayment = legalVm.RecallCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.RecallCase.totalExpenseNet = legalVm.RecallCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.RecallCase.totalExpenseTax = legalVm.RecallCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.RecallCase.totalExpenseVat = legalVm.RecallCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}

        //                    //legalVm.RecallCase.ListOfJudgmentDebtor = db.SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //legalVm.RecallCase.CarReceives = db.SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB(job.JOB_ID).FirstOrDefault();
        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC016)
        //                {
        //                    //--- LC016	ฟ้องขาดทุน
        //                    legalVm.LossCase.HasData = true;
        //                    legalVm.LossCase.RefNo = job.JOB_ID;
        //                    legalVm.LossCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.LossCase.LegalCase = Constants.LegalCase.LC016;
        //                    //legalVm.LossCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.LossCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.LossCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.LossCase.totalCourtFee = legalVm.LossCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.LossCase.totalReceiveBack = legalVm.LossCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.LossCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.RecallCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.LossCase.totalExpensePayment = legalVm.RecallCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.LossCase.totalExpenseNet = legalVm.LossCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.LossCase.totalExpenseTax = legalVm.LossCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.LossCase.totalExpenseVat = legalVm.LossCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}

        //                    //legalVm.LossCase.ListOfJudgmentDebtor = db.SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //legalVm.LossCase.Repo = db.SP_SELECT_LEGAL_REPO_BY_JOB(job.JOB_ID).FirstOrDefault();
        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC010)
        //                {
        //                    //--- LC010	AMLO คดี ปปง
        //                    legalVm.AMLOCase.HasData = true;
        //                    legalVm.AMLOCase.RefNo = job.JOB_ID;
        //                    legalVm.AMLOCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.AMLOCase.LegalCase = Constants.LegalCase.LC010;
        //                    //legalVm.AMLOCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.AMLOCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();                     
        //                    //if (!legalVm.AMLOCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.AMLOCase.totalCourtFee = legalVm.AMLOCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.AMLOCase.totalReceiveBack = legalVm.AMLOCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}


        //                    //legalVm.AMLOCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.AMLOCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.AMLOCase.totalExpensePayment = legalVm.AMLOCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.AMLOCase.totalExpenseNet = legalVm.AMLOCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.AMLOCase.totalExpenseTax = legalVm.AMLOCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.AMLOCase.totalExpenseVat = legalVm.AMLOCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}

        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC009)
        //                {
        //                    //--- LC009	ONCB คดี ปปส
        //                    legalVm.ONCBCase.HasData = true;
        //                    legalVm.ONCBCase.RefNo = job.JOB_ID;
        //                    legalVm.ONCBCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.ONCBCase.LegalCase = Constants.LegalCase.LC009;
        //                    //legalVm.ONCBCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.ONCBCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ONCBCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ONCBCase.totalCourtFee = legalVm.ONCBCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.ONCBCase.totalReceiveBack = legalVm.ONCBCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //                    //}

        //                    //legalVm.ONCBCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ONCBCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ONCBCase.totalExpensePayment = legalVm.ONCBCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.ONCBCase.totalExpenseNet = legalVm.ONCBCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.ONCBCase.totalExpenseTax = legalVm.ONCBCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.ONCBCase.totalExpenseVat = legalVm.ONCBCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}
        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC003)
        //                {
        //                    //--- LC003 Embezzle ยักยอกทรัพย์
        //                    legalVm.EmbezzleCase.HasData = true;
        //                    legalVm.EmbezzleCase.RefNo = job.JOB_ID;
        //                    legalVm.EmbezzleCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.EmbezzleCase.LegalCase = Constants.LegalCase.LC003;
        //                    //legalVm.EmbezzleCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.EmbezzleCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.EmbezzleCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.EmbezzleCase.totalCourtFee = legalVm.EmbezzleCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.EmbezzleCase.totalReceiveBack = legalVm.EmbezzleCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //                    //}

        //                    //legalVm.EmbezzleCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.EmbezzleCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.EmbezzleCase.totalExpensePayment = legalVm.EmbezzleCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.EmbezzleCase.totalExpenseNet = legalVm.EmbezzleCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.EmbezzleCase.totalExpenseTax = legalVm.EmbezzleCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.EmbezzleCase.totalExpenseVat = legalVm.EmbezzleCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC004)
        //                {
        //                    //--- LC003 Embezzle คดีฉ้อโกง
        //                    legalVm.EmbezzleCase2.HasData = true;
        //                    legalVm.EmbezzleCase2.RefNo = job.JOB_ID;
        //                    legalVm.EmbezzleCase2.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.EmbezzleCase2.LegalCase = Constants.LegalCase.LC004;
        //                    //legalVm.EmbezzleCase2.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();
        //                    //legalVm.EmbezzleCase2.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.EmbezzleCase2.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.EmbezzleCase2.totalCourtFee = legalVm.EmbezzleCase2.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.EmbezzleCase2.totalReceiveBack = legalVm.EmbezzleCase2.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.EmbezzleCase2.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.EmbezzleCase2.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.EmbezzleCase2.totalExpensePayment = legalVm.EmbezzleCase2.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.EmbezzleCase2.totalExpenseNet = legalVm.EmbezzleCase2.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.EmbezzleCase2.totalExpenseTax = legalVm.EmbezzleCase2.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.EmbezzleCase2.totalExpenseVat = legalVm.EmbezzleCase2.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}





        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC005)
        //                {
        //                    //--- LC003 Embezzle คดีโกงเจ้าหนี้
        //                    legalVm.EmbezzleCase3.HasData = true;
        //                    legalVm.EmbezzleCase3.RefNo = job.JOB_ID;
        //                    legalVm.EmbezzleCase3.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.EmbezzleCase3.LegalCase = Constants.LegalCase.LC005;
        //                    //legalVm.EmbezzleCase3.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();
        //                    //legalVm.EmbezzleCase3.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.EmbezzleCase3.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.EmbezzleCase3.totalCourtFee = legalVm.EmbezzleCase3.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.EmbezzleCase3.totalReceiveBack = legalVm.EmbezzleCase3.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.EmbezzleCase3.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.EmbezzleCase3.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.EmbezzleCase3.totalExpensePayment = legalVm.EmbezzleCase3.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.EmbezzleCase3.totalExpenseNet = legalVm.EmbezzleCase3.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.EmbezzleCase3.totalExpenseTax = legalVm.EmbezzleCase3.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.EmbezzleCase3.totalExpenseVat = legalVm.EmbezzleCase3.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC008)
        //                {
        //                    //--- LC008	Exhibit ร้องคืนของกลาง
        //                    legalVm.ExhibitCase.HasData = true;
        //                    legalVm.ExhibitCase.RefNo = job.JOB_ID;
        //                    legalVm.ExhibitCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.ExhibitCase.LegalCase = Constants.LegalCase.LC008;
        //                  //  legalVm.ExhibitCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                  //  legalVm.ExhibitCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                  //  if (!legalVm.ExhibitCase.ListOfCourtFee.Count.Equals(0))
        //                  //  {
        //                  //      legalVm.ExhibitCase.totalCourtFee = legalVm.ExhibitCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                  //      legalVm.ExhibitCase.totalReceiveBack = legalVm.ExhibitCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                  //  }

        //                  //legalVm.ExhibitCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                  //  if (!legalVm.ExhibitCase.ListOfExpense.Count.Equals(0))
        //                  //  {
        //                  //      legalVm.ExhibitCase.totalExpensePayment = legalVm.ExhibitCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                  //      legalVm.ExhibitCase.totalExpenseNet = legalVm.ExhibitCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                  //      legalVm.ExhibitCase.totalExpenseTax = legalVm.ExhibitCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                  //      legalVm.ExhibitCase.totalExpenseVat = legalVm.ExhibitCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                  //  }





        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC006)
        //                {
        //                    //--- LC006 Bankruptcy ล้มละลาย
        //                    legalVm.BankruptcyCase.HasData = true;
        //                    legalVm.BankruptcyCase.RefNo = job.JOB_ID;
        //                    legalVm.BankruptcyCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.BankruptcyCase.LegalCase = Constants.LegalCase.LC006;
        //                    //legalVm.BankruptcyCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.BankruptcyCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.BankruptcyCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.BankruptcyCase.totalCourtFee = legalVm.BankruptcyCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.BankruptcyCase.totalReceiveBack = legalVm.BankruptcyCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.BankruptcyCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.BankruptcyCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.BankruptcyCase.totalExpensePayment = legalVm.BankruptcyCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.BankruptcyCase.totalExpenseNet = legalVm.BankruptcyCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.BankruptcyCase.totalExpenseTax = legalVm.BankruptcyCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.BankruptcyCase.totalExpenseVat = legalVm.BankruptcyCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC013)
        //                {
        //                    //--- LC014 Claim เคลมประกัน คดีรถหาย
        //                    legalVm.ClaimCase.HasData = true;
        //                    legalVm.ClaimCase.RefNo = job.JOB_ID;
        //                    legalVm.ClaimCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.ClaimCase.LegalCase = Constants.LegalCase.LC013;
        //                    //legalVm.ClaimCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.ClaimCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ClaimCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ClaimCase.totalCourtFee = legalVm.ClaimCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.ClaimCase.totalReceiveBack = legalVm.ClaimCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.ClaimCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ClaimCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ClaimCase.totalExpensePayment = legalVm.ClaimCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.ClaimCase.totalExpenseNet = legalVm.ClaimCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.ClaimCase.totalExpenseTax = legalVm.ClaimCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.ClaimCase.totalExpenseVat = legalVm.ClaimCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC014)
        //                {
        //                    //--- LC014 Claim เคลมประกัน เสียหายโดยสิ้นเชิง
        //                    legalVm.ClaimCase2.HasData = true;
        //                    legalVm.ClaimCase2.RefNo = job.JOB_ID;
        //                    legalVm.ClaimCase2.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.ClaimCase2.LegalCase = Constants.LegalCase.LC014;
        //                    //legalVm.ClaimCase2.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.ClaimCase2.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ClaimCase2.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ClaimCase2.totalCourtFee = legalVm.ClaimCase2.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.ClaimCase2.totalReceiveBack = legalVm.ClaimCase2.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.ClaimCase2.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ClaimCase2.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ClaimCase2.totalExpensePayment = legalVm.ClaimCase2.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.ClaimCase2.totalExpenseNet = legalVm.ClaimCase2.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.ClaimCase2.totalExpenseTax = legalVm.ClaimCase2.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.ClaimCase2.totalExpenseVat = legalVm.ClaimCase2.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC002)
        //                {
        //                    //--- LC002 OCPB สคบ
        //                    legalVm.OCPBCase.HasData = true;
        //                    legalVm.OCPBCase.RefNo = job.JOB_ID;
        //                    legalVm.OCPBCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.OCPBCase.LegalCase = Constants.LegalCase.LC002;
        //                    //legalVm.OCPBCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.OCPBCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.OCPBCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.OCPBCase.totalCourtFee = legalVm.OCPBCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.OCPBCase.totalReceiveBack = legalVm.OCPBCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); 
        //                    //}

        //                    //legalVm.OCPBCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.OCPBCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.OCPBCase.totalExpensePayment = legalVm.OCPBCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.OCPBCase.totalExpenseNet = legalVm.OCPBCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.OCPBCase.totalExpenseTax = legalVm.OCPBCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.OCPBCase.totalExpenseVat = legalVm.OCPBCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC001)
        //                {
        //                    //--- LC001 Other คดีอื่นๆ
        //                    legalVm.OtherCase.HasData = true;
        //                    legalVm.OtherCase.RefNo = job.JOB_ID;
        //                    legalVm.OtherCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.OtherCase.LegalCase = Constants.LegalCase.LC001;
        //                    //legalVm.OtherCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.OtherCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.OtherCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.OtherCase.totalCourtFee = legalVm.OtherCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.OtherCase.totalReceiveBack = legalVm.OtherCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); 
        //                    //}

        //                    //legalVm.OtherCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.OtherCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.OtherCase.totalExpensePayment = legalVm.OtherCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.OtherCase.totalExpenseNet = legalVm.OtherCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.OtherCase.totalExpenseTax = legalVm.OtherCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.OtherCase.totalExpenseVat = legalVm.OtherCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}





        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC012)
        //                {
        //                    //--- LC012 Cheque เช็ค
        //                    legalVm.ChequeCase.HasData = true;
        //                    legalVm.ChequeCase.RefNo = job.JOB_ID;
        //                    legalVm.ChequeCase.ContractNo ="" ;//contractNo
        //                    legalVm.ChequeCase.LegalCase = Constants.LegalCase.LC012;
        //                    //legalVm.ChequeCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.ChequeCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ChequeCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ChequeCase.totalCourtFee = legalVm.ChequeCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.ChequeCase.totalReceiveBack = legalVm.ChequeCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.ChequeCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.ChequeCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.ChequeCase.totalExpensePayment = legalVm.ChequeCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.ChequeCase.totalExpenseNet = legalVm.ChequeCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.ChequeCase.totalExpenseTax = legalVm.ChequeCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.ChequeCase.totalExpenseVat = legalVm.ChequeCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //                else if (job.JOB_CASE == Constants.LegalCase.LC007)
        //                {
        //                    //--- LC007	Rehabilitation ฟื้นฟูกิจการ
        //                    legalVm.RehabilitationCase.HasData = true;
        //                    legalVm.RehabilitationCase.RefNo = job.JOB_ID;
        //                    legalVm.RehabilitationCase.ContractNo = job.JOB_CONTRACT_NO;
        //                    legalVm.RehabilitationCase.LegalCase = Constants.LegalCase.LC007;
        //                    //legalVm.RehabilitationCase.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //                    //legalVm.RehabilitationCase.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.RehabilitationCase.ListOfCourtFee.Count.Equals(0))
        //                    //{
        //                    //    legalVm.RehabilitationCase.totalCourtFee = legalVm.RehabilitationCase.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                    //    legalVm.RehabilitationCase.totalReceiveBack = legalVm.RehabilitationCase.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); ;
        //                    //}

        //                    //legalVm.RehabilitationCase.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //                    //if (!legalVm.RehabilitationCase.ListOfExpense.Count.Equals(0))
        //                    //{
        //                    //    legalVm.RehabilitationCase.totalExpensePayment = legalVm.RehabilitationCase.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                    //    legalVm.RehabilitationCase.totalExpenseNet = legalVm.RehabilitationCase.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                    //    legalVm.RehabilitationCase.totalExpenseTax = legalVm.RehabilitationCase.ListOfExpense.Select(x => x.WHT).Sum();
        //                    //    legalVm.RehabilitationCase.totalExpenseVat = legalVm.RehabilitationCase.ListOfExpense.Select(x => x.VAT).Sum();
        //                    //}



        //                }
        //            }
        //        }

        //        if (legalVm.LossCase.HasData && (defaultRefNo.ToUpper() == legalVm.LossCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.LossCase.CssActive = " active";

        //        else if (legalVm.RecallCase.HasData && (defaultRefNo.ToUpper() == legalVm.RecallCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.RecallCase.CssActive = " active";

        //        else if (legalVm.AMLOCase.HasData && (defaultRefNo.ToUpper() == legalVm.AMLOCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.AMLOCase.CssActive = " active";

        //        else if (legalVm.ONCBCase.HasData && (defaultRefNo.ToUpper() == legalVm.ONCBCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.ONCBCase.CssActive = " active";

        //        else if (legalVm.EmbezzleCase.HasData && (defaultRefNo.ToUpper() == legalVm.EmbezzleCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.EmbezzleCase.CssActive = " active";

        //        else if (legalVm.EmbezzleCase2.HasData && (defaultRefNo.ToUpper() == legalVm.EmbezzleCase2.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.EmbezzleCase2.CssActive = " active";

        //        else if (legalVm.EmbezzleCase3.HasData && (defaultRefNo.ToUpper() == legalVm.EmbezzleCase3.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.EmbezzleCase3.CssActive = " active";

        //        else if (legalVm.ExhibitCase.HasData && (defaultRefNo.ToUpper() == legalVm.ExhibitCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.ExhibitCase.CssActive = " active";

        //        else if (legalVm.BankruptcyCase.HasData && (defaultRefNo.ToUpper() == legalVm.BankruptcyCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.BankruptcyCase.CssActive = " active";

        //        else if (legalVm.ClaimCase.HasData && (defaultRefNo.ToUpper() == legalVm.ClaimCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.ClaimCase.CssActive = " active";

        //        else if (legalVm.ClaimCase2.HasData && (defaultRefNo.ToUpper() == legalVm.ClaimCase2.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.ClaimCase2.CssActive = " active";

        //        else if (legalVm.OCPBCase.HasData && (defaultRefNo.ToUpper() == legalVm.OCPBCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.OCPBCase.CssActive = " active";

        //        else if (legalVm.BankruptcyCase.HasData && (defaultRefNo.ToUpper() == legalVm.BankruptcyCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.OtherCase.CssActive = " active";

        //        else if (legalVm.OtherCase.HasData && (defaultRefNo.ToUpper() == legalVm.OtherCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.OtherCase.CssActive = " active";

        //        else if (legalVm.RehabilitationCase.HasData && (defaultRefNo.ToUpper() == legalVm.RehabilitationCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.RehabilitationCase.CssActive = " active";

        //        else if (legalVm.ChequeCase.HasData && (defaultRefNo.ToUpper() == legalVm.ChequeCase.RefNo.ToUpper() || defaultRefNo == ""))
        //            legalVm.ChequeCase.CssActive = " active";

        //        //--- LC010	 คดี ปปง
        //        //--- LC009	 คดี ปปส
        //        //--- LC003  ยักยอกทรัพย์
        //        //--- LC008	 ร้องคืนของกลาง
        //        //--- LC006  ล้มละลาย
        //        //--- LC014  เคลมประกัน
        //        //--- LC002  สคบ
        //        //--- LC001  คดีอื่นๆ
        //        //--- LC012  เช็ค
        //        //--- LC007	 ฟื้นฟูกิจการ

        //        return PartialView(legalVm);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public ActionResult _LegalTracking(string refNo = "", int seqNo = 0, string readOnly = "Y", string contractNo = "", string legalCase = "")
        //{
        //    var tracking = new LegalTracking();
        //    tracking.ContractNo = contractNo;
        //    tracking.LegalCase = legalCase;
        //    tracking.RefNo = refNo;
        //    tracking.ReadOnly = readOnly;
        //    tracking.SelectedTracking = new T_LEGAL_TRACKING();
        //    tracking.ListOfTracking = new List<SP_SELECT_LEGAL_TRACKING_BY_CASE_Result>();
        //    if (refNo != "")
        //    {
        //        tracking.ListOfTracking = db.SP_SELECT_LEGAL_TRACKING_BY_CASE(refNo).ToList();
        //        if (seqNo == 0 && tracking.ListOfTracking.Count > 0)
        //        {
        //            seqNo = db.T_LEGAL_TRACKING.Where(x => x.LEGAL_JOB_ID == refNo).Max(x => x.LEGAL_SEQ_NO);
        //        }
        //        if (seqNo > 0)
        //        {
        //            tracking.SelectedTracking = db.T_LEGAL_TRACKING
        //                .Where(x => x.LEGAL_JOB_ID == refNo && x.LEGAL_SEQ_NO == seqNo).FirstOrDefault();
        //        }

        //    }
        //    return PartialView(tracking);
        //}

        ////--- LC015	ฟ้องเรียกทรัพย์
        //public ActionResult _RecallCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var recallVm = new RecallInfo();
        //    recallVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC015")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC015" && x.JOB_STATUS=="A").ToList();



        //    recallVm.ContractNo = contractNo;
        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();

        //        recallVm.HasData = true;
        //        recallVm.RefNo = job.JOB_ID;
        //        recallVm.CssActive = cssActive;
        //        recallVm.ContractNo = job.JOB_CONTRACT_NO;
        //        recallVm.LegalCase = Constants.LegalCase.LC015;
        //        recallVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        recallVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        recallVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        recallVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        recallVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!recallVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            recallVm.totalCourtFee = recallVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            recallVm.totalReceiveBack = recallVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum(); 
        //        }

        //        recallVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!recallVm.ListOfExpense.Count.Equals(0))
        //        {
        //            recallVm.totalExpensePayment = recallVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            recallVm.totalExpenseNet = recallVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            recallVm.totalExpenseTax = recallVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            recallVm.totalExpenseVat = recallVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //        recallVm.ListOfJudgmentDebtor = db.SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        var CarReceives = db.SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB(job.JOB_ID).FirstOrDefault();
        //        if (CarReceives != null)
        //            recallVm.CarReceives = CarReceives;

        //    }
        //    return PartialView(recallVm);
        //}

        ////--- LC016	ฟ้องขาดทุน
        //public ActionResult _LossCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    try
        //    {
        //        var lossVm = new LossInfo();
        //        lossVm.ReadOnly = readOnly;
        //        //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC016")
        //        //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //        var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC016" && x.JOB_STATUS == "A").ToList();


        //        if (!jobList.Count.Equals(0))
        //        {
        //            var job = jobList.FirstOrDefault();

        //            lossVm.HasData = true;
        //            lossVm.RefNo = job.JOB_ID;
        //            lossVm.ContractNo = job.JOB_CONTRACT_NO;
        //            lossVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //            lossVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //            lossVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //            lossVm.ShortFall = job.JOB_AMOUNT_CLAIMED;
        //            lossVm.LegalCase = Constants.LegalCase.LC016;
        //            lossVm.CssActive = cssActive;
        //            lossVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //            lossVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //            if (!lossVm.ListOfCourtFee.Count.Equals(0))
        //            {
        //                lossVm.totalCourtFee = lossVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                lossVm.totalReceiveBack = lossVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //            }

        //            lossVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //            if (!lossVm.ListOfExpense.Count.Equals(0))
        //            {
        //                lossVm.totalExpensePayment = lossVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                lossVm.totalExpenseNet = lossVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                lossVm.totalExpenseTax = lossVm.ListOfExpense.Select(x => x.WHT).Sum();
        //                lossVm.totalExpenseVat = lossVm.ListOfExpense.Select(x => x.VAT).Sum();

        //            }

        //            lossVm.ListOfJudgmentDebtor = db.SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB(job.JOB_ID).ToList();

        //            var repo = db.SP_SELECT_LEGAL_REPO_BY_JOB(job.JOB_ID).FirstOrDefault();
        //            if (repo != null)
        //                lossVm.Repo = repo;
        //        }
        //        return PartialView(lossVm);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ////--- LC010	AMLO คดี ปปง
        //public ActionResult _AMLOCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var amloVm = new AMLO();
        //    amloVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC010")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC010" && x.JOB_STATUS == "A").ToList();

        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        amloVm.HasData = true;
        //        amloVm.RefNo = job.JOB_ID;
        //        amloVm.ContractNo = job.JOB_CONTRACT_NO;
        //        amloVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        amloVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        amloVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        amloVm.AMLOrderNo = job.JOB_AML_ORDER_NO;
        //        amloVm.Remark = job.JOB_REMARK;
        //        amloVm.RequestDate = job.JOB_REQUEST_DATE;
        //        amloVm.AMLOrderDate = job.JOB_AML_ORDER_DATE;
        //        amloVm.LegalCase = Constants.LegalCase.LC010;
        //        amloVm.CssActive = cssActive;
        //        amloVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        amloVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!amloVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            amloVm.totalCourtFee = amloVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            amloVm.totalReceiveBack = amloVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        amloVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!amloVm.ListOfExpense.Count.Equals(0))
        //        {
        //            amloVm.totalExpensePayment = amloVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            amloVm.totalExpenseNet = amloVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            amloVm.totalExpenseTax = amloVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            amloVm.totalExpenseVat = amloVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(amloVm);
        //}

        ////--- LC009	ONCB คดี ปปส
        //public ActionResult _ONCBCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var oncbVm = new ONCB();
        //    oncbVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC009")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();

        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC009" && x.JOB_STATUS == "A").ToList();
        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        oncbVm.HasData = true;
        //        oncbVm.RefNo = job.JOB_ID;
        //        oncbVm.ContractNo = job.JOB_CONTRACT_NO;
        //        oncbVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        oncbVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        oncbVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        oncbVm.Remark = job.JOB_REMARK;
        //        oncbVm.RequestDate = job.JOB_REQUEST_DATE;
        //        //oncbVm.AMLOrderNo = job.JOB_AML_ORDER_NO;
        //        //oncbVm.AMLOrderDate = job.JOB_AML_ORDER_DATE;
        //        oncbVm.LegalCase = Constants.LegalCase.LC009;
        //        oncbVm.CssActive = cssActive;
        //        oncbVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        oncbVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!oncbVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            oncbVm.totalCourtFee = oncbVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            oncbVm.totalReceiveBack = oncbVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        oncbVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!oncbVm.ListOfExpense.Count.Equals(0))
        //        {
        //            oncbVm.totalExpensePayment = oncbVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            oncbVm.totalExpenseNet = oncbVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            oncbVm.totalExpenseTax = oncbVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            oncbVm.totalExpenseVat = oncbVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(oncbVm);
        //}

        ////--- LC003 Embezzle ยักยอกทรัพย์
        //public ActionResult _EmbezzleCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var embVm = new Embezzle();
        //    embVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC003")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();

        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC003" && x.JOB_STATUS == "A").ToList();

        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        embVm.HasData = true;
        //        embVm.RefNo = job.JOB_ID;
        //        embVm.ContractNo = job.JOB_CONTRACT_NO;
        //        embVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        embVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        embVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        embVm.Remark = job.JOB_REMARK;
        //        embVm.RequestDate = job.JOB_REQUEST_DATE;
        //        embVm.LegalCase = Constants.LegalCase.LC003;
        //        embVm.CssActive = cssActive;
        //        embVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        embVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!embVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            embVm.totalCourtFee = embVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            embVm.totalReceiveBack = embVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        embVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!embVm.ListOfExpense.Count.Equals(0))
        //        {
        //            embVm.totalExpensePayment = embVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            embVm.totalExpenseNet = embVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            embVm.totalExpenseTax = embVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            embVm.totalExpenseVat = embVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(embVm);
        //}

        ////--- LC004 Embezzle2 คดีฉ้อโกง
        //public ActionResult _EmbezzleCase2(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var embVm = new Embezzle2();
        //    embVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC004")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC004" && x.JOB_STATUS == "A").ToList();



        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();

        //        embVm.HasData = true;
        //        embVm.RefNo = job.JOB_ID;
        //        embVm.ContractNo = job.JOB_CONTRACT_NO;
        //        embVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        embVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        embVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        embVm.Remark = job.JOB_REMARK;
        //        embVm.RequestDate = job.JOB_REQUEST_DATE;
        //        embVm.LegalCase = Constants.LegalCase.LC004;
        //        embVm.CssActive = cssActive;
        //        embVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        embVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!embVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            embVm.totalCourtFee = embVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            embVm.totalReceiveBack = embVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        embVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!embVm.ListOfExpense.Count.Equals(0))
        //        {
        //            embVm.totalExpensePayment = embVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            embVm.totalExpenseNet = embVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            embVm.totalExpenseTax = embVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            embVm.totalExpenseVat = embVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(embVm);
        //}

        ////--- LC005 Embezzle3 คดีโกงเจ้าหนี้
        //public ActionResult _EmbezzleCase3(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var embVm = new Embezzle3();
        //    embVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC005")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC005" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        embVm.HasData = true;
        //        embVm.RefNo = job.JOB_ID;
        //        embVm.ContractNo = job.JOB_CONTRACT_NO;
        //        embVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        embVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        embVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        embVm.Remark = job.JOB_REMARK;
        //        embVm.RequestDate = job.JOB_REQUEST_DATE;
        //        embVm.LegalCase = Constants.LegalCase.LC005;
        //        embVm.CssActive = cssActive;
        //        embVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        embVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!embVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            embVm.totalCourtFee = embVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            embVm.totalReceiveBack = embVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        embVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!embVm.ListOfExpense.Count.Equals(0))
        //        {
        //            embVm.totalExpensePayment = embVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            embVm.totalExpenseNet = embVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            embVm.totalExpenseTax = embVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            embVm.totalExpenseVat = embVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(embVm);
        //}
        ////--- LC008	Exhibit ร้องคืนของกลาง
        //public ActionResult _ExhibitCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var exhVm = new Exhibit();
        //    exhVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC008")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC008" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        exhVm.HasData = true;
        //        exhVm.RefNo = job.JOB_ID;
        //        exhVm.ContractNo = job.JOB_CONTRACT_NO;
        //        exhVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        exhVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        exhVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        exhVm.Remark = job.JOB_REMARK;
        //        exhVm.RequestDate = job.JOB_REQUEST_DATE;
        //        exhVm.CarReceiveDate = job.JOB_CAR_RECEIVE_DATE;
        //        exhVm.LegalCase = Constants.LegalCase.LC008;
        //        exhVm.CssActive = cssActive;
        //        exhVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        exhVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!exhVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            exhVm.totalCourtFee = exhVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            exhVm.totalReceiveBack = exhVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        exhVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!exhVm.ListOfExpense.Count.Equals(0))
        //        {
        //            exhVm.totalExpensePayment = exhVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            exhVm.totalExpenseNet = exhVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            exhVm.totalExpenseTax = exhVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            exhVm.totalExpenseVat = exhVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(exhVm);
        //}

        ////--- LC006 Bankruptcy ล้มละลาย
        //public ActionResult _BankruptcyCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var bkrpVm = new Bankruptcy();
        //    bkrpVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC006")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC006" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        bkrpVm.HasData = true;
        //        bkrpVm.RefNo = job.JOB_ID;
        //        bkrpVm.ContractNo = job.JOB_CONTRACT_NO;
        //        bkrpVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        bkrpVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        bkrpVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        bkrpVm.Remark = job.JOB_REMARK;
        //        bkrpVm.RequestDate = job.JOB_REQUEST_DATE;
        //        bkrpVm.ReceiveOrderDate = job.JOB_RECEIVE_ORDER_DATE;
        //        bkrpVm.AnnounceDate = job.JOB_ANNOUNCE_DATE;
        //        bkrpVm.LastDueDate = job.JOB_LAST_DUE_DATE;
        //        bkrpVm.AppointedDate = job.JOB_APPOINTED_DATE;
        //        bkrpVm.PlaintiffName = job.JOB_PLAINTIFF_NAME;
        //        bkrpVm.LegalCase = Constants.LegalCase.LC006;
        //        bkrpVm.CssActive = cssActive;
        //        bkrpVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        bkrpVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!bkrpVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            bkrpVm.totalCourtFee = bkrpVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            bkrpVm.totalReceiveBack = bkrpVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        bkrpVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!bkrpVm.ListOfExpense.Count.Equals(0))
        //        {
        //            bkrpVm.totalExpensePayment = bkrpVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            bkrpVm.totalExpenseNet = bkrpVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            bkrpVm.totalExpenseTax = bkrpVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            bkrpVm.totalExpenseVat = bkrpVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(bkrpVm);
        //}

        ////--- LC013 Claim เคลมประกัน คดีรถหาย
        //public ActionResult _ClaimCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var clmVm = new Claim();
        //    clmVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC013")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();

        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC013" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        clmVm.HasData = true;
        //        clmVm.RefNo = job.JOB_ID;
        //        clmVm.ContractNo = job.JOB_CONTRACT_NO;
        //        clmVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        clmVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        clmVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        clmVm.Remark = job.JOB_REMARK;
        //        clmVm.RequestDate = job.JOB_REQUEST_DATE;
        //        clmVm.TotalLossAmount = cm.UnDecimalNull(job.JOB_TOTAL_LOSS_AMOUNT);
        //        clmVm.Insurer = job.JOB_INSURER_NAME;
        //        clmVm.AssuredAmount = cm.UnDecimalNull(job.JOB_ASSURED_AMOUNT);
        //        clmVm.LegalCase = Constants.LegalCase.LC013;
        //        clmVm.CssActive = cssActive;
        //        clmVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        clmVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!clmVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            clmVm.totalCourtFee = clmVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            clmVm.totalReceiveBack = clmVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        clmVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!clmVm.ListOfExpense.Count.Equals(0))
        //        {
        //            clmVm.totalExpensePayment = clmVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            clmVm.totalExpenseNet = clmVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            clmVm.totalExpenseTax = clmVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            clmVm.totalExpenseVat = clmVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(clmVm);
        //}


        ////--- LC014 Claim เคลมประกัน เสียหายโดยสิ้นเชิง
        //public ActionResult _ClaimCase2(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var clmVm = new Claim2();
        //    clmVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC014")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();

        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC014" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        clmVm.HasData = true;
        //        clmVm.RefNo = job.JOB_ID;
        //        clmVm.ContractNo = job.JOB_CONTRACT_NO;
        //        clmVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        clmVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        clmVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        clmVm.Remark = job.JOB_REMARK;
        //        clmVm.RequestDate = job.JOB_REQUEST_DATE;
        //        clmVm.TotalLossAmount = cm.UnDecimalNull(job.JOB_TOTAL_LOSS_AMOUNT);
        //        clmVm.Insurer = job.JOB_INSURER_NAME;
        //        clmVm.AssuredAmount = cm.UnDecimalNull(job.JOB_ASSURED_AMOUNT);
        //        clmVm.LegalCase = Constants.LegalCase.LC014;
        //        clmVm.CssActive = cssActive;
        //        clmVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        clmVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!clmVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            clmVm.totalCourtFee = clmVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            clmVm.totalReceiveBack = clmVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        clmVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!clmVm.ListOfExpense.Count.Equals(0))
        //        {
        //            clmVm.totalExpensePayment = clmVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            clmVm.totalExpenseNet = clmVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            clmVm.totalExpenseTax = clmVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            clmVm.totalExpenseVat = clmVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(clmVm);
        //}

        ////--- LC002 OCPB สคบ
        //public ActionResult _OCPBCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var ocpbVm = new OCPB();
        //    ocpbVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC002")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC002" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        ocpbVm.HasData = true;
        //        ocpbVm.RefNo = job.JOB_ID;
        //        ocpbVm.ContractNo = job.JOB_CONTRACT_NO;
        //        ocpbVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        ocpbVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        ocpbVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        ocpbVm.Remark = job.JOB_REMARK;
        //        ocpbVm.RequestDate = job.JOB_REQUEST_DATE;
        //        ocpbVm.Requestor = job.JOB_REQUESTOR;
        //        ocpbVm.AppointedDate = job.JOB_APPOINTED_DATE;
        //        ocpbVm.LegalCase = Constants.LegalCase.LC002;
        //        ocpbVm.CssActive = cssActive;
        //        ocpbVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        ocpbVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!ocpbVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            ocpbVm.totalCourtFee = ocpbVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            ocpbVm.totalReceiveBack = ocpbVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        ocpbVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!ocpbVm.ListOfExpense.Count.Equals(0))
        //        {
        //            ocpbVm.totalExpensePayment = ocpbVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            ocpbVm.totalExpenseNet = ocpbVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            ocpbVm.totalExpenseTax = ocpbVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            ocpbVm.totalExpenseVat = ocpbVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(ocpbVm);
        //}

        ////--- LC001 Other คดีอื่นๆ
        //public ActionResult _OtherCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var othVm = new Other();
        //    othVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC001")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();
        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC001" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        othVm.HasData = true;
        //        othVm.RefNo = job.JOB_ID;
        //        othVm.ContractNo = job.JOB_CONTRACT_NO;
        //        othVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        othVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        othVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        othVm.Remark = job.JOB_REMARK;
        //        othVm.RequestDate = job.JOB_REQUEST_DATE;
        //        othVm.LegalCaseName = job.JOB_CASE_OTHER;
        //        othVm.LegalCase = Constants.LegalCase.LC001;
        //        othVm.CssActive = cssActive;
        //        othVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        othVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!othVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            othVm.totalCourtFee = othVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            othVm.totalReceiveBack = othVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        othVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!othVm.ListOfExpense.Count.Equals(0))
        //        {
        //            othVm.totalExpensePayment = othVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            othVm.totalExpenseNet = othVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            othVm.totalExpenseTax = othVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            othVm.totalExpenseVat = othVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(othVm);
        //}

        ////--- LC012 Cheque เช็ค
        //public ActionResult _ChequeCase(string refNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var chqVm = new Cheque();
        //    chqVm.ReadOnly = readOnly;

        //        //var job = db.T_JOB_LEGAL.Where(x => x.JOB_ID == refNo && x.JOB_CASE == "LC012")
        //        //  .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();

        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_ID == refNo && x.JOB_CASE == "LC012" && x.JOB_STATUS == "A").ToList();



        //        if (!jobList.Count.Equals(0))
        //        {
        //            var job = jobList.FirstOrDefault();
        //            chqVm.HasData = true;
        //            chqVm.RefNo = job.JOB_ID;
        //            chqVm.ContractNo = job.JOB_CONTRACT_NO;
        //            chqVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //            chqVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //            chqVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //            chqVm.Remark = job.JOB_REMARK;
        //            chqVm.PayerName = job.JOB_CUST_NAME;
        //            chqVm.Address = job.JOB_CUST_ADDRESS;
        //            chqVm.LegalCase = Constants.LegalCase.LC012;
        //            chqVm.CssActive = cssActive;
        //            chqVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();
        //            chqVm.RequestDate = job.JOB_REQUEST_DATE;
        //            chqVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //            if (!chqVm.ListOfCourtFee.Count.Equals(0))
        //            {
        //                chqVm.totalCourtFee = chqVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //                chqVm.totalReceiveBack = chqVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //            }

        //            chqVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //            if (!chqVm.ListOfExpense.Count.Equals(0))
        //            {
        //                chqVm.totalExpensePayment = chqVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //                chqVm.totalExpenseNet = chqVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //                chqVm.totalExpenseTax = chqVm.ListOfExpense.Select(x => x.WHT).Sum();
        //                chqVm.totalExpenseVat = chqVm.ListOfExpense.Select(x => x.VAT).Sum();

        //            }

        //            chqVm.ListOfContract = db.SP_SEARCH_CHEQUE_CONTRACT(job.JOB_ID).ToList();
        //        }


        //    return PartialView(chqVm);
        //}

        ////--- LC007	Rehabilitation ฟื้นฟูกิจการ
        //public ActionResult _RehabilitationCase(string contractNo, string cssActive = "", string readOnly = "Y")
        //{
        //    var rehVm = new Rehabilitation();
        //    rehVm.ReadOnly = readOnly;
        //    //var job = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC007")
        //    //    .Select(x => x).OrderByDescending(x => x.JOB_ID).FirstOrDefault();

        //    var jobList = db.T_JOB_LEGAL.Where(x => x.JOB_CONTRACT_NO == contractNo && x.JOB_CASE == "LC007" && x.JOB_STATUS == "A").ToList();


        //    if (!jobList.Count.Equals(0))
        //    {
        //        var job = jobList.FirstOrDefault();
        //        rehVm.HasData = true;
        //        rehVm.RefNo = job.JOB_ID;
        //        rehVm.ContractNo = job.JOB_CONTRACT_NO;
        //        rehVm.Admin = cm.GetNameUserByCode(job.JOB_ADMIN_CODE);
        //        rehVm.AssignOADate = job.JOB_ASSIGN_OA_DATE;
        //        rehVm.LegalOA = cm.GetNameOAByCode(job.JOB_OA_CODE);
        //        rehVm.Remark = job.JOB_REMARK;
        //        rehVm.RequestDate = job.JOB_REQUEST_DATE;
        //        rehVm.Requestor = job.JOB_REQUESTOR;
        //        rehVm.TheCompanyPlan = job.JOB_COMPANY_PLAN;
        //        rehVm.OrderedRehabilitation = job.JOB_ORDERED_REH;
        //        rehVm.LegalCase = Constants.LegalCase.LC007;
        //        rehVm.CssActive = cssActive;
        //        rehVm.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(job.JOB_ID).ToList();

        //        rehVm.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(job.JOB_ID).ToList();
        //        if (!rehVm.ListOfCourtFee.Count.Equals(0))
        //        {
        //            rehVm.totalCourtFee = rehVm.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
        //            rehVm.totalReceiveBack = rehVm.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
        //        }

        //        rehVm.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(job.JOB_ID).ToList();
        //        if (!rehVm.ListOfExpense.Count.Equals(0))
        //        {
        //            rehVm.totalExpensePayment = rehVm.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
        //            rehVm.totalExpenseNet = rehVm.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
        //            rehVm.totalExpenseTax = rehVm.ListOfExpense.Select(x => x.WHT).Sum();
        //            rehVm.totalExpenseVat = rehVm.ListOfExpense.Select(x => x.VAT).Sum();

        //        }

        //    }
        //    return PartialView(rehVm);
        //}

        //[HttpPost]
        //public ActionResult SaveTracking(T_LEGAL_TRACKING SelectedTracking)
        //{
        //    string message = Constants.Msg.SaveFail;
        //    string result = Constants.Result.False;
        //    try
        //    {

        //        var jobLegal = db.T_JOB_LEGAL.Find(SelectedTracking.LEGAL_JOB_ID);

        //        if (jobLegal != null)
        //        {
        //            if (jobLegal.JOB_LEGAL_STATUS != SelectedTracking.LEGAL_STATUS)
        //            jobLegal.JOB_STEP_DATE = cm.SystemDate;

        //            jobLegal.JOB_LEGAL_STATUS = SelectedTracking.LEGAL_STATUS;                 
        //            jobLegal.JOB_FILING_DATE = SelectedTracking.LEGAL_FILING_DATE;
        //            jobLegal.JOB_CAR_RECEIVE_PLACE = SelectedTracking.LEGAL_CAR_RECEIVED_PLACE;
        //            jobLegal.JOB_AMOUNT_CLAIMED = SelectedTracking.LEGAL_AMOUNT_CLAIMED;
        //            jobLegal.JOB_MAILING_DATE = SelectedTracking.LEGAL_MAILING_DATE;
        //            jobLegal.JOB_DEBTOR_STATUS = SelectedTracking.LEGAL_DEBTOR_STATUS;
        //            jobLegal.JOB_BLACK_CODE = SelectedTracking.LEGAL_BLACK_CODE;
        //            jobLegal.JOB_RED_CODE = SelectedTracking.LEGAL_RED_CODE;
        //            jobLegal.JOB_ATTORNEY_STATUS = SelectedTracking.LEGAL_ATTORNEY_STATUS;
        //            jobLegal.JOB_COURT_CODE = SelectedTracking.LEGAL_COURT_CODE;
        //            jobLegal.JOB_COURT_FEE = SelectedTracking.LEGAL_COURT_FEE;
        //            jobLegal.JOB_POLICE_STATION = SelectedTracking.LEGAL_POLICE_STATION;
        //            jobLegal.JOB_SUBMISSION_DATE = SelectedTracking.LEGAL_SUBMISSION_DATE;
        //            jobLegal.JOB_SUBMISSION_AMOUNT = SelectedTracking.LEGAL_SUBMISSION_AMOUNT;
        //            jobLegal.JOB_CONTRACT_TERMINATED_DATE = SelectedTracking.LEGAL_CONTRACT_TERMINATED_DATE;
        //            jobLegal.JOB_LACK_OF_BENEFIT = SelectedTracking.LEGAL_LACK_OF_BENEFIT;
        //            jobLegal.JOB_CHEQUE_NO = SelectedTracking.LEGAL_CHEQUE_NO;
        //            jobLegal.JOB_NOTIFY_CHEQUE_DATE = SelectedTracking.LEGAL_NOTIFY_CHEQUE_DATE;
        //            jobLegal.JOB_PARTY_IN_LAW_SUIT = SelectedTracking.LEGAL_PARTY_IN_LAW_SUIT;
        //            jobLegal.JOB_APPOINTED_DATE = SelectedTracking.LEGAL_APPOINTED_DATE;
        //            jobLegal.JOB_ASSIGNED_DATE = SelectedTracking.LEGAL_ASSIGNED_DATE;
        //            jobLegal.JOB_ATTORNEY_DATE = SelectedTracking.LEGAL_ATTORNEY_DATE;
        //            jobLegal.JOB_NOTICE_DATE = SelectedTracking.LEGAL_NOTICE_DATE;
        //            jobLegal.JOB_WITNESS_DATE = SelectedTracking.LEGAL_WITNESS_DATE;
        //            jobLegal.JOB_WITNESS_TIME = SelectedTracking.LEGAL_WITNESS_TIME;
        //            jobLegal.JOB_LAWYER_FEE = SelectedTracking.LEGAL_LAWYER_FEE;
        //            jobLegal.JOB_SECOND_LAWYER_FEE = SelectedTracking.LEGAL_SECOND_LAWYER_FEE;
        //            jobLegal.JOB_ENFORCEMENT_DATE = SelectedTracking.LEGAL_ENFORCEMENT_DATE;
        //            jobLegal.JOB_BANKRUPTCY_DATE = SelectedTracking.LEGAL_BANKRUPTCY_DATE;
        //            jobLegal.JOB_BANKRUPTCY_DISCHARGED_DATE = SelectedTracking.LEGAL_BANKRUPTCY_DISCHARGED_DATE;
        //            jobLegal.JOB_POL_NO = SelectedTracking.LEGAL_POL_NO;
        //            jobLegal.JOB_STOLEN_NO = SelectedTracking.LEGAL_STOLEN_NO;
        //            jobLegal.JOB_APPOINTMENT_CHECK_DATE = SelectedTracking.LEGAL_APPOINTMENT_CHECK_DATE;
        //            jobLegal.JOB_OA_ENFORCEMENT = SelectedTracking.LEGAL_OA_ENFORCEMENT;
        //            jobLegal.JOB_SUBMIT_ENFORCEMENT_DATE = SelectedTracking.LEGAL_SUBMIT_ENFORCEMENT_DATE;
        //            jobLegal.JOB_OA_ASSET_SEARCH = SelectedTracking.LEGAL_OA_ASSET_SEARCH;
        //            jobLegal.JOB_SUBMIT_INVEST_DATE = SelectedTracking.LEGAL_SUBMIT_INVEST_DATE;
        //            jobLegal.JOB_ENFORCEMENT_EFF_DATE = SelectedTracking.LEGAL_ENFORCEMENT_EFF_DATE;
        //            jobLegal.JOB_CASH_RECEIVE_DATE = SelectedTracking.LEGAL_CASH_RECEIVE_DATE;
        //            jobLegal.JOB_SEIZE_DATE = SelectedTracking.LEGAL_SEIZE_DATE;
        //            jobLegal.JOB_REPORT_DATE = SelectedTracking.LEGAL_REPORT_DATE;
        //            jobLegal.JOB_JUDGMENT_DATE = SelectedTracking.LEGAL_JUDGMENT_DATE;
        //            jobLegal.JOB_WITHDRAW_DATE = SelectedTracking.LEGAL_WITHDRAW_DATE;
        //            jobLegal.JOB_EXECUTION_DATE = SelectedTracking.LEGAL_EXECUTION_DATE;
        //            jobLegal.JOB_EXECUTION_END_DATE = SelectedTracking.LEGAL_EXECUTION_END_DATE;
        //            jobLegal.JOB_DETAILS = SelectedTracking.LEGAL_DETAILS;
        //            jobLegal.JOB_UPDATE_BY = cm.UserLogin;
        //            jobLegal.JOB_UPDATE_DATE = cm.SystemDate;

        //        }
        //        SelectedTracking.LEGAL_SEQ_NO = 1;

        //        var seq = db.T_LEGAL_TRACKING.Where(x => x.LEGAL_JOB_ID == SelectedTracking.LEGAL_JOB_ID).ToList();


        //        if(!seq.Count.Equals(0))
        //        {
        //             SelectedTracking.LEGAL_SEQ_NO =(seq.Max(x => x.LEGAL_SEQ_NO)) + 1;
        //        }


        //        SelectedTracking.LEGAL_CREATE_BY = cm.UserLogin;
        //        SelectedTracking.LEGAL_CREATE_DATE = cm.SystemDate;
        //        SelectedTracking.LEGAL_UPDATE_BY = cm.UserLogin;
        //        SelectedTracking.LEGAL_UPDATE_DATE = cm.SystemDate;
        //        SelectedTracking.LEGAL_TRACKING_BY = cm.UserLogin;
        //        SelectedTracking.LEGAL_TRACKING_DATE = cm.SystemDate;
        //        db.T_LEGAL_TRACKING.Add(SelectedTracking);
        //        db.SaveChanges();
        //        message = Constants.Msg.SaveSucc;
        //        result = Constants.Result.True;
        //        return Json(new { message = message, result = result});
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { message = ex.Message, result = result });
        //    }
        //}


        public ActionResult LegalCase(string id = "")
        {

            var model = new LegalCase();
            model.DefaultRefNo = id;
            model.RefNo = id;
            model.ContractNo = "";
            if (id != "")
            {
                var jobLegal = db.T_JOB_LEGAL.Where(x => x.JOB_ID == id).FirstOrDefault();
                model.ContractNo = (jobLegal.JOB_CONTRACT_NO == null) ? "" : jobLegal.JOB_CONTRACT_NO;
                if (model.ContractNo == "")
                {
                    var chqContract = db.T_CHEQUE_DETAIL.Where(x => x.CHQ_JOB_ID == id).FirstOrDefault();
                    model.ContractNo = (chqContract == null) ? "" : chqContract.CHQ_CONTRACT_NO;
                }
            }
            return View(model);
        }
        public ActionResult _LegalCase(string contractNo, string defaultRefNo)
        {
            try
            {
                var model = new LegalCase();
                model.ContractNo = contractNo;
                model.RefNo = defaultRefNo;
                model.DefaultRefNo = defaultRefNo;
                model.ListOfCase = db.SP_SELECT_LEGAL_CASE_BY_JOB(defaultRefNo, contractNo).ToList();

                if (cm.IsNullOrEmpty(defaultRefNo))
                {
                    if (model.ListOfCase.Count > 0)
                    {
                        model.RefNo = model.ListOfCase.FirstOrDefault().JOB_ID;
                        model.ListOfCase.FirstOrDefault().CSS_ACTIVE = " active";
                        model.DefaultRefNo = "";
                    }
                }

                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _DetailCase(string refNo, string defaultRefNo = "")
        {
            try
            {
                var model = new LegalCase();

                var jobLegal = db.T_JOB_LEGAL.Where(x => x.JOB_ID == refNo).FirstOrDefault();
                if (jobLegal != null)
                {

                    model.DefaultRefNo = defaultRefNo;
                    model.RefNo = jobLegal.JOB_ID;
                    model.ContractNo = jobLegal.JOB_CONTRACT_NO;
                    model.LegalCaseCode = jobLegal.JOB_CASE;


                }



                //model.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(refNo).ToList();
                //model.ListOfContract = db.SP_SEARCH_CHEQUE_CONTRACT(refNo).ToList();
                //model.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(refNo).ToList();
                //model.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(refNo).ToList();

                //var repo = db.SP_SELECT_LEGAL_REPO_BY_JOB(refNo).FirstOrDefault();
                //if (repo != null)
                //    model.Repo = repo;

                //var CarReceives = db.SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB(refNo).FirstOrDefault();
                //if (CarReceives != null)
                //    model.CarReceives = CarReceives;


                //if (!model.ListOfCourtFee.Count.Equals(0))
                //{
                //    model.totalCourtFee = model.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
                //    model.totalReceiveBack = model.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
                //}            
                //if (!model.ListOfExpense.Count.Equals(0))
                //{
                //    model.totalExpensePayment = model.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
                //    model.totalExpenseNet = model.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
                //    model.totalExpenseTax = model.ListOfExpense.Select(x => x.WHT).Sum();
                //    model.totalExpenseVat = model.ListOfExpense.Select(x => x.VAT).Sum();

                //}


                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _LegalTrackingCase(string refNo, string defaultRefNo = "", string contractNo = "", string legalCase = "")
        {
            var model = new LegalCase();


            model.RefNo = refNo;
            model.ContractNo = contractNo;
            model.DefaultRefNo = defaultRefNo;
            model.LegalCaseCode = legalCase;
            model.SelectedTracking = new T_LEGAL_TRACKING();
            model.ListOfTracking = new List<SP_SELECT_LEGAL_TRACKING_BY_CASE_Result>();

            model.ListOfTracking = db.SP_SELECT_LEGAL_TRACKING_BY_CASE(refNo).ToList();
            var legal = db.T_JOB_LEGAL.Where(t => t.JOB_ID == refNo).FirstOrDefault();
            if (legal != null)
            {
                // เอาข้อมูลที่ JOB_LEGAL มาใส่ Tracking
                model.SelectedTracking.LEGAL_JOB_ID = refNo;
                model.SelectedTracking.LEGAL_SEQ_NO = 1;
                model.SelectedTracking.LEGAL_CASE = legalCase;
                model.SelectedTracking.LEGAL_CONTRACT_NO = contractNo;
                model.SelectedTracking.LEGAL_TRACKING_DATE = legal.JOB_UPDATE_DATE;
                model.SelectedTracking.LEGAL_TRACKING_BY = legal.JOB_UPDATE_BY;
                model.SelectedTracking.LEGAL_MAILING_DATE = legal.JOB_MAILING_DATE;
                model.SelectedTracking.LEGAL_FILING_DATE = legal.JOB_FILING_DATE;
                model.SelectedTracking.LEGAL_STATUS = legal.JOB_LEGAL_STATUS;
                model.SelectedTracking.LEGAL_DEBTOR_STATUS = legal.JOB_DEBTOR_STATUS;
                model.SelectedTracking.LEGAL_BLACK_CODE = legal.JOB_BLACK_CODE;
                model.SelectedTracking.LEGAL_RED_CODE = legal.JOB_RED_CODE;
                model.SelectedTracking.LEGAL_ATTORNEY_STATUS = legal.JOB_ATTORNEY_STATUS;
                model.SelectedTracking.LEGAL_COURT_CODE = legal.JOB_COURT_CODE;
                model.SelectedTracking.LEGAL_COURT_FEE = legal.JOB_COURT_FEE;
                model.SelectedTracking.LEGAL_AMOUNT_CLAIMED = legal.JOB_AMOUNT_CLAIMED;
                model.SelectedTracking.LEGAL_POLICE_STATION = legal.JOB_POLICE_STATION;
                model.SelectedTracking.LEGAL_CAR_RECEIVED_PLACE = legal.JOB_CAR_RECEIVE_PLACE;
                model.SelectedTracking.LEGAL_SUBMISSION_DATE = legal.JOB_SUBMISSION_DATE;
                model.SelectedTracking.LEGAL_SUBMISSION_AMOUNT = legal.JOB_SUBMISSION_AMOUNT;
                model.SelectedTracking.LEGAL_CONTRACT_TERMINATED_DATE = legal.JOB_CONTRACT_TERMINATED_DATE;
                model.SelectedTracking.LEGAL_LACK_OF_BENEFIT = legal.JOB_LACK_OF_BENEFIT;
                model.SelectedTracking.LEGAL_CHEQUE_NO = legal.JOB_CHEQUE_NO;
                model.SelectedTracking.LEGAL_NOTIFY_CHEQUE_DATE = legal.JOB_NOTIFY_CHEQUE_DATE;
                model.SelectedTracking.LEGAL_PARTY_IN_LAW_SUIT = legal.JOB_PARTY_IN_LAW_SUIT;
                model.SelectedTracking.LEGAL_APPOINTED_DATE = legal.JOB_APPOINTED_DATE;
                model.SelectedTracking.LEGAL_ASSIGNED_DATE = legal.JOB_ASSIGNED_DATE;
                model.SelectedTracking.LEGAL_ATTORNEY_DATE = legal.JOB_ATTORNEY_DATE;
                model.SelectedTracking.LEGAL_NOTICE_DATE = legal.JOB_NOTICE_DATE;
                model.SelectedTracking.LEGAL_WITNESS_DATE = legal.JOB_WITNESS_DATE;
                model.SelectedTracking.LEGAL_WITNESS_TIME = legal.JOB_WITNESS_TIME;
                model.SelectedTracking.LEGAL_LAWYER_FEE = legal.JOB_LAWYER_FEE;
                model.SelectedTracking.LEGAL_SECOND_LAWYER_FEE = legal.JOB_SECOND_LAWYER_FEE;
                model.SelectedTracking.LEGAL_ENFORCEMENT_DATE = legal.JOB_ENFORCEMENT_DATE;
                model.SelectedTracking.LEGAL_BANKRUPTCY_DATE = legal.JOB_BANKRUPTCY_DATE;
                model.SelectedTracking.LEGAL_BANKRUPTCY_DISCHARGED_DATE = legal.JOB_BANKRUPTCY_DATE;
                model.SelectedTracking.LEGAL_POL_NO = legal.JOB_POL_NO;
                model.SelectedTracking.LEGAL_STOLEN_NO = legal.JOB_STOLEN_NO;
                model.SelectedTracking.LEGAL_APPOINTMENT_CHECK_DATE = legal.JOB_APPOINTMENT_CHECK_DATE;
                model.SelectedTracking.LEGAL_OA_ENFORCEMENT = legal.JOB_OA_ENFORCEMENT;
                model.SelectedTracking.LEGAL_SUBMIT_ENFORCEMENT_DATE = legal.JOB_SUBMIT_ENFORCEMENT_DATE;
                model.SelectedTracking.LEGAL_OA_ASSET_SEARCH = legal.JOB_OA_ASSET_SEARCH;
                model.SelectedTracking.LEGAL_SUBMIT_INVEST_DATE = legal.JOB_SUBMIT_INVEST_DATE;
                model.SelectedTracking.LEGAL_ENFORCEMENT_EFF_DATE = legal.JOB_ENFORCEMENT_EFF_DATE;
                model.SelectedTracking.LEGAL_CASH_RECEIVE_DATE = legal.JOB_CASH_RECEIVE_DATE;
                model.SelectedTracking.LEGAL_SEIZE_DATE = legal.JOB_SEIZE_DATE;
                model.SelectedTracking.LEGAL_REPORT_DATE = legal.JOB_REPORT_DATE;
                model.SelectedTracking.LEGAL_JUDGMENT_DATE = legal.JOB_JUDGMENT_DATE;
                model.SelectedTracking.LEGAL_WITHDRAW_DATE = legal.JOB_WITHDRAW_DATE;
                model.SelectedTracking.LEGAL_EXECUTION_DATE = legal.JOB_EXECUTION_DATE;
                model.SelectedTracking.LEGAL_EXECUTION_END_DATE = legal.JOB_EXECUTION_END_DATE;
                model.SelectedTracking.LEGAL_DETAILS = legal.JOB_DETAILS;
                model.SelectedTracking.LEGAL_CREATE_DATE = legal.JOB_CREATE_DATE;
                model.SelectedTracking.LEGAL_CREATE_BY = legal.JOB_CREATE_BY;
                model.SelectedTracking.LEGAL_UPDATE_DATE = legal.JOB_UPDATE_DATE;
                model.SelectedTracking.LEGAL_UPDATE_BY = legal.JOB_UPDATE_BY;
                // ใส่ให้ครบ
            }
            return PartialView(model);
        }
        public ActionResult _GetLegalTrackingBySeq(string seqNo, string refNo)
        {
            var tracking = new LegalCase();
            int seq = 0;
            try
            {
                seq = cm.UnInt32Null(seqNo);

                var model = db.T_LEGAL_TRACKING.Where(xx => xx.LEGAL_JOB_ID == refNo && xx.LEGAL_SEQ_NO == seq).FirstOrDefault();

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }


        }
        public ActionResult _AttachmentCase(string refNo)
        {
            try
            {
                var model = new LegalCase();


                model.ListOfAttachment = db.SP_SELECT_LEGAL_ATTACH_BY_JOB(refNo).ToList();


                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _CarReceivesCase(string refNo)
        {
            try
            {
                var model = new LegalCase();



                var CarReceives = db.SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB(refNo).FirstOrDefault();
                if (CarReceives != null)
                    model.CarReceives = CarReceives;




                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _ContractListCase(string refNo)
        {
            try
            {
                var model = new LegalCase();


                model.ListOfContract = db.SP_SEARCH_CHEQUE_CONTRACT(refNo).ToList();


                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _CourtFeeCase(string refNo)
        {
            try
            {
                var model = new LegalCase();


                model.ListOfCourtFee = db.SP_SELECT_LEGAL_COURT_FEE_BY_JOB(refNo).ToList();

                if (!model.ListOfCourtFee.Count.Equals(0))
                {
                    model.totalCourtFee = model.ListOfCourtFee.Select(x => x.COURT_FEE).Sum();
                    model.totalReceiveBack = model.ListOfCourtFee.Select(x => x.RECEIVE_BACK).Sum();
                }


                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _OtherExpenseCase(string refNo)
        {
            try
            {
                var model = new LegalCase();


                model.ListOfExpense = db.SP_SELECT_LEGAL_EXPENSE_BY_JOB(refNo).ToList();

                if (!model.ListOfExpense.Count.Equals(0))
                {
                    model.totalExpensePayment = model.ListOfExpense.Select(x => x.PAYMENT_AMOUNT).Sum();
                    model.totalExpenseNet = model.ListOfExpense.Select(x => x.NET_AMOUNT).Sum();
                    model.totalExpenseTax = model.ListOfExpense.Select(x => x.WHT).Sum();
                    model.totalExpenseVat = model.ListOfExpense.Select(x => x.VAT).Sum();

                }


                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult _RepossessionCase(string refNo)
        {
            try
            {
                var model = new LegalCase();



                var repo = db.SP_SELECT_LEGAL_REPO_BY_JOB(refNo).FirstOrDefault();
                if (repo != null)
                    model.Repo = repo;



                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveTracking(T_LEGAL_TRACKING SelectedTracking)
        {
            string message = Constants.Msg.SaveFail;
            string result = Constants.Result.False;
            try
            {

                var jobLegal = db.T_JOB_LEGAL.Find(SelectedTracking.LEGAL_JOB_ID);

                if (jobLegal != null)
                {
                    if (jobLegal.JOB_LEGAL_STATUS != SelectedTracking.LEGAL_STATUS)
                        jobLegal.JOB_STEP_DATE = cm.SystemDate;

                    jobLegal.JOB_LEGAL_STATUS = SelectedTracking.LEGAL_STATUS;
                    jobLegal.JOB_FILING_DATE = SelectedTracking.LEGAL_FILING_DATE;
                    jobLegal.JOB_CAR_RECEIVE_PLACE = SelectedTracking.LEGAL_CAR_RECEIVED_PLACE;
                    jobLegal.JOB_AMOUNT_CLAIMED = SelectedTracking.LEGAL_AMOUNT_CLAIMED;
                    jobLegal.JOB_MAILING_DATE = SelectedTracking.LEGAL_MAILING_DATE;
                    jobLegal.JOB_DEBTOR_STATUS = SelectedTracking.LEGAL_DEBTOR_STATUS;
                    jobLegal.JOB_BLACK_CODE = SelectedTracking.LEGAL_BLACK_CODE;
                    jobLegal.JOB_RED_CODE = SelectedTracking.LEGAL_RED_CODE;
                    jobLegal.JOB_ATTORNEY_STATUS = SelectedTracking.LEGAL_ATTORNEY_STATUS;
                    jobLegal.JOB_COURT_CODE = SelectedTracking.LEGAL_COURT_CODE;
                    jobLegal.JOB_COURT_FEE = SelectedTracking.LEGAL_COURT_FEE;
                    jobLegal.JOB_POLICE_STATION = SelectedTracking.LEGAL_POLICE_STATION;
                    jobLegal.JOB_SUBMISSION_DATE = SelectedTracking.LEGAL_SUBMISSION_DATE;
                    jobLegal.JOB_SUBMISSION_AMOUNT = SelectedTracking.LEGAL_SUBMISSION_AMOUNT;
                    jobLegal.JOB_CONTRACT_TERMINATED_DATE = SelectedTracking.LEGAL_CONTRACT_TERMINATED_DATE;
                    jobLegal.JOB_LACK_OF_BENEFIT = SelectedTracking.LEGAL_LACK_OF_BENEFIT;
                    jobLegal.JOB_CHEQUE_NO = SelectedTracking.LEGAL_CHEQUE_NO;
                    jobLegal.JOB_NOTIFY_CHEQUE_DATE = SelectedTracking.LEGAL_NOTIFY_CHEQUE_DATE;
                    jobLegal.JOB_PARTY_IN_LAW_SUIT = SelectedTracking.LEGAL_PARTY_IN_LAW_SUIT;
                    jobLegal.JOB_APPOINTED_DATE = SelectedTracking.LEGAL_APPOINTED_DATE;
                    jobLegal.JOB_ASSIGNED_DATE = SelectedTracking.LEGAL_ASSIGNED_DATE;
                    jobLegal.JOB_ATTORNEY_DATE = SelectedTracking.LEGAL_ATTORNEY_DATE;
                    jobLegal.JOB_NOTICE_DATE = SelectedTracking.LEGAL_NOTICE_DATE;
                    jobLegal.JOB_WITNESS_DATE = SelectedTracking.LEGAL_WITNESS_DATE;
                    jobLegal.JOB_WITNESS_TIME = SelectedTracking.LEGAL_WITNESS_TIME;
                    jobLegal.JOB_LAWYER_FEE = SelectedTracking.LEGAL_LAWYER_FEE;
                    jobLegal.JOB_SECOND_LAWYER_FEE = SelectedTracking.LEGAL_SECOND_LAWYER_FEE;
                    jobLegal.JOB_ENFORCEMENT_DATE = SelectedTracking.LEGAL_ENFORCEMENT_DATE;
                    jobLegal.JOB_BANKRUPTCY_DATE = SelectedTracking.LEGAL_BANKRUPTCY_DATE;
                    jobLegal.JOB_BANKRUPTCY_DISCHARGED_DATE = SelectedTracking.LEGAL_BANKRUPTCY_DISCHARGED_DATE;
                    jobLegal.JOB_POL_NO = SelectedTracking.LEGAL_POL_NO;
                    jobLegal.JOB_STOLEN_NO = SelectedTracking.LEGAL_STOLEN_NO;
                    jobLegal.JOB_APPOINTMENT_CHECK_DATE = SelectedTracking.LEGAL_APPOINTMENT_CHECK_DATE;
                    jobLegal.JOB_OA_ENFORCEMENT = SelectedTracking.LEGAL_OA_ENFORCEMENT;
                    jobLegal.JOB_SUBMIT_ENFORCEMENT_DATE = SelectedTracking.LEGAL_SUBMIT_ENFORCEMENT_DATE;
                    jobLegal.JOB_OA_ASSET_SEARCH = SelectedTracking.LEGAL_OA_ASSET_SEARCH;
                    jobLegal.JOB_SUBMIT_INVEST_DATE = SelectedTracking.LEGAL_SUBMIT_INVEST_DATE;
                    jobLegal.JOB_ENFORCEMENT_EFF_DATE = SelectedTracking.LEGAL_ENFORCEMENT_EFF_DATE;
                    jobLegal.JOB_CASH_RECEIVE_DATE = SelectedTracking.LEGAL_CASH_RECEIVE_DATE;
                    jobLegal.JOB_SEIZE_DATE = SelectedTracking.LEGAL_SEIZE_DATE;
                    jobLegal.JOB_REPORT_DATE = SelectedTracking.LEGAL_REPORT_DATE;
                    jobLegal.JOB_JUDGMENT_DATE = SelectedTracking.LEGAL_JUDGMENT_DATE;
                    jobLegal.JOB_WITHDRAW_DATE = SelectedTracking.LEGAL_WITHDRAW_DATE;
                    jobLegal.JOB_EXECUTION_DATE = SelectedTracking.LEGAL_EXECUTION_DATE;
                    jobLegal.JOB_EXECUTION_END_DATE = SelectedTracking.LEGAL_EXECUTION_END_DATE;
                    jobLegal.JOB_DETAILS = SelectedTracking.LEGAL_DETAILS;
                    jobLegal.JOB_UPDATE_BY = cm.UserLogin;
                    jobLegal.JOB_UPDATE_DATE = cm.SystemDate;

                }
                SelectedTracking.LEGAL_SEQ_NO = 1;

                var seq = db.T_LEGAL_TRACKING.Where(x => x.LEGAL_JOB_ID == SelectedTracking.LEGAL_JOB_ID).ToList();


                if (!seq.Count.Equals(0))
                {
                    SelectedTracking.LEGAL_SEQ_NO = (seq.Max(x => x.LEGAL_SEQ_NO)) + 1;
                }


                SelectedTracking.LEGAL_CREATE_BY = cm.UserLogin;
                SelectedTracking.LEGAL_CREATE_DATE = cm.SystemDate;
                SelectedTracking.LEGAL_UPDATE_BY = cm.UserLogin;
                SelectedTracking.LEGAL_UPDATE_DATE = cm.SystemDate;
                SelectedTracking.LEGAL_TRACKING_BY = cm.UserLogin;
                SelectedTracking.LEGAL_TRACKING_DATE = cm.SystemDate;
                db.T_LEGAL_TRACKING.Add(SelectedTracking);
                db.SaveChanges();
                message = Constants.Msg.SaveSucc;
                result = Constants.Result.True;
                return Json(new { message = message, result = result });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, result = result });
            }
        }
    }
}