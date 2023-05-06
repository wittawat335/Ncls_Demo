using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Models.ViewModels.TodoList
{
    public class TodoListSearch
    {
        public int popupCancelLegal { get; set; }
        public string DefaultCase { get; set; }
        public string CaseCode { get; set; }
        public bool DocFlag { get; set; }
        public string OACode { get; set; }
        public List<M_OA> OAList { get; set; }
        public List<M_USER> AdminList { get; set; }
        public List<M_LEGAL_CASE> LegalCaseList { get; set; }
        public List<TrafficType> TrafficList { get; set; }
        public List<SP_SEARCH_STATUS_BY_CASE_Result> LegalStatusList { get; set; }
        public TodoListSearch()
        {
            OAList = new List<M_OA>();
            AdminList = new List<M_USER>();
            LegalCaseList = new List<M_LEGAL_CASE>();
            LegalStatusList = new List<SP_SEARCH_STATUS_BY_CASE_Result>();
            TrafficList = new List<TrafficType>();
        }
    }
    public class TrafficType
    {
        public string CODE { get; set; }
        public string TEXT { get; set; }
    }
}