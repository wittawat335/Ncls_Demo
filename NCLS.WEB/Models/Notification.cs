using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCLS.WEB.Models
{
    public class Notification
    {
        public int CountItem { get; set; }
        public List<ItemNotification> NotificationList { get; set; }

        public Notification()
        {
            NotificationList = new List<ItemNotification>();
        }
    }

    public class ItemNotification
    {
        public int Count { get; set; }
        public string Header { get; set; }
        public string Detail { get; set; }
        public string NoticeDate { get; set; }
        public string Icon { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public bool typeModalPupup { get; set; }

    }
}