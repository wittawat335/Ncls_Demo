//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCLS.DOMAIN.Entities
{
    using System;
    
    public partial class SP_SEARCH_WRITE_OFF_Result
    {
        public string CONTRACT_NO { get; set; }
        public string ID_NUMBER { get; set; }
        public string CUST_NAME_TH { get; set; }
        public Nullable<decimal> OUTSTANDING_BALANCE { get; set; }
        public Nullable<System.DateTime> CONTRACT_CREATION_DATE { get; set; }
        public string JOB_R3_STATUS { get; set; }
        public string JOB_REPO_STATUS { get; set; }
        public int R3DAYS { get; set; }
        public string AUCTFLAG { get; set; }
        public decimal OVERDUEDAY { get; set; }
        public string REDCODE { get; set; }
        public string BLACKCODE { get; set; }
        public string JOB_CASE { get; set; }
        public string JOB_LEGAL_STATUS { get; set; }
        public string REPO_STATUS { get; set; }
        public string LEGAL_STATUS_NAME { get; set; }
        public string CASE_NAME_TH { get; set; }
        public string COURT_CODE { get; set; }
        public string COURT_NAME_TH { get; set; }
        public Nullable<System.DateTime> JOB_JUDGMENT_DATE { get; set; }
        public Nullable<System.DateTime> JOB_FILING_DATE { get; set; }
        public Nullable<decimal> JD_TOTAL { get; set; }
    }
}
