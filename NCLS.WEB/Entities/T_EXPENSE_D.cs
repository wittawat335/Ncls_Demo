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
    using System.Collections.Generic;
    
    public partial class T_EXPENSE_D
    {
        public int EXPENSED_ID { get; set; }
        public string EXPENSED_HID { get; set; }
        public string EXPENSED_JOB_ID { get; set; }
        public string EXPENSED_CONTRACT_NO { get; set; }
        public string EXPENSED_COURT_CODE { get; set; }
        public string EXPENSED_TRANS_CODE { get; set; }
        public string EXPENSED_REMARK { get; set; }
        public Nullable<decimal> EXPENSED_AMOUNT_CLAIMED { get; set; }
        public Nullable<decimal> EXPENSED_AMT { get; set; }
        public Nullable<decimal> EXPENSED_VAT { get; set; }
        public Nullable<decimal> EXPENSED_TAX { get; set; }
        public Nullable<decimal> EXPENSED_TOTAL { get; set; }
        public Nullable<System.DateTime> EXPENSED_FILING_DATE { get; set; }
        public string EXPENSED_CREATE_BY { get; set; }
        public Nullable<System.DateTime> EXPENSED_CREATE_DATE { get; set; }
        public string EXPENSED_UPDATE_BY { get; set; }
        public Nullable<System.DateTime> EXPENSED_UPDATE_DATE { get; set; }
        public string EXPENSED_STATUS { get; set; }
        public string EXPENSED_PAYMENT_REF { get; set; }
        public Nullable<int> EXPENSED_ID_REF { get; set; }
        public string EXPENSED_RECEIVE_TYPE { get; set; }
        public string EXPENSED_RECEIVE_BANK_CODE { get; set; }
        public string EXPENSED_RECEIVE_CHEQUE_NO { get; set; }
        public Nullable<System.DateTime> EXPENSED_RECEIVE_CHEQUE_DATE { get; set; }
        public string EXPENSED_RECVIVE_FLAG { get; set; }
    }
}
