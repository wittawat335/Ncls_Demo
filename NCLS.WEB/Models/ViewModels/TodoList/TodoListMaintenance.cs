using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Models.ViewModels.TodoList
{
    public class TodoListMaintenance
    {
        public string RefNo { get; set; }
        public string CaseCode { get; set; }
        public string ContractNo { get; set; }
        public bool DocFlag { get; set; }
        public string OACode { get; set; }
        public string OADummy { get; set; }
        public string mode { get; set; }
        public List<Document> DocumentList { get; set; }
        public List<M_MASTER> ReasonList { get; set; }
        public List<M_OA> OAList { get; set; }
        public TodoListMaintenance()
        {
            DocumentList = new List<Document>();
            ReasonList = new List<M_MASTER>();
            OAList = new List<M_OA>();
        }
    }

    public class Document
    {
        public string DocJobId { get; set; }
        public string DocContractNo { get; set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public bool DocSuccFlag { get; set; }
        public bool DocFailFlag { get; set; }
        public string DocReasonCode { get; set; }
        public string DocRemark { get; set; }
        public bool DocReq { get; set; }
    }
    public class UseCheckCancel
    {
        public bool CheckCancel { get; set; }
        public string JOB_ID { get; set; }
    }
}