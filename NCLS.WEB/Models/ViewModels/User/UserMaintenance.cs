using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Models.ViewModels.User
{
    public class UserMaintenance
    {
        public M_USER User { get; set; }
        public List<Role> UserRoleList { get; set; }
        public string mode { get; set; }
        public UserMaintenance()
        {
            UserRoleList = new List<Role>();
            User = new M_USER();
        }
    }
    public class Role
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string UserLogin { get; set; }
        public bool RoleFlag { get; set; }

    }
}