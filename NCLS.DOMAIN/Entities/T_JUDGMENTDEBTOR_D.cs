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
    using System.Collections.Generic;
    
    public partial class T_JUDGMENTDEBTOR_D
    {
        public int JDD_ID { get; set; }
        public string JDD_HID { get; set; }
        public int JDD_SEQ { get; set; }
        public string JDD_TRANS_CODE { get; set; }
        public Nullable<decimal> JDD_AMOUNT { get; set; }
        public Nullable<decimal> JDD_PAYMENT_AMOUNT { get; set; }
        public string JDD_CREDITBUREAU_FLAG { get; set; }
        public string JDD_SUM_FLAG { get; set; }
        public string JDD_GENERATE_FLAG { get; set; }
        public string JDD_INTEREST_FLAG { get; set; }
        public string JDD_INTEREST_TYPE { get; set; }
        public Nullable<System.DateTime> JDD_INTEREST_START_DATE { get; set; }
        public Nullable<System.DateTime> JDD_INTEREST_END_DATE { get; set; }
        public string JDD_INTEREST_END_DATE_FLAG { get; set; }
        public Nullable<int> JDD_INTEREST_MONTHS { get; set; }
        public Nullable<int> JDD_INTEREST_DAYS { get; set; }
        public Nullable<decimal> JDD_INTEREST_RATE { get; set; }
        public string JDD_MONTHS_FLAG { get; set; }
        public Nullable<int> JDD_MONTHS { get; set; }
        public string JDD_REMARK { get; set; }
        public string JDD_CREATE_BY { get; set; }
        public Nullable<System.DateTime> JDD_CREATE_DATE { get; set; }
        public string JDD_UPDATE_BY { get; set; }
        public Nullable<System.DateTime> JDD_UPDATE_DATE { get; set; }
        public string JDD_STATUS { get; set; }
    }
}