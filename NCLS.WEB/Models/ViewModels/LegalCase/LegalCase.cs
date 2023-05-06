using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Models.ViewModels.LegalCase
{
    public class LegalCase
    {


        public string DefaultRefNo { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCaseCode { get; set; }
        public string ReadOnly { get; set; }
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public DateTime? AssignOADate { get; set; }
        public decimal? ShortFall { get; set; }
        public DateTime? RequestDate { get; set; }
        public string AMLOrderNo { get; set; }
        public DateTime? AMLOrderDate { get; set; }
        public string Remark { get; set; }
        public DateTime? CarReceiveDate { get; set; }
        public string CarReceivePlace { get; set; }
        public string Requestor { get; set; }
        public string TheCompanyPlan { get; set; }
        public string OrderedRehabilitation { get; set; }
        public string OrderedReh { get; set; }
        public DateTime? ReceiveOrderDate { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? AppointedDate { get; set; }
        public DateTime? LastDueDate { get; set; }
        public string PlaintiffName { get; set; }
        public string Insurer { get; set; }
        public decimal AssuredAmount { get; set; }
        public decimal TotalLossAmount { get; set; }
        public string LegalCaseName { get; set; }
        public string PayerName { get; set; }
        public string Address { get; set; }
        public T_LEGAL_TRACKING SelectedTracking { get; set; }
        public SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB_Result CarReceives;
        public SP_SELECT_LEGAL_REPO_BY_JOB_Result Repo;
        public List<SP_SELECT_LEGAL_TRACKING_BY_CASE_Result> ListOfTracking { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public List<SP_SEARCH_CHEQUE_CONTRACT_Result> ListOfContract { get; set; }
        public List<SP_SELECT_LEGAL_CASE_BY_JOB_Result> ListOfCase { get; set; }

        public LegalCase()
        {

            SelectedTracking = new T_LEGAL_TRACKING();
            CarReceives = new SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB_Result();
            Repo = new SP_SELECT_LEGAL_REPO_BY_JOB_Result();
            ListOfCase = new List<SP_SELECT_LEGAL_CASE_BY_JOB_Result>();
            ListOfTracking = new List<SP_SELECT_LEGAL_TRACKING_BY_CASE_Result>();
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
            ListOfContract = new List<SP_SEARCH_CHEQUE_CONTRACT_Result>();

            RecallCase = new RecallInfo();
            LossCase = new LossInfo();
            AMLOCase = new AMLO();
            ONCBCase = new ONCB();
            EmbezzleCase = new Embezzle();
            EmbezzleCase2 = new Embezzle2();
            EmbezzleCase3 = new Embezzle3();
            ExhibitCase = new Exhibit();
            BankruptcyCase = new Bankruptcy();
            ClaimCase = new Claim();
            ClaimCase2 = new Claim2();
            OCPBCase = new OCPB();
            OtherCase = new Other();
            ChequeCase = new Cheque();
            RehabilitationCase = new Rehabilitation();
        }

        public RecallInfo RecallCase { get; set; }
        public LossInfo LossCase { get; set; }
        public AMLO AMLOCase { get; set; }
        public ONCB ONCBCase { get; set; }
        public Embezzle EmbezzleCase { get; set; }
        public Embezzle2 EmbezzleCase2 { get; set; }
        public Embezzle3 EmbezzleCase3 { get; set; }
        public Exhibit ExhibitCase { get; set; }
        public Bankruptcy BankruptcyCase { get; set; }
        public Claim ClaimCase { get; set; }
        public Claim2 ClaimCase2 { get; set; }
        public OCPB OCPBCase { get; set; }
        public Other OtherCase { get; set; }
        public Cheque ChequeCase { get; set; }
        public Rehabilitation RehabilitationCase { get; set; }



    }

    public class LegalTracking
    {
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string ReadOnly { get; set; }
        public List<SP_SELECT_LEGAL_TRACKING_BY_CASE_Result> ListOfTracking { get; set; }
        public T_LEGAL_TRACKING SelectedTracking { get; set; }
    }

    //--- ฟ้องเรียกทรัพย์
    public class RecallInfo
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public DateTime? AssignOADate { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public List<SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB_Result> ListOfJudgmentDebtor { get; set; }
        public SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB_Result CarReceives;
        public RecallInfo()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
            ListOfJudgmentDebtor = new List<SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB_Result>();
            CarReceives = new SP_SELECT_LEGAL_CAR_RECEIVE_BY_JOB_Result();
        }
    }

    //--- ฟ้องส่วนขาดทุน
    public class LossInfo
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public decimal? ShortFall { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public List<SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB_Result> ListOfJudgmentDebtor { get; set; }
        public SP_SELECT_LEGAL_REPO_BY_JOB_Result Repo = new SP_SELECT_LEGAL_REPO_BY_JOB_Result();
        public LossInfo()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
            ListOfJudgmentDebtor = new List<SP_SELECT_LEGAL_DEBTOR_EXPENSE_BY_JOB_Result>();
            Repo = new SP_SELECT_LEGAL_REPO_BY_JOB_Result();
        }
    }

    //--- AMLO ปปง
    public class AMLO
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }

        public string Admin { get; set; }
        public DateTime? RequestDate { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public string Remark { get; set; }
        public string AMLOrderNo { get; set; }
        public DateTime? AMLOrderDate { get; set; }
        public decimal ShortFall { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public AMLO()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- ONCB ปปส
    public class ONCB
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string AMLOrderNo { get; set; }
        public DateTime? AMLOrderDate { get; set; }
        public string Remark { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public ONCB()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Embezzle ยักยอกทรัพย์
    public class Embezzle
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Remark { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Embezzle()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Embezzle คดีฉ้อโกง
    public class Embezzle2
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Remark { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Embezzle2()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Embezzle คดีโกงเจ้าหนี้
    public class Embezzle3
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Remark { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Embezzle3()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Exhibit ร้องคืนของกลาง
    public class Exhibit
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CarReceiveDate { get; set; }
        public string Remark { get; set; }
        public string CarReceivePlace { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Exhibit()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Rehabilitation ฟื้นฟูกิจการ
    public class Rehabilitation
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Requestor { get; set; }
        public string Remark { get; set; }
        public string TheCompanyPlan { get; set; }
        public string OrderedRehabilitation { get; set; }
        public string OrderedReh { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Rehabilitation()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Bankruptcy ล้มละลาย
    public class Bankruptcy
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Remark { get; set; }
        public DateTime? ReceiveOrderDate { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? AppointedDate { get; set; }
        public DateTime? LastDueDate { get; set; }
        public string PlaintiffName { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Bankruptcy()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }

    }

    //--- Claim เคลมประกัน คดีรถหาย
    public class Claim
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public string Remark { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Insurer { get; set; }
        public decimal AssuredAmount { get; set; }
        public decimal TotalLossAmount { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Claim()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Claim เคลมประกัน เสียหายโดยสิ้นเชิง
    public class Claim2
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public string Remark { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Insurer { get; set; }
        public decimal AssuredAmount { get; set; }
        public decimal TotalLossAmount { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Claim2()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }
    //--- OCPB สคบ
    public class OCPB
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Remark { get; set; }
        public string Requestor { get; set; }
        public DateTime? AppointedDate { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public OCPB()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Other คดีอื่นๆ
    public class Other
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public string LegalCaseName { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AssignOADate { get; set; }
        public string Remark { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Other()
        {
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }

    //--- Cheque เช็ค
    public class Cheque
    {
        public bool HasData { get; set; }
        public string CssActive { get; set; }
        public string ReadOnly { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public string LegalCase { get; set; }
        public string Admin { get; set; }
        public string LegalOA { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? AssignOADate { get; set; }
        public string Remark { get; set; }
        public string PayerName { get; set; }
        public string Address { get; set; }
        public decimal ShortFall { get; set; }
        public decimal totalCourtFee { get; set; }
        public decimal totalReceiveBack { get; set; }
        public decimal totalExpenseVat { get; set; }
        public decimal totalExpenseTax { get; set; }
        public decimal totalExpensePayment { get; set; }
        public decimal totalExpenseNet { get; set; }
        public List<SP_SEARCH_CHEQUE_CONTRACT_Result> ListOfContract { get; set; }
        public List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result> ListOfAttachment { get; set; }
        public List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result> ListOfCourtFee { get; set; }
        public List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result> ListOfExpense { get; set; }
        public Cheque()
        {
            ListOfContract = new List<SP_SEARCH_CHEQUE_CONTRACT_Result>();
            ListOfAttachment = new List<SP_SELECT_LEGAL_ATTACH_BY_JOB_Result>();
            ListOfCourtFee = new List<SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result>();
            ListOfExpense = new List<SP_SELECT_LEGAL_EXPENSE_BY_JOB_Result>();
        }
    }
}