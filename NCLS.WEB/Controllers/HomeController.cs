using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NCLS.WEB.Entities;
using NCLS.WEB.Models;
using NCLS.WEB.Utility;

namespace NCLS.WEB.Controllers
{
    public class HomeController : BaseController
    {
        NCLSEntities db = new NCLSEntities();
        Common cm = new Common();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                base.Dispose(disposing);
        }

        public ActionResult Index()
        {



            return View();
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            HttpCookie cookie = Request.Cookies["TSWA-Last-User"];

            if (User.Identity.IsAuthenticated == false || cookie == null || StringComparer.OrdinalIgnoreCase.Equals(User.Identity.Name, cookie.Value))
            {
                string name = string.Empty;

                if (Request.IsAuthenticated)
                {
                    name = User.Identity.Name;
                }

                cookie = new HttpCookie("TSWA-Last-User", name);
                Response.Cookies.Set(cookie);

                Response.AppendHeader("Connection", "close");
                Response.StatusCode = 401; // Unauthorized;
                Response.Clear();
                //should probably do a redirect here to the unauthorized/failed login page
                //if you know how to do this, please tap it on the comments below
                Response.Write("Unauthorized. Reload the page to try again...");
                Response.End();

                return PartialView("Login");
            }

            cookie = new HttpCookie("TSWA-Last-User", string.Empty)
            {
                Expires = DateTime.Now.AddYears(-5)
            };

            Response.Cookies.Set(cookie);


            return PartialView("Login");
        }
        public ActionResult Login(string msg = "")
        {
            if (!cm.IsNullOrEmpty(msg))
                ViewBag.msg = Constants.Msg.SessionExp;
            else
                ViewBag.msg = msg;

            Session.Remove(Constants.SessionKey.LoginInfo);
            Session.Remove(Constants.SessionKey.Menu);
            FormsAuthentication.SignOut();

            return PartialView();
        }

