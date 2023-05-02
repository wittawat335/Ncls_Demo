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
    
    public partial class SP_SEARCH_BANKRUPTCY_BY_DOC_Result
    {
        public string BF_DOC_ID { get; set; }
        public string BF_TYPE { get; set; }
        public string ID_NUMBER { get; set; }
        public string FULLNAME { get; set; }
        public string CONTRACT_NO { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string BFD_COURTNAME { get; set; }
        public string BFD_REDCODE { get; set; }
        public string BFD_PLAINTIFF_NAME { get; set; }
        public string BFD_DEFENDANT_NAME { get; set; }
        public Nullable<System.DateTime> BFD_RECEIVING_ORDER_DATE { get; set; }
        public Nullable<System.DateTime> BFD_SUBMIT_DUE_DATE { get; set; }
        public Nullable<System.DateTime> BFD_CANCEL_RECEIVING_ORDER_DATE { get; set; }
        public Nullable<System.DateTime> BFD_COMPROMISE_BEFORE_DATE { get; set; }
        public Nullable<System.DateTime> BFD_CANCEL_COMPROMISE_BAFORE_DATE { get; set; }
        public Nullable<System.DateTime> BFD_ORDER_BANKRUPCTY_DATE { get; set; }
        public Nullable<System.DateTime> BFD_COMPROMISE_AFTER_DATE { get; set; }
        public Nullable<System.DateTime> BFD_CANCEL_COMPROMISE_AFTER_DATE { get; set; }
        public Nullable<System.DateTime> BFD_SUBMIT_AFTER_DUE_DATE { get; set; }
        public Nullable<System.DateTime> BFD_CANCEL_BANKRUPTCY_DATE { get; set; }
        public Nullable<System.DateTime> BFD_DISCHANGED_BANKRUPTCY_DATE { get; set; }
        public Nullable<System.DateTime> BFD_DISMISSAL_DATE { get; set; }
        public Nullable<System.DateTime> BFD_DISPOSE_CASE_DATE { get; set; }
        public Nullable<System.DateTime> BFD_FILING_DATE { get; set; }
        public string BFD_REMARK { get; set; }
    }
}