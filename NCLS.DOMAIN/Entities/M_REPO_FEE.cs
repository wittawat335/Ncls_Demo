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
    
    public partial class M_REPO_FEE
    {
        public int REPO_ID { get; set; }
        public Nullable<int> REPO_OVD_DAY_FROM { get; set; }
        public Nullable<int> REPO_OVD_DAY_TO { get; set; }
        public string REPO_BRAND { get; set; }
        public string REPO_MODEL { get; set; }
        public string REPO_BODY { get; set; }
        public Nullable<decimal> REPO_AMT_FROM { get; set; }
        public Nullable<decimal> REPO_AMT_TO { get; set; }
        public string REPO_FIELD { get; set; }
        public Nullable<decimal> REPO_AMT { get; set; }
    }
}
