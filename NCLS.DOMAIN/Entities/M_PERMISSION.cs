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
    
    public partial class M_PERMISSION
    {
        public string PERM_ROLE_CODE { get; set; }
        public string PERM_PROG_CODE { get; set; }
        public string PERM_ACT_CODE { get; set; }
        public string PERM_USE_FLAG { get; set; }
        public string PERM_CREATE_BY { get; set; }
        public Nullable<System.DateTime> PERM_CREATE_DATE { get; set; }
        public string PERM_UPDATE_BY { get; set; }
        public Nullable<System.DateTime> PERM_UPDATE_DATE { get; set; }
        public string PERM_STATUS { get; set; }
    }
}