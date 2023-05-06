using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCLS.WEB.Models.ViewModels.BankrupcyFraudC
{
    public class WriteOffUploadViewModel
    {
        public string Validate { get; set; }
        public string UploadType { get; set; }
        public string ContractNo { get; set; }
        public string CitizenId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Courtname { get; set; }
        public string Redcode { get; set; }
        public string ComplainantName { get; set; }
        public string DefendantName { get; set; }
        public DateTime? ReceivingOrderDate { get; set; }
        public DateTime? SubmitDueDate { get; set; }
        public DateTime? CancelReceivingOrderDate { get; set; }
        public DateTime? CompromiseBeforeDate { get; set; }
        public DateTime? CancelCompromiseBeforeDate { get; set; }
        public DateTime? OrderBankrupcyDate { get; set; }
        public DateTime? CompromiseAfterDate { get; set; }
        public DateTime? CancelCompromiseAfterDate { get; set; }
        public DateTime? SubmitAfterDueDate { get; set; }
        public DateTime? CancelBankrupcyDate { get; set; }
        public DateTime? DischangedBankrupcyDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public DateTime? DisposeCaseDate { get; set; }
        public DateTime? FilingDate { get; set; }
        public string MsgError { get; set; }
        public int Flag { get; set; }
    }
}