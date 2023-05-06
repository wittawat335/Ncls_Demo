using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCLS.WEB.Models.ViewModels.SpecialCase
{
    public class SpecialCase
    {
        public string LegalCase { get; set; }
        public string RefNo { get; set; }
        public string ContractNo { get; set; }
        public ChequeCase Cheque { get; set; }
        public OtherCase Other { get; set; }
        public SpecialCase()
        {
            Cheque = new ChequeCase();
            Other = new OtherCase();
        }
    }

    public class ChequeCase
    {
        public bool HasData { get; set; }
        public string Admin { get; set; }
        public string PayerName { get; set; }
        public string CitizenId { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public DateTime? RequestDate { get; set; }
        public List<AddCheque> ListOfCheque { get; set; }
        public List<Attachment> ListOfAttach { get; set; }
        public ChequeCase()
        {
            ListOfCheque = new List<AddCheque>();
            ListOfAttach = new List<Attachment>();
        }
    }

    public class OtherCase
    {
        public bool HasData { get; set; }
        public string Admin { get; set; }
        public DateTime? RequestDate { get; set; }
        public string LegalOA { get; set; }
        public DateTime? AssignOADate { get; set; }
        public string AMLOrderNo { get; set; }
        public DateTime? AMLOrderDate { get; set; }

        public decimal? ShortFall { get; set; }
        public string CarReceivePlace { get; set; }
        public DateTime? CarReceiveDate { get; set; }
        public string Requestor { get; set; }
        public string TheCompanyPlan { get; set; }
        public string OrderedReh { get; set; }
        public DateTime? ReceiveOrderDate { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? AppointedDate { get; set; }
        public DateTime? LastDueDate { get; set; }
        public string PlaintiffName { get; set; }
        public string Insurer { get; set; }
        public decimal? AssuredAmount { get; set; }
        public decimal? TotalLossAmount { get; set; }
        public string LegalCase { get; set; }
        public string Remark { get; set; }
        public List<Attachment> ListOfAttach { get; set; }
        public OtherCase()
        {
            ListOfAttach = new List<Attachment>();
        }
    }

    public class AddCheque
    {
        public string ChequeNo { get; set; }
        public decimal ChequeAmount { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContractNo { get; set; }
        public string Remark { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string BorrowerName { get; set; }
    }

    public class Attachment
    {
        public string FileName { get; set; }
        public string Description { get; set; }
    }

    public class CheckListReject
    {
        public bool CheckBox { get; set; }
        public string RefNo { get; set; }
    }

    public class ReturnView
    {
        public string result { get; set; }
        public string Msg { get; set; }
        public PartialViewResult View { get; set; }
    }
}