        private string GetUsernameDomain()
        {
            try
            {
                string logonid = Request.LogonUserIdentity.Name;
                string[] arrDomain = logonid.Split('\\');
                // return "QXE9379";
                return arrDomain[1];
            }
            catch (Exception ex)
            {
                throw new Exception("GetUsernameDomain :: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CheckLoginADandDB(UserViewModel objUser)
        {
            string result = Constants.Result.False;
            string msg = "";
            UserResult user = new UserResult();
            string userAD = GetUsernameDomain();
            try
            {

                cm.Ip = Request.UserHostAddress;

                //CheckUserLdapOrOA(userAD) ปรับแก้ login AD or User password
                if (CheckUserPassOrAD(objUser))//Check User
                {


                    var currentRoleList = db.T_CURRENT_LOGIN.Where(x => x.CL_USER_LOGIN == userAD && x.CL_IP_ADDRESS != cm.Ip).ToList();

                    if (!currentRoleList.Count.Equals(0))
                    {
                        var currentRole = currentRoleList.LastOrDefault();
                        msg = Constants.Msg.LoginDuplicate;
                    }
                    else
                    {
                        msg = Constants.Msg.LoginSucc;
                    }
                    result = Constants.Result.True;
                }
                else
                {
                    msg = "Check Login: " + Request.LogonUserIdentity.Name + " - Invalid user or password";
                }



                return Json(new { Result = result, Message = msg });
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool CheckUserLdapOrOA(string objUser)
        {
            bool results = false;
            try
            {

                var colUser = db.M_USER.FirstOrDefault(x => x.USER_LOGIN == objUser && x.USER_STATUS == "A");
                if (colUser != null)  //Check User ใน System ถ้ามี ?
                {
                    results = true;
                }


                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool CheckUserPassOrAD(UserViewModel objUser)
        {
            bool results = false;
            string typeUser = "0";
            try
            {
                var colUser = db.M_USER.FirstOrDefault(x => x.USER_LOGIN == objUser.UserLogin && x.USER_STATUS == "A");
                if (colUser != null)  //Check User ใน System ถ้ามี ?
                {
                    typeUser = colUser.USER_AD_FLAG;

                    if (typeUser == "0")
                    {

                        // LDAPManager objLdap = new LDAPManager(cm.LdapUrl, cm.LdapDomain, objUser.UserLogin, objUser.Password, cm.LdapOuSite);                    
                        // objLdap.SearchUser(objUser.UserLogin);
                        //if (objLdap.IsError)//Check AD
                        //    results = true;

                        LDAPManager objLdap = new LDAPManager(cm.UserDomain, objUser.UserLogin, objUser.Password);
                        if (objLdap.IsError)//Check AD
                            results = true;
                    }
                    else
                    {
                        string password = cm.EncryptCrypto(objUser.Password);
                        var colUserOA = db.M_USER.FirstOrDefault(x => x.USER_LOGIN == objUser.UserLogin && x.USER_PASSWORD == password);
                        if (colUserOA != null)  //Check User ใน System ถ้ามี ?
                        {
                            results = true;
                        }

                    }


                }


                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult CheckLogin(UserViewModel objUser)
        {
            string result = Constants.Result.False;
            string msg = "Invalid user name or password";
            string initUrl = "~/Home/Index";
            string url = initUrl;
            string userAD = objUser.UserLogin;
            // string userAD = GetUsernameDomain();
            try
            {
                //Check User ใน System
                var colUser = db.M_USER.FirstOrDefault(x => x.USER_LOGIN == userAD);


                if (colUser != null)  //Check User ใน System ถ้ามี ?
                {
                    //Set Config
                    var sysdate = db.M_PARAMETER.FirstOrDefault(x => x.PARA_CODE == Constants.ParaCode.sysDate);
                    var pageSize = db.M_PARAMETER.FirstOrDefault(x => x.PARA_CODE == Constants.ParaCode.pageSize);
                    string userName = colUser.USER_FIRST_NAME + " " + colUser.USER_LAST_NAME;
                    cm.SysDate = sysdate.PARA_VALUE;
                    cm.PageSize = pageSize.PARA_VALUE;

                    //Check ว่าเคย Login เข้าระบบ ด้วย Role ไหนมาก่อนหรือไม่ ?
                    var currentRoleList = db.T_CURRENT_LOGIN.Where(x => x.CL_USER_LOGIN == userAD).ToList();

                    if (!currentRoleList.Count.Equals(0)) // ถ้าใช่
                    {
                        var currentRole = currentRoleList.LastOrDefault();
                        var role = db.M_ROLE.FirstOrDefault(x => x.ROLE_CODE == currentRole.CL_ROLE_CODE);

                        var CheckRoleOld = db.M_USER_ROLE.Where(x => x.USERROLE_USER_LOGIN == userAD && x.USERROLE_ROLE_CODE == currentRole.CL_ROLE_CODE).FirstOrDefault();

                        if (CheckRoleOld != null)
                        {
                            SetSessionLogin(userAD, userName, role.ROLE_CODE, role.ROLE_NAME, role.ROLE_DATA_LEVEL);
                            url = Url.Content(initUrl);
                            msg = Constants.Msg.LoginSucc;
                            result = Constants.Result.True;
                        }
                        else
                        {
                            CheckRoleLogin(userAD, userName, ref msg, ref result, ref url);
                        }

                        url = Url.Content(cm.GetMeneDefault(role.ROLE_CODE));
                    }
                    else // ถ้าไม่ใช่
                    {

                        CheckRoleLogin(userAD, userName, ref msg, ref result, ref url);
                    }


                }
                else //Check User ใน System ถ้าไม่มี ?
                {
                    msg = Request.LogonUserIdentity.Name + " Invalid user or password";
                }

                return Json(new { Result = result, url = url, Message = msg });
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private void CheckRoleLogin(string userLogin, string userName, ref string msg, ref string result, ref string url)
        {
            try
            {
                //Check Role User
                var countRole = db.M_USER_ROLE.Where(x => x.USERROLE_USER_LOGIN == userLogin).ToList();
                if (countRole.Count.Equals(1)) //Check Role = 1 ?
                {
                    foreach (var r in countRole)
                    {
                        var role = db.M_ROLE.FirstOrDefault(x => x.ROLE_CODE == r.USERROLE_ROLE_CODE);
                        SetSessionLogin(userLogin, userName, role.ROLE_CODE, role.ROLE_NAME, role.ROLE_DATA_LEVEL);
                        url = Url.Content(cm.GetMeneDefault(role.ROLE_CODE));
                    }


                    msg = Constants.Msg.LoginSucc;
                    result = Constants.Result.True;
                    //Insert Log

                }
                else if (countRole.Count > 1) //Check Role > 1 ?
                {
                    var defaultRole = cm.GetListRole(userLogin).Where(x => x.RoleFlag == true).FirstOrDefault();
                    var role = db.M_ROLE.FirstOrDefault(x => x.ROLE_CODE == defaultRole.RoleCode);
                    SetSessionLogin(userLogin, userName, role.ROLE_CODE, role.ROLE_NAME, role.ROLE_DATA_LEVEL);
                    //cm.SetLoginSession(0, objUser.UserLogin, userName, defaultRole.RoleCode, defaultRole.RoleName, 0);
                    //url = Url.Content(Constants.urlAction.HomeSwitchRole);

                    url = Url.Content(cm.GetMeneDefault(role.ROLE_CODE));


                    msg = Constants.Msg.LoginSucc;
                    result = Constants.Result.True;
                }
                else
                {
                    msg = "' " + userLogin + " '" + "had no role";
                    result = Constants.Result.False;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult _SelectRole(string role)
        {
            string result = Constants.Result.False;
            string msg = Constants.Msg.SwitchRoleFail;
            string url = Url.Content(cm.GetMeneDefault(role));
            try
            {
                if (role != null)
                {
                    var objRole = db.M_ROLE.FirstOrDefault(x => x.ROLE_CODE == role);
                    Session.Remove(Constants.SessionKey.Menu);
                    SetSessionLogin(cm.UserLogin, cm.UserName, objRole.ROLE_CODE, objRole.ROLE_NAME, objRole.ROLE_DATA_LEVEL);
                    result = Constants.Result.True;
                    msg = Constants.Msg.SwitchRoleSucc;
                }
                return Json(new { Result = result, url = url, Message = msg });
            }
            catch (Exception)
            {
                return Json(new { Result = result, url = url, Message = msg });
                throw;
            }
        }

        [HttpPost]
        public ActionResult _SwitchRole()
        {
            try
            {
                var Role = cm.GetListRole(cm.UserLogin).Where(x => x.RoleCode != cm.UserRole && x.RoleFlag == true).ToList();

                ViewBag.Role = Role.ToList();
                return PartialView();

            }
            catch (Exception)
            {
                throw;
            }
        }



        private void SetSessionLogin(string userLogin, string userName, string roleCode, string roleName, int dataLevel)
        {
            try
            {
                cm.SetLoginSession(0, userLogin, userName, roleCode, roleName, dataLevel);
                cm.SetLoginSession(cm.InsertCurrentLogin(), userLogin, userName, roleCode, roleName, dataLevel);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}