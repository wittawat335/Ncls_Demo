//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCLS.WEB.Entities
{
    using System;
    
    public partial class SP_SELECT_LEGAL_COURT_FEE_BY_JOB_Result
    {
        public Nullable<int> SEQ_NO { get; set; }
        public string PAYMENT_NO { get; set; }
        public string COURT_NAME { get; set; }
        public Nullable<System.DateTime> FILING_DATE { get; set; }
        public decimal AMOUNT_CLAIMED { get; set; }
        public decimal COURT_FEE { get; set; }
        public string REMARK { get; set; }
        public string LEGAL_OA { get; set; }
        public decimal RECEIVE_BACK { get; set; }
    }
}
