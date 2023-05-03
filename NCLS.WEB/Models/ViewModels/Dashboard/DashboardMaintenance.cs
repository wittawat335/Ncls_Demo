using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCLS.WEB.Models.ViewModels.Dashboard
{
    public class DashboardMaintenance
    {
        //public M_LEGAL_CASE LegalCase { get; set; }
        //public List<M_LEGAL_CASE> LegalCaseList { get; set; }
        //public List<LegalStatus> LegalStatusList { get; set; }
        //public string mode { get; set; }
        //public string caseCode { get; set; }
        public DashboardMaintenance()
        {
            //LegalCase = new M_LEGAL_CASE();
            //LegalCaseList = new List<M_LEGAL_CASE>();
            //LegalStatusList = new List<LegalStatus>();

        }

    }

    public class Charts
    {
        public string id { get; set; }
        public string text { get; set; }
        public int value { get; set; }
        public string color { get; set; }
    }
}