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
    
    public partial class SP_SELECT_LEGAL_REPO_BY_JOB_Result
    {
        public Nullable<System.DateTime> REPO_DATE { get; set; }
        public Nullable<System.DateTime> AUCTION_DATE { get; set; }
        public Nullable<decimal> AUCTION_PRICE { get; set; }
        public decimal AUCTION_FEE { get; set; }
        public decimal REPO_FEE { get; set; }
        public string AUCTION_HOUSE { get; set; }
        public string REPO_OA { get; set; }
        public decimal PRINCIPAL_REMAINING { get; set; }
        public decimal TOTAL_REMAINING { get; set; }
        public string COMMENT { get; set; }
        public Nullable<System.DateTime> R3_DATE { get; set; }
        public decimal PENALTY_INTEREST { get; set; }
        public Nullable<System.DateTime> REDEMPTION_DATE { get; set; }
        public System.DateTime AFT_DATE { get; set; }
        public decimal REDEMPTION_AMOUNT { get; set; }
        public decimal AFT_AMOUNT { get; set; }
    }
}
