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
    
    public partial class M_TRANSACTION
    {
        public string TRANS_CODE { get; set; }
        public string TRANS_NAME_TH { get; set; }
        public string TRANS_NAME_EN { get; set; }
        public string TRANS_GROUP_CODE { get; set; }
        public Nullable<decimal> TRANS_AMT { get; set; }
        public string TRANS_VAT_FLAG { get; set; }
        public string TRANS_TAX_FLAG { get; set; }
        public string TRANS_DUP_FLAG { get; set; }
        public string TRANS_EST_FLAG { get; set; }
        public string TRANS_CREATE_BY { get; set; }
        public Nullable<System.DateTime> TRANS_CREATE_DATE { get; set; }
        public string TRANS_UPDATE_BY { get; set; }
        public Nullable<System.DateTime> TRANS_UPDATE_DATE { get; set; }
        public string TRANS_STATUS { get; set; }
    }
}
