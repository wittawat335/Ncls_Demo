using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCLS.WEB.Models.ViewModels.AssignRepoOA
{
    public class AssignRepoOAViewModel
    {
        public string JobId { get; set; }
        public string ContractNo { get; set; }
        public string CitizenId { get; set; }
        public string BorrowerName { get; set; }
        public string PreviousRepoOa { get; set; }
        public Decimal? OutstandingBalance { get; set; }
        public DateTime? AssignDate { get; set; }
        public string AreaCode { get; set; }
        public bool Flag { get; set; }
    }
}