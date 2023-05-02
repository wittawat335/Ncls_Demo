using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCLS.WEB.Models
{
    public class LoginInfo
    {
        public long clID { get; set; }
        public string UserLogin { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }
        public string DataLevel { get; set; }
    }
}