using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using ITOS.Utility.TripleDES;
using NCLS.DOMAIN.Entities;
using NCLS.WEB.Models;
using NCLS.WEB.Models.ViewModels.User;
using Newtonsoft.Json;

namespace NCLS.WEB.Utility
{
    public class Common
    {
        static AppSettingsReader _configReader = new AppSettingsReader();
        static cTripleDES objTrippleDes = new cTripleDES();
        static Common crypto = new Common();
        NCLSEntities db = new NCLSEntities();

        public string Version { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }
        public string ConnectionString { get { return crypto.DecryptCrypto((string)_configReader.GetValue("ConnectionString", typeof(string))); } }
        public string Globalization { get { return crypto.DecryptCrypto((string)_configReader.GetValue("Globalization", typeof(string))); } }
        public string UICulture { get { return crypto.DecryptCrypto((string)_configReader.GetValue("UICulture", typeof(string))); } }
        public string DBCulture { get { return crypto.DecryptCrypto((string)_configReader.GetValue("DBCulture", typeof(string))); } }
        public string LdapUrl { get { return crypto.DecryptCrypto((string)_configReader.GetValue("LDP.URL", typeof(string))); } }
        public string LdapDomain { get { return crypto.DecryptCrypto((string)_configReader.GetValue("LDP.Domain", typeof(string))); } }
        public string LdapUserName { get { return crypto.DecryptCrypto((string)_configReader.GetValue("LDP.UserName", typeof(string))); } }
        public string LdapPassword { get { return crypto.DecryptCrypto((string)_configReader.GetValue("LDP.Password", typeof(string))); } }
        public string LdapOuSite { get { return crypto.DecryptCrypto((string)_configReader.GetValue("LDP.OuSite", typeof(string))); } }
        public string UserDomain { get { return crypto.DecryptCrypto((string)_configReader.GetValue("USER.Domain", typeof(string))); } }
        public string LinkedServer { get { return crypto.DecryptCrypto((string)_configReader.GetValue("LinkedServer", typeof(string))); } }
        public string NLSDbName { get { return crypto.DecryptCrypto((string)_configReader.GetValue("NLSDbName", typeof(string))); } }
        public string CSDbName { get { return crypto.DecryptCrypto((string)_configReader.GetValue("CSDbName", typeof(string))); } }
        public string PathLog { get { return crypto.DecryptCrypto((string)_configReader.GetValue("PathLog", typeof(string))); } }
        public string PageSize
        {
            get
            {
                if (HttpContext.Current.Session[Constants.SessionKey.PageSize] != null)
                    return (string)HttpContext.Current.Session[Constants.SessionKey.PageSize];
                else
                {
                    string pageSzie = GetParameterByCode(Constants.ParaCode.pageSize);

                    if (!IsNullOrEmpty(pageSzie))
                    {
                        PageSize = pageSzie;
                        return pageSzie;
                    }
                    else
                        return "10";
                }
            }
            set
            {
                HttpContext.Current.Session[Constants.SessionKey.PageSize] = value;
            }
        }
        public string ErrorPage
        {
            get
            {

                if (HttpContext.Current.Session["ErrorPage"] != null)
                    return (string)HttpContext.Current.Session["ErrorPage"];
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["ErrorPage"] = value;
            }
        }
        public string ErrorMsg
        {
            get
            {
                if (HttpContext.Current.Session["ErrorMsg"] != null)
                    return (string)HttpContext.Current.Session["ErrorMsg"];
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["ErrorMsg"] = value;
            }
        }
        /// <summary>
        /// Return Date (dd/MM/yyyy)
        /// </summary>
        public string SysDate
        {
            get
            {
                if (HttpContext.Current.Session[Constants.SessionKey.SysDate] != null)
                    return (string)HttpContext.Current.Session[Constants.SessionKey.SysDate];
                else
                {
                    string sysDate = GetParameterByCode(Constants.ParaCode.sysDate);

                    if (!IsNullOrEmpty(sysDate))
                    {
                        SysDate = sysDate;
                        return sysDate;
                    }
                    else
                        return DateTime.Now.ToString("yyyy-mm-dd");
                }

            }
            set
            {
                HttpContext.Current.Session[Constants.SessionKey.SysDate] = value;
            }
        }

        /// <summary>
        /// Return Datetime Now
        /// </summary>
        public DateTime SystemDate
        {
            get
            {
                //ITOS.Utility.Formatter.DateTimeFormatter dtf = new ITOS.Utility.Formatter.DateTimeFormatter(DBCulture, DBCulture);
                // string sysdatetime = DateTime.Now.ToString(" HH:mm:ss");

                //if (SysDate != null)
                //{
                //    sysdatetime = SysDate + "" + sysdatetime;
                //    return dtf.Parse(sysdatetime);
                //}
                //else
                //{
                //    return DateTime.Now;
                //}
                return DateTime.Now;
            }
        }
        public DateTime LastLoginDateTime
        {
            get
            {
                if (HttpContext.Current.Session[Constants.SessionKey.LastLoginDateTime] != null)
                {

                    return (DateTime)(HttpContext.Current.Session[Constants.SessionKey.LastLoginDateTime]);
                }
                else
                {
                    return SystemDate;
                }
            }
            set
            {
                HttpContext.Current.Session[Constants.SessionKey.LastLoginDateTime] = value;
            }
        }
        public long LoginCurrentID
        {
            get
            {
                var loginInfo = new LoginInfo();
                long currentID = 0;
                if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] != null)
                {
                    loginInfo = (LoginInfo)HttpContext.Current.Session[Constants.SessionKey.LoginInfo];
                    currentID = loginInfo.clID;
                }
                return currentID;
            }
        }
        public string UserLogin
        {
            get
            {
                var loginInfo = new LoginInfo();
                var userLogin = "";
                if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] != null)
                {
                    loginInfo = (LoginInfo)HttpContext.Current.Session[Constants.SessionKey.LoginInfo];
                    userLogin = loginInfo.UserLogin;
                }
                return userLogin;
            }
        }
        public string UserName
        {
            get
            {
                var loginInfo = new LoginInfo();
                var userName = "";
                if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] != null)
                {
                    loginInfo = (LoginInfo)HttpContext.Current.Session[Constants.SessionKey.LoginInfo];
                    userName = loginInfo.FullName;
                }
                return userName;
            }
        }

        public string UserRole
        {
            get
            {
                var loginInfo = new LoginInfo();
                var userRole = "";
                if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] != null)
                {
                    loginInfo = (LoginInfo)HttpContext.Current.Session[Constants.SessionKey.LoginInfo];
                    userRole = loginInfo.Role;
                }
                return userRole;
            }
        }
        public string UserRoleName
        {
            get
            {
                var loginInfo = new LoginInfo();
                var userRole = "";
                if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] != null)
                {
                    loginInfo = (LoginInfo)HttpContext.Current.Session[Constants.SessionKey.LoginInfo];
                    userRole = loginInfo.RoleName;
                }
                return userRole;
            }
        }
        public string UserDataLevel
        {
            get
            {
                var loginInfo = new LoginInfo();
                var dataLevel = "";
                if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] != null)
                {
                    loginInfo = (LoginInfo)HttpContext.Current.Session[Constants.SessionKey.LoginInfo];
                    dataLevel = loginInfo.DataLevel;
                }
                return dataLevel;
            }
        }
        public string Ip
        {
            get
            {
                if (HttpContext.Current.Session[Constants.SessionKey.Ip] != null)
                    return (string)HttpContext.Current.Session[Constants.SessionKey.Ip];
                else
                {
                    string ip = GetipAddress();

                    if (!IsNullOrEmpty(ip))
                    {
                        Ip = ip;
                        return ip;
                    }
                    else
                        return "127.0.0.1";
                }
            }
            set
            {
                HttpContext.Current.Session[Constants.SessionKey.Ip] = value;
            }
        }
        public void SetLoginSession(long id, string userLogin, string userName, string role, string roleName, int dataLevel)
        {
            var loginInfo = new LoginInfo
            {
                clID = id,
                UserLogin = userLogin,
                FullName = userName,
                Role = role,
                RoleName = roleName,
                DataLevel = dataLevel.ToString()
            };
            HttpContext.Current.Session[Constants.SessionKey.LoginInfo] = loginInfo;
        }
        public void ClearLoginSession()
        {
            HttpContext.Current.Session[Constants.SessionKey.LoginInfo] = null;
        }
        public object htmlAttr(string mode, bool req, bool key = false)
        {

            if (req)
            {
                if (mode.Equals(Constants.Mode.New))
                {
                    var obj = new { @class = "form-control", @required = "required" };
                    return obj;
                }
                else if (mode.Equals(Constants.Mode.Edit))
                {
                    if (key)
                    {
                        var obj = new { @class = "form-control", @required = "required", @disabled = false };
                        return obj;
                    }
                    else
                    {
                        var obj = new { @class = "form-control", @required = "required" };
                        return obj;
                    }

                }
                else
                {
                    var obj = new { @class = "form-control", @required = "required", @disabled = false };
                    return obj;
                }
            }
            else
            {
                if (mode.Equals(Constants.Mode.New))
                {
                    var obj = new { @class = "form-control" };
                    return obj;
                }
                else if (mode.Equals(Constants.Mode.Edit))
                {
                    if (key)
                    {
                        var obj = new { @class = "form-control", @disabled = false };
                        return obj;
                    }
                    else
                    {
                        var obj = new { @class = "form-control" };
                        return obj;
                    }
                }
                else
                {
                    var obj = new { @class = "form-control", @disabled = false };
                    return obj;
                }
            }


        }
        public object htmlAttr(string mode, bool req, int maxLength, bool key = false)
        {


            if (req)
            {
                if (mode.Equals(Constants.Mode.New))
                {
                    var obj = new { @class = "form-control", @required = "required", @MaxLength = maxLength };
                    return obj;
                }
                else if (mode.Equals(Constants.Mode.Edit))
                {
                    if (key)
                    {
                        var obj = new { @class = "form-control", @required = "required", @disabled = false, @MaxLength = maxLength };
                        return obj;
                    }
                    else
                    {
                        var obj = new { @class = "form-control", @required = "required", @MaxLength = maxLength };
                        return obj;
                    }

                }
                else
                {
                    var obj = new { @class = "form-control", @required = "required", @disabled = false, @MaxLength = maxLength };
                    return obj;
                }
            }
            else
            {
                if (mode.Equals(Constants.Mode.New))
                {
                    var obj = new { @class = "form-control", @MaxLength = maxLength };
                    return obj;
                }
                else if (mode.Equals(Constants.Mode.Edit))
                {
                    if (key)
                    {
                        var obj = new { @class = "form-control", @disabled = false, @MaxLength = maxLength };
                        return obj;
                    }
                    else
                    {
                        var obj = new { @class = "form-control", @MaxLength = maxLength };
                        return obj;
                    }
                }
                else
                {
                    var obj = new { @class = "form-control", @disabled = false, @MaxLength = maxLength };
                    return obj;
                }
            }

        }
        public void SetDataLevel(ref string adminCode, ref string roleCode)
        {
            try
            {
                if (UserDataLevel == "1")
                {
                    adminCode = UserLogin;
                    roleCode = UserRole;
                }
                else if (UserDataLevel == "2")
                {
                    roleCode = UserRole;
                }
                else
                {
                    roleCode = "";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string CheckSession()
        {
            string msg = "";
            try
            {
                //ตรวจสอบ Session


                if (UnStringNull(UserLogin) == "")
                // if (HttpContext.Current.Session[Constants.SessionKey.LoginInfo] == null)
                {
                    msg = Constants.Msg.SessionExp;

                }
                else
                {
                    NCLSEntities db = new NCLSEntities();

                    var x = db.T_CURRENT_LOGIN.Find(LoginCurrentID);

                    if (x != null)
                    {
                        if ((SystemDate - LastLoginDateTime).Minutes <= UnInt32Null(GetParameterByCode(Constants.ParaCode.timeOut)))
                        {
                            SetLoginSession(LoginCurrentID, UserLogin, UserName, UserRole, UserRoleName, UnInt32Null(UserDataLevel));
                            UpdateCurrentLogin();
                        }
                        else
                            msg = Constants.Msg.SessionExp;
                    }
                    else
                    {
                        msg = Constants.Msg.SessionExp;
                    }
                }


                return msg;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool IsPermission(string programCode, string actCode)
        {

            try
            {

                // return true;
                NCLSEntities db = new NCLSEntities();

                var model = db.M_PERMISSION.Where(x => x.PERM_ROLE_CODE == UserRole
                   && x.PERM_PROG_CODE == programCode && x.PERM_ACT_CODE == actCode).ToList();

                if (model.Count > 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }
        public long InsertCurrentLogin()
        {

            try
            {
                NCLSEntities db = new NCLSEntities();
                // db.Database.ExecuteSqlCommand("DELETE T_CURRENT_LOGIN WHERE CL_USER_LOGIN = {0} AND CL_IP_ADDRESS={1}", UserLogin, GetipAddress());
                db.Database.ExecuteSqlCommand("DELETE T_CURRENT_LOGIN WHERE CL_USER_LOGIN = {0} ", UserLogin);
                db.SaveChanges();



                T_CURRENT_LOGIN model = new T_CURRENT_LOGIN();

                model.CL_USER_LOGIN = UserLogin;
                model.CL_ROLE_CODE = UserRole;
                model.CL_IP_ADDRESS = Ip;
                model.CL_LOGIN_DATE = SystemDate;
                model.CL_LAST_ACT_DATE = SystemDate;
                model.CL_STATUS = Constants.Status.Active;

                db.T_CURRENT_LOGIN.Add(model);


                T_LOGIN_HISTORY modelH = new T_LOGIN_HISTORY();
                modelH.CL_USER_LOGIN = UserLogin;
                modelH.CL_ROLE_CODE = UserRole;
                modelH.CL_IP_ADDRESS = Ip;
                modelH.CL_LOGIN_DATE = SystemDate;
                modelH.CL_LAST_ACT_DATE = SystemDate;
                modelH.CL_STATUS = Constants.Status.Active;
                db.T_LOGIN_HISTORY.Add(modelH);

                db.SaveChanges();
                return model.CL_ID;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateCurrentLogin()
        {
            try
            {
                NCLSEntities db = new NCLSEntities();
                var model = db.T_CURRENT_LOGIN.Find(LoginCurrentID);
                if (model != null)
                {
                    model.CL_LAST_ACT_DATE = SystemDate;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private string GetipAddress()
        {
            string strHostName = "127.0.0.1";
            try
            {
                strHostName = HttpContext.Current.Request.UserHostAddress;
                return strHostName;
            }
            catch (Exception)
            {
                return strHostName;
            }

        }
        public void InsertLog(NCLSEntities db, string act, string key, string program)
        {

            // Format desc = Action:Key
            try
            {



                T_ACT_LOG model = new T_ACT_LOG();
                model.AL_USER_LOGIN = UserLogin;
                model.AL_PROG_CODE = program;
                model.AL_DESC = act + ":" + key;
                model.AC_DATE = SystemDate;
                db.T_ACT_LOG.Add(model);

            }
            catch (Exception)
            {

                throw;
            }

        }
        #region Function DataDropDownList && Common
        public List<ddlValuse> GetListDataLevel()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {

                item.CODE = "1";
                item.TEXT = "Owner";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "2";
                item.TEXT = "Role";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "3";
                item.TEXT = "All";
                list.Add(item);
                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListTypeUser()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {

                item.CODE = "0";
                item.TEXT = "Internal";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "1";
                item.TEXT = "External";
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListStatus()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {

                item.CODE = Constants.Status.Active;
                item.TEXT = Constants.Status.ActiveText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.Status.Inactive;
                item.TEXT = Constants.Status.InactiveText;
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListADType()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                item.CODE = "0";
                item.TEXT = "AD";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "1";
                item.TEXT = "Not AD";
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListApproveStatus()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                item.CODE = Constants.ApproveStatus.Approved;
                item.TEXT = Constants.ApproveStatus.ApprovedText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.ApproveStatus.Pending;
                item.TEXT = Constants.ApproveStatus.PendingText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.ApproveStatus.Rejected;
                item.TEXT = Constants.ApproveStatus.RejectedText;
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ddlValuse> GetListApproveStatus2()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                item.CODE = Constants.ApproveStatus.Approved;
                item.TEXT = Constants.ApproveStatus.ApprovedText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.ApproveStatus.Pending;
                item.TEXT = Constants.ApproveStatus.PendingText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.ApproveStatus.Rejected;
                item.TEXT = Constants.ApproveStatus.RejectedText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.ApproveStatus.Cancel;
                item.TEXT = Constants.ApproveStatus.CancelText;
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ddlValuse> GetListDebtorStatus()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                item.CODE = Constants.DebtorStatus.AppearCode;
                item.TEXT = Constants.DebtorStatus.AppearText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.DebtorStatus.NotAppearCode;
                item.TEXT = Constants.DebtorStatus.NotAppearText;
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<ddlValuse> GetListFlag()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {

                item.CODE = "1";
                item.TEXT = "True";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "0";
                item.TEXT = "False";
                list.Add(item);

                return list.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListBatch()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                item.CODE = "";
                item.TEXT = Constants.SelectOption.SelectAll;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC001";
                item.TEXT = "Contract Information";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC002";
                item.TEXT = "RPS";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC003";
                item.TEXT = "Update Status";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC004";
                item.TEXT = "Snap Shot";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC005";
                item.TEXT = "Generate R3";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC006";
                item.TEXT = "Assignment Admin";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "BJOBC007";
                item.TEXT = "Assignment OA";
                list.Add(item);


                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListYesNo()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                item.CODE = "";
                item.TEXT = Constants.SelectOption.SelectOne;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "1";
                item.TEXT = "Yes";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "0";
                item.TEXT = "No";
                list.Add(item);

                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListActive()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {

                item.CODE = Constants.Status.Active;
                item.TEXT = Constants.Status.ActiveText;
                list.Add(item);

                item = new ddlValuse();
                item.CODE = Constants.Status.Inactive;
                item.TEXT = Constants.Status.InactiveText;
                list.Add(item);

                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListInterestStep()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                //item.CODE = "";
                //item.TEXT = Constants.SelectOption.SelectOne;
                //list.Add(item);

                //item = new ddlValuse();
                item.CODE = "P";
                item.TEXT = "Period";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "M";
                item.TEXT = "Months";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "D";
                item.TEXT = "Days";
                list.Add(item);

                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ddlValuse> GetListOAType()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                //item.CODE = "";
                //item.TEXT = Constants.SelectOption.SelectOne;
                //list.Add(item);

                //item = new ddlValuse();
                item.CODE = "Individual";
                item.TEXT = "Individual";
                list.Add(item);

                item = new ddlValuse();
                item.CODE = "Cooperate";
                item.TEXT = "Cooperate";
                list.Add(item);


                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ddlValuse> GetListUserAD()
        {
            List<ddlValuse> list = new List<ddlValuse>();
            ddlValuse item = new ddlValuse();
            try
            {
                LDAPManager objLdap = new LDAPManager(LdapUrl, LdapDomain, LdapUserName, LdapPassword, LdapOuSite);



                foreach (UserResult m in objLdap.SearchUserAll())
                {
                    item = new ddlValuse();
                    item.CODE = m.samaccountname;
                    item.TEXT = m.samaccountname + " " + m.givenname + " " + m.displayname;
                    list.Add(item);
                }



                return list.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<M_MASTER> GetListByMasterType(string type)
        {
            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_MASTER.Where(m => m.MASTER_TYPE == type && m.MASTER_STATUS == Constants.Status.Active).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<M_PROVINCE> GetListProvinces()
        {

            try
            {
                var model = db.M_PROVINCE.Where(m => m.PROVINCE_STATUS == Constants.Status.Active).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<M_WRITEOFF_SUBTYPE> GetListBySubType(string type)
        {

            try
            {
                var model =
                    db.M_WRITEOFF_SUBTYPE.Where(
                        x => x.SUBTYPE_GROUPE_CODE == type && x.SUBTYPE_STATUS == Constants.Status.Active).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<ddlValuse> GetListMasterType()
        {
            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_MASTER.Select(x => new ddlValuse { CODE = x.MASTER_TYPE }).Distinct().ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<M_LEGAL_CASE> GetListLegalCaseByGroup(string group = "")
        {
            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_LEGAL_CASE.Where(m => m.CASE_GROUP_CODE == group || group == "").OrderByDescending(m => m.CASE_SEQ).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<SP_SEARCH_STATUS_BY_CASE_Result> GetListLegalStatusByCase(string caseCode)
        {
            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.SP_SEARCH_STATUS_BY_CASE(caseCode).Where(x => x.STATUS_FLAG == "1").ToList();

                return model ?? new List<SP_SEARCH_STATUS_BY_CASE_Result>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<M_USER> GetListUserByRole(string role = "")
        {
            List<M_USER> list = new List<M_USER>();

            try
            {
                NCLSEntities db = new NCLSEntities();

                if (IsNullOrEmpty(role))
                {
                    list = db.M_USER.ToList();
                }
                else
                {
                    var query = (
                                from m in db.M_USER
                                from d in db.M_USER_ROLE
                                    .Where(d => d.USERROLE_USER_LOGIN == m.USER_LOGIN && d.USERROLE_ROLE_CODE == role)
                                select m

                            );


                    list = query.ToList();

                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        public List<M_OA> GetListOA()
        {

            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_OA.Where(x => x.OA_STATUS == Constants.Status.Active).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<M_BUCKET> GetListBucket()
        {
            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_BUCKET.Where(x => x.BUCKET_STATUS == Constants.Status.Active).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<M_COURT> GetListCourtName()
        {

            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_COURT.Where(x => x.COURT_STATUS == Constants.Status.Active).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<M_TRANSACTION> GetListTransaction()
        {

            NCLSEntities db = new NCLSEntities();
            try
            {
                var model = db.M_TRANSACTION.ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public List<Role> GetListRole(string userLogin = "")
        {
            try
            {
                NCLSEntities db = new NCLSEntities();
                var query = (
                                from m in db.M_ROLE
                                from d in db.M_USER_ROLE
                                    .Where(d => d.USERROLE_ROLE_CODE == m.ROLE_CODE && d.USERROLE_USER_LOGIN == userLogin).DefaultIfEmpty()
                                select new Role
                                {
                                    RoleCode = m.ROLE_CODE,
                                    RoleName = m.ROLE_NAME,
                                    UserLogin = d == null ? string.Empty : d.USERROLE_USER_LOGIN,
                                    RoleFlag = d == null ? false : true
                                }
                            ).ToList();
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetParameterByCode(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_PARAMETER.FirstOrDefault(x => x.PARA_CODE == code).PARA_VALUE;

                return value;
            }
            catch (Exception)
            {
                return "";
                //throw;
            }
            finally
            {

            }

        }
        public string GetNameOAByCode(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_OA.FirstOrDefault(x => x.OA_CODE == code).OA_NAME_TH;

                return value;
            }
            catch (Exception)
            {
                return "";
                //  throw;
            }
            finally
            {

            }

        }
        public string GetProvinceNameByCode(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_PROVINCE.FirstOrDefault(x => x.PROVINCE_CODE == code).PROVINCE_NAME;

                return value;
            }
            catch (Exception)
            {

                return "";
            }
            finally
            {

            }

        }
        public string GetNameMaster(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_MASTER.FirstOrDefault(x => x.MASTER_CODE == code).MASTER_NAME_TH;

                return value;
            }
            catch (Exception)
            {
                return "";
                //  throw;
            }
            finally
            {

            }

        }
        public string GetNameWriteOffSubTypeByCode(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_WRITEOFF_SUBTYPE.FirstOrDefault(x => x.SUBTYPE_CODE == code).SUBTYPE_NAME_TH;

                return value;
            }
            catch (Exception)
            {
                return "";

            }
            finally
            {

            }

        }
        public string GetLegalCaseNameByCode(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_LEGAL_CASE.FirstOrDefault(x => x.CASE_CODE == code).CASE_NAME_TH;

                return value;
            }
            catch (Exception)
            {
                return "";
                // throw;
            }
            finally
            {

            }

        }
        public string GetLegalStatusNameByCode(string code)
        {

            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_STATUS.FirstOrDefault(x => x.STS_CODE == code).STS_NAME_TH;

                return value;
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {

            }

        }
        public string GetNameUserByCode(string code)
        {
            string name = "";
            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.M_USER.FirstOrDefault(x => x.USER_LOGIN == code);

                if (value != null)
                    name = value.USER_FIRST_NAME + " " + value.USER_LAST_NAME;

                return name;
            }
            catch (Exception)
            {
                return "";
                //throw;
            }
            finally
            {

            }

        }
        public string GetAddressByCode(string code)
        {
            string name = "";
            try
            {
                NCLSEntities db = new NCLSEntities();

                var value = db.T_R3_DETAIL.FirstOrDefault(x => x.R3_ADDR_ID == code);

                if (value != null)
                    name = value.R3_ADDR_FULL;

                return name;
            }
            catch (Exception)
            {
                return "";
                //  throw;
            }
            finally
            {

            }

        }
        public string GetMeneDefault(string code)
        {
            string name = "~/Home/Index";
            try
            {
                NCLSEntities db = new NCLSEntities();


                var value = db.SP_GET_MENU_DEFAULT(code).FirstOrDefault();

                if (value != null)
                    name = value;

                return name;


            }
            catch (Exception)
            {
                return "~/Home/Index";
                //  throw;
            }
            finally
            {

            }

        }
        public string GetNameStatus(string code)
        {

            try
            {
                return code == Constants.Status.Active ? "Active" : "In Active";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        public string GetNameApproveStatus(string code)
        {

            try
            {
                if (code == Constants.ApproveStatus.Pending)
                {
                    code = "Pending";
                }
                else if (code == Constants.ApproveStatus.Approved)
                {
                    code = "Approved";
                }
                else if (code == Constants.ApproveStatus.Rejected)
                {
                    code = "Rejected";
                }
                else if (code == Constants.ApproveStatus.Cancel)
                {
                    code = "Cancel";
                }
                else
                {
                    code = null;
                }

                return code;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        public string GetNameAddressType(string code)
        {

            try
            {
                return code == Constants.StatusData.Mailing ? "Mailing" : "Registered";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        public string GetNameCustomerType(string code)
        {

            try
            {
                return code == Constants.StatusCustomer.Borrower ? "Borrower" : "Guarantor";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }

        public string GetDocStatus(string code)
        {

            try
            {
                return code == "1" ? "Generate" : "Not Generate";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        public string GetR3Status(string code)
        {

            try
            {
                if (code == Constants.R3Status.SendR310)
                {
                    code = "กำลังส่ง";
                }
                else if (code == Constants.R3Status.PendingR320)
                {
                    code = "รอใบตอบรับ";
                }
                else if (code == Constants.R3Status.AcceptR330)
                {
                    code = "ลูกค้าตอบรับ";
                }
                else if (code == Constants.R3Status.RejectR340)
                {
                    code = "จดหมายตีกลับ";
                }
                else
                {
                    code = "";
                }

                return code;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        public string GetNameUserAD(string userAD)
        {

            try
            {
                LDAPManager objLdap = new LDAPManager(LdapUrl, LdapDomain, LdapUserName, LdapPassword, LdapOuSite);


                UserResult x = objLdap.SearchUser(userAD);

                return x.cn;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

        }
        public string GetNameDebtorStatus(string code)
        {

            try
            {

                switch (code)
                {
                    case Constants.DebtorStatus.AppearCode:
                        code = Constants.DebtorStatus.AppearText;
                        break;
                    case Constants.DebtorStatus.NotAppearCode:
                        code = Constants.DebtorStatus.NotAppearText;
                        break;
                    case Constants.DebtorStatus.JudgmentDebtorCode:
                        code = Constants.DebtorStatus.JudgmentDebtorText;
                        break;
                    case Constants.DebtorStatus.CompromiseCode:
                        code = Constants.DebtorStatus.CompromiseText;
                        break;
                    default:
                        code = null;
                        break;
                }

                return code;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        public decimal GetStandardRepoFee(int ovdDay, string brand, string model, string body, int km, decimal os)
        {
            decimal returnValue = 0;
            NCLSEntities db = new NCLSEntities();
            decimal valueCheck = 0;
            try
            {
                var config = db.M_REPO_FEE.Where(t => t.REPO_BRAND == brand
                                                && t.REPO_MODEL == model
                                                && t.REPO_BODY == body
                                                && t.REPO_OVD_DAY_FROM <= ovdDay
                                                && t.REPO_OVD_DAY_TO >= ovdDay
                                                ).ToList();

                if (config != null)
                {
                    var rowField = config.FirstOrDefault();
                    string field = rowField.REPO_FIELD;

                    if (field == "KM")
                        valueCheck = km;
                    else if (field == "OS")
                        valueCheck = os;

                    var rowValue = config.Where(t =>
                                               t.REPO_AMT_FROM <= valueCheck
                                               && t.REPO_AMT_TO >= valueCheck).ToList();

                    if (rowValue != null)
                    {
                        returnValue = UnDecimalNull(rowValue.FirstOrDefault().REPO_AMT);
                    }

                }

                return returnValue;
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }

        }
        public decimal GetConfigExpense(string TransCode)
        {
            decimal returnValue = 0;
            NCLSEntities db = new NCLSEntities();
            decimal valueCheck = 0;
            try
            {
                var config = db.SP_SEARCH_EXPENSE_CONFIG(TransCode).ToList();

                //List Field ทั้งหมดที่มี
                // var fieldconfig = db.SP_SEARCH_EXPENSE_CONFIG(TransCode).ToList();

                if (config != null)
                {
                    var configFirstRow = config.FirstOrDefault();

                    if (IsNullOrEmpty(configFirstRow.TRANSD_FIELD))
                    {
                        returnValue = UnDecimalNull(configFirstRow.TRANSD_VALUE);
                    }
                    else
                    {
                        string field = configFirstRow.TRANSD_FIELD;


                        if (field == "KM")
                            valueCheck = 0;
                        else if (field == "OS")
                            valueCheck = 0;

                        var rowValue = config.Where(t =>
                                                    t.TRANSD_FROM <= valueCheck
                                                    && t.TRANSD_TO >= valueCheck).ToList();

                        if (rowValue != null)
                        {
                            var rowValueFirst = rowValue.FirstOrDefault();

                            if (rowValueFirst.TRANSD_EXPENSE_FLAG.Equals("1"))
                            {
                                returnValue = valueCheck * UnDecimalNull(rowValueFirst.TRANSD_VALUE) / 100;
                            }
                            else
                            {
                                returnValue = UnDecimalNull(rowValueFirst.TRANSD_VALUE);
                            }

                        }


                    }
                }



                //if (config != null)
                //{
                //    var rowField = config.FirstOrDefault();
                //    string field = rowField.REPO_FIELD;

                //    if (field == "KM")
                //        valueCheck = km;
                //    else if (field == "OS")
                //        valueCheck = os;

                //    var rowValue = config.Where(t =>
                //                                t.REPO_AMT_FROM >= valueCheck
                //                                && t.REPO_AMT_TO <= valueCheck).ToList();

                //    if (rowValue != null)
                //    {
                //        returnValue = UnDecimalNull(rowValue.FirstOrDefault().REPO_AMT);
                //    }

                //}

                return returnValue;
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }

        }
        public decimal GetTravel(string CourtCode)
        {
            decimal returnValue = 0;
            NCLSEntities db = new NCLSEntities();
            try
            {
                var config = db.M_COURT.Where(t => t.COURT_CODE == CourtCode).ToList();



                if (config != null)
                {
                    var configFirstRow = config.FirstOrDefault();
                    returnValue = UnDecimalNull(configFirstRow.COURT_AMT);

                }


                return returnValue;
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }

        }
        public List<SelectListItem> ListItemsLegalStatus(string legalCase)
        {
            var toReturn = new List<SelectListItem>();
            var db = new NCLSEntities();
            try
            {
                toReturn.Add(new SelectListItem
                {
                    Text = Constants.SelectOption.SelectOne,
                    Value = ""
                });
                db.SP_SEARCH_STATUS_BY_CASE(legalCase)
                    .Where(x => x.STATUS_FLAG == "1")
                    .ToList()
                    .ForEach(x => toReturn.Add(new SelectListItem
                    {
                        Text = x.STS_NAME_TH,
                        Value = x.STS_CODE.ToString()
                    }));
                return toReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SelectListItem> ListItemDebtorStatus
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                toReturn.Add(new SelectListItem
                {
                    Text = Constants.SelectOption.SelectOne,
                    Value = ""
                });
                toReturn.Add(new SelectListItem
                {
                    Text = Constants.DebtorStatus.AppearText,
                    Value = Constants.DebtorStatus.AppearCode
                });
                toReturn.Add(new SelectListItem
                {
                    Text = Constants.DebtorStatus.NotAppearText,
                    Value = Constants.DebtorStatus.NotAppearCode
                });
                return toReturn;
            }
        }

        public List<SelectListItem> ListItemsBank
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    //toReturn.Add(new SelectListItem
                    //{
                    //    Text = Constants.SelectOption.SelectOne,
                    //    Value = ""
                    //});
                    db.M_MASTER.Where(x => x.MASTER_TYPE == "Bank")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.MASTER_NAME_TH,
                            Value = x.MASTER_CODE.ToString()
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsCourt
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    toReturn.Add(new SelectListItem
                    {
                        Text = Constants.SelectOption.SelectOne,
                        Value = ""
                    });
                    db.M_COURT.ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.COURT_NAME_TH,
                            Value = x.COURT_CODE
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsAttorneyStatus
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    toReturn.Add(new SelectListItem
                    {
                        Text = Constants.SelectOption.SelectOne,
                        Value = ""
                    });
                    db.M_MASTER.Where(x => x.MASTER_TYPE == "AttorneyStatus")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.MASTER_NAME_TH,
                            Value = x.MASTER_CODE.ToString()
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsCaseType
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    //toReturn.Add(new SelectListItem
                    //{
                    //    Text = Constants.SelectOption.SelectOne,
                    //    Value = ""
                    //});
                    db.M_MASTER.Where(x => x.MASTER_TYPE == "CaseType")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.MASTER_NAME_TH,
                            Value = x.MASTER_CODE.ToString()
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsUser
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    //toReturn.Add(new SelectListItem
                    //{
                    //    Text = Constants.SelectOption.SelectOne,
                    //    Value = ""
                    //});
                    db.M_USER.Where(x => x.USER_STATUS == "A")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.USER_FIRST_NAME + " " + x.USER_LAST_NAME,
                            Value = x.USER_LOGIN.ToString()
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsOA
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    //toReturn.Add(new SelectListItem
                    //{
                    //    Text = Constants.SelectOption.SelectOne,
                    //    Value = ""
                    //});
                    db.M_OA.Where(x => x.OA_STATUS == "A")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.OA_NAME_TH,
                            Value = x.OA_CODE.ToString()
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsSpecialRefNo
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    //-- LC001	คดีอื่นๆ
                    //-- LC002	คดีสคบ
                    //-- LC003	คดียักยอกทร้พย์
                    //-- LC004	คดีฉ้อโกง
                    //-- LC005	คดีโกงเจ้าหนี้
                    //-- LC006	คดีล้มละลาย
                    //-- LC007	คดีฟิ้นฟูกิจการ
                    //-- LC008	คดีร้องคืนของกลาง
                    //-- LC009	คดีปปส
                    //-- LC010	คดีปปง
                    //-- LC012	คดีเช็ค
                    //-- LC013	คดีรถหาย
                    //-- LC014	เสียหายโดยสิ้นเชิง

                    db.T_JOB_LEGAL.Where(x => x.JOB_CASE == "LC001"
                        || x.JOB_CASE == "LC002"
                        || x.JOB_CASE == "LC003"
                        || x.JOB_CASE == "LC004"
                        || x.JOB_CASE == "LC005"
                        || x.JOB_CASE == "LC006"
                        || x.JOB_CASE == "LC007"
                        || x.JOB_CASE == "LC008"
                        || x.JOB_CASE == "LC009"
                        || x.JOB_CASE == "LC010"
                        || x.JOB_CASE == "LC012"
                        || x.JOB_CASE == "LC013"
                        || x.JOB_CASE == "LC014")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.JOB_ID,
                            Value = x.JOB_ID
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsLegalCaseSpecial
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    //-- LC001	คดีอื่นๆ
                    //-- LC002	คดีสคบ
                    //-- LC003	คดียักยอกทร้พย์
                    //-- LC004	คดีฉ้อโกง
                    //-- LC005	คดีโกงเจ้าหนี้
                    //-- LC006	คดีล้มละลาย
                    //-- LC007	คดีฟิ้นฟูกิจการ
                    //-- LC008	คดีร้องคืนของกลาง
                    //-- LC009	คดีปปส
                    //-- LC010	คดีปปง
                    //-- LC012	คดีเช็ค
                    //-- LC013	คดีรถหาย
                    //-- LC014	เสียหายโดยสิ้นเชิง
                    //-- LC016	ฟ้องส่วนขาดทุน
                    db.M_LEGAL_CASE.Where(x => x.CASE_CODE == "LC001"
                        || x.CASE_CODE == "LC002"
                        || x.CASE_CODE == "LC003"
                        || x.CASE_CODE == "LC004"
                        || x.CASE_CODE == "LC005"
                        || x.CASE_CODE == "LC006"
                        || x.CASE_CODE == "LC007"
                        || x.CASE_CODE == "LC008"
                        || x.CASE_CODE == "LC009"
                        || x.CASE_CODE == "LC010"
                        || x.CASE_CODE == "LC012"
                        || x.CASE_CODE == "LC013"
                        || x.CASE_CODE == "LC014"
                        || x.CASE_CODE == "LC016")
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.CASE_NAME_TH,
                            Value = x.CASE_CODE
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<SelectListItem> ListItemsContractList
        {
            get
            {
                var toReturn = new List<SelectListItem>();
                var db = new NCLSEntities();
                try
                {
                    db.S_CONTRACT
                        .ToList()
                        .ForEach(x => toReturn.Add(new SelectListItem
                        {
                            Text = x.CONTRACT_NO + " : " + x.CUST_NAME_TH,
                            Value = x.CONTRACT_NO
                        }));
                    return toReturn;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public string GetYesNoStatus(string code)
        {

            try
            {
                return code == "1" ? "Yes" : "No";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

        }

        #endregion

        #region Function Convert

        public string UnStringNull(object obj)
        {
            try
            {

                return obj.ToString().Trim();
            }
            catch
            {
                return "";
            }

        }
        public string UnStringNullstring(string obj)
        {
            try
            {
                return obj;
            }
            catch
            {
                return "";
            }

        }
        public string UnDateTimeStringNull(object obj)
        {
            try
            {

                return DateTime.Parse(obj.ToString()).ToString(Constants.Config.DateFormat);
            }
            catch
            {
                return "";
            }

        }
        public double UnDoubleNull(object obj)
        {
            try
            {
                return Convert.ToDouble(obj.ToString().Replace(",", "").Trim());
            }
            catch
            {
                return 0;
            }

        }
        public decimal UnDecimalNull(object obj)
        {
            try
            {
                return Convert.ToDecimal(obj.ToString().Replace(",", "").Trim());
            }
            catch
            {
                return 0;
            }

        }
        public int UnInt32Null(object obj)
        {
            try
            {
                return Convert.ToInt32(obj.ToString().Replace(",", "").Trim());
            }
            catch
            {
                return 0;
            }

        }
        public bool IsNullOrEmpty(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return true;
            else
                return false;
        }
        public bool IsNullOrEmpty(string obj)
        {
            if (obj == null || obj.Trim().Equals(""))
            {
                return true;
            }

            return false;
        }
        protected long UnInt64Null(object obj)
        {
            try
            {
                return Convert.ToInt64(obj.ToString().Replace(",", "").Trim());
            }
            catch
            {
                return 0;
            }

        }
        public string DecryptCrypto(string text)
        {

            try
            {
                ChangeCryptoToTripleDES();
                return ITOS.Utility.Crypto.Crypto.DecryptFast(text);
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public string EncryptCrypto(string text)
        {

            try
            {
                ChangeCryptoToTripleDES();
                return ITOS.Utility.Crypto.Crypto.EncryptFast(text);
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public string Decrypt(string text)
        {

            cTripleDES objTripleDes = new cTripleDES();
            try
            {
                return HttpUtility.UrlDecode(objTripleDes.Decrypt(text));
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public string Encrypt(string text)
        {

            cTripleDES objTripleDes = new cTripleDES();
            try
            {
                return HttpUtility.UrlDecode(objTripleDes.Encrypt(text));
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public void ChangeCryptoToTripleDES()
        {
            try
            {
                ITOS.Utility.Crypto.Crypto.EncryptionAlgorithm = ITOS.Utility.Crypto.Crypto.Algorithm.TripleDES;
                ITOS.Utility.Crypto.Crypto.Encoding = ITOS.Utility.Crypto.Crypto.EncodingType.BASE_64;
            }
            catch
            {
                throw;
            }
        }
        public string EncryptValueInUrl(string pathPage)
        {
            ITOS.Utility.TripleDES.cTripleDES encryptor = new ITOS.Utility.TripleDES.cTripleDES();
            string newPath = "";
            try
            {
                if (pathPage.IndexOf("?") > 0)
                {
                    string strParameter = pathPage.Substring(pathPage.IndexOf("?") + 1);
                    string[] parameter = strParameter.Split('&');

                    newPath = pathPage.Substring(0, pathPage.IndexOf("?") + 1);
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        string text = parameter[i].Substring(0, parameter[i].IndexOf("="));
                        string value = encryptor.Encrypt(parameter[i].Substring(parameter[i].IndexOf("=") + 1));
                        if (i.Equals(0))
                            newPath += text + "=" + System.Web.HttpUtility.UrlEncode(value);
                        else
                            newPath += "&" + text + "=" + System.Web.HttpUtility.UrlEncode(value);
                    }
                    return newPath;
                }
                else
                    return pathPage;

            }
            catch
            {
                throw;
            }
        }
        public void DuplicateTable(DataTable srcTable, DataTable targetTable)
        {
            try
            {
                targetTable.Rows.Clear();
                DataRow dr = null;
                foreach (DataRow dr_loopVariable in srcTable.Rows)
                {
                    foreach (DataColumn dc in targetTable.Columns)
                    {
                        if (dr_loopVariable.IsNull(dc.ColumnName))
                        {
                            switch (targetTable.Columns[dc.ColumnName].DataType.Name.ToLower())
                            {
                                case "dbnull":
                                    dr_loopVariable[dc.ColumnName] = "";
                                    break;

                                case "string":
                                    dr_loopVariable[dc.ColumnName] = "";
                                    break;

                                case "datetime":
                                    // Nick 2015-05-06DateTime dateEmpty = new DateTime();
                                    // dr_loopVariable[dc.ColumnName] = dateEmpty;
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "byte":
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "int16":
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "int32":
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "int64":
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "double":
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "decimal":
                                    dr_loopVariable[dc.ColumnName] = DBNull.Value;
                                    break;

                                case "boolean":
                                    break;
                            }
                        }
                    }
                    dr = dr_loopVariable;
                    targetTable.ImportRow(dr);
                }
                srcTable.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Function Display
        public string DateDisplay(DateTime? objDate)
        {
            DateTime dt = new DateTime();
            try
            {

                return (objDate == null || objDate == dt) ? "" : DateDisplay((DateTime)objDate);
            }
            catch
            {
                return "";
            }
        }

        public string DateDisplay(DateTime objDate)
        {
            DateTime dt = new DateTime();
            try
            {
                return (objDate == null || objDate == dt) ? "" : objDate.ToString(Constants.Config.DateFormat);
            }
            catch
            {
                return "";
            }
        }

        public string DateTimeDisplay(DateTime? objDateTime)
        {
            DateTime dt = new DateTime();
            try
            {
                return (objDateTime == null || objDateTime == dt) ? "" : DateTimeDisplay((DateTime)objDateTime);
            }
            catch
            {
                return "";
            }
        }

        public string DateTimeDisplay(DateTime objDateTime)
        {
            DateTime dt = new DateTime();
            try
            {
                return (objDateTime == null || objDateTime == dt) ? "" : objDateTime.ToString(Constants.Config.DateTimeFormat);
            }
            catch
            {
                return "";
            }
        }

        public string DecimalDisplay(decimal? objDec, int decPlace = 2)
        {
            try
            {
                return (objDec == null) ? (0).ToString("n" + decPlace.ToString()) : DecimalDisplay((decimal)objDec, decPlace);
            }
            catch
            {
                return (0).ToString("n" + decPlace.ToString());
            }
        }

        public string DecimalDisplay(decimal objDec, int decPlace = 2)
        {
            try
            {
                return objDec.ToString("n" + decPlace.ToString());
            }
            catch
            {
                return (0).ToString("n" + decPlace.ToString());
            }
        }

        public string DateSort(DateTime? objDate)
        {
            try
            {
                return (objDate == null) ? "" : DateSort((DateTime)objDate);
            }
            catch
            {
                return "";
            }
        }

        public string DateSort(DateTime objDate)
        {
            try
            {
                return objDate.ToString("yyyyMMddHHmm");
            }
            catch
            {
                return "";
            }
        }

        public string DecimalSort(decimal? objDec, int decPlace = 2)
        {
            try
            {
                return (objDec == null) ? (0).ToString("n" + decPlace.ToString()) : DecimalSort((decimal)objDec, decPlace);
            }
            catch
            {
                return "0000000000" + (0).ToString("n" + decPlace.ToString()).Split('.').Last();
            }
        }

        public string DecimalSort(decimal objDec, int decPlace = 2)
        {
            try
            {
                var toReturn = "";
                toReturn = Convert.ToInt32(objDec).ToString("0000000000");
                toReturn += objDec.ToString("n" + decPlace.ToString()).Split('.').Last();
                return toReturn;
            }
            catch
            {
                return "0000000000" + (0).ToString("n" + decPlace.ToString()).Split('.').Last();
            }
        }


        public string ExpenseName(string objCode)
        {
            var db = new NCLSEntities();
            string toReturn = "";
            try
            {
                var s = db.M_TRANSACTION.Where(x => x.TRANS_CODE == objCode && x.TRANS_STATUS == Constants.Status.Active).ToList();
                toReturn = s[0].TRANS_NAME_TH;
                return toReturn;
            }
            catch
            {
                return "";
            }
        }

        public string getExpenseCode(string objGroup)
        {
            var db = new NCLSEntities();
            string toReturn = "";
            try
            {
                var s = db.M_TRANSACTION.Where(x => x.TRANS_GROUP_CODE == objGroup).ToList();
                toReturn = s[0].TRANS_CODE;
                return toReturn;
            }
            catch
            {
                throw;
            }

        }

        public string getTranGroupCode(string code)
        {
            var db = new NCLSEntities();
            string toReturn = "";
            try
            {
                var s = db.M_TRANSACTION.FirstOrDefault(x => x.TRANS_CODE == code);

                if (s != null)
                    toReturn = s.TRANS_GROUP_CODE;


                return toReturn;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Function Export Import
        public DataTable ReadCSV(string filePath, bool HDR, char delimited = ',')
        {
            DataTable toReturn = new DataTable();
            try
            {
                var lines = File.ReadLines(filePath).ToList();
                var rowCount = lines.Count();
                var colCount = 0;
                if (rowCount > 0)
                {
                    var listOfCol = lines[0].Split(delimited).ToList();
                    colCount = listOfCol.Count();
                    if (HDR)
                    {
                        foreach (var col in listOfCol)
                        {
                            toReturn.Columns.Add(col);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= colCount; i++)
                        {
                            toReturn.Columns.Add("col_" + i.ToString("000"));
                        }
                    }
                }
                for (int i = (HDR) ? 1 : 0; i < rowCount; i++)
                {
                    var dr = toReturn.NewRow();
                    var line = lines[i].Split(delimited);
                    for (int x = 0; x < colCount; x++)
                    {
                        dr[x] = line[x];
                    }
                    toReturn.Rows.Add(dr);
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public class JsonDotNetResult : ActionResult
        {
            private object _obj { get; set; }
            public JsonDotNetResult(object obj)
            {
                _obj = obj;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.AddHeader("content-type", "application/json");
                context.HttpContext.Response.Write(JsonConvert.SerializeObject(_obj));
            }
        }
        public DataTable ReadExcel(string strExcelPath, string specificExpr = "")
        {
            DataTable toReturn = new DataTable();
            string connString = "";
            try
            {

                string fileType = strExcelPath.Split('.').Last();


                //--- for Jet 4.0 (.xls)
                if (fileType == "xls")
                {
                    connString = "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + strExcelPath + "'; Extended Properties=Excel 8.0;";

                }
                else if (fileType == "xlsx")
                {
                    // connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=""Excel 8.0;IMEX=1""";
                    connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;\";", strExcelPath);
                    //connString = "provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + strExcelPath + "'; Extended Properties=Excel 8.0";
                }//--- for ACE (.xlsx)
                //Dim connString As String = "Provider=Microsoft.ACE.OLEDB." & ExcelVersion & ";Data Source='" & strExcelPath & "';Extended Properties='Excel " & ExcelVersion & ";IMEX=1'"
                OleDbConnection odbConn = new OleDbConnection(connString);
                OleDbCommand odbCmd = new OleDbCommand();
                OleDbDataAdapter odbDa = new OleDbDataAdapter(odbCmd);
                odbCmd.Connection = odbConn;
                odbConn.Open();
                DataTable dtSchema = new DataTable();
                dtSchema = odbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                if (dtSchema.Rows.Count > 0)
                {
                    odbCmd.CommandText = "SELECT * FROM [" + dtSchema.Rows[0]["TABLE_NAME"] + "] " + specificExpr;

                    odbDa.Fill(toReturn);
                }
                odbConn.Close();
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("MainModule.ReadExcel --> " + ex.Message);
            }
        }
        public string ExportExcel(DataTable dt, string filePathName)
        {

            try
            {
                //Check Path Directory Exists
                var filePath = Path.GetDirectoryName(filePathName);
                bool exists = Directory.Exists(filePath);
                if (!exists)
                    Directory.CreateDirectory(filePath);

                //open file
                StreamWriter wr = new StreamWriter(filePathName, false, Encoding.GetEncoding("TIS-620"));

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString() + "\t");
                }

                wr.WriteLine();
                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line

                    wr.WriteLine();
                }
                //close file
                wr.Close();

                return filePathName;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void WriteLogError(string message)
        {
            try
            {

                string filePath = PathLog;

                bool exists = Directory.Exists(filePath);
                if (!exists)
                    Directory.CreateDirectory(filePath);

                filePath = filePath + @"\Log" + DateTime.Now.ToString("_yyyyMMdd") + ".txt";



                if (!IsNullOrEmpty(message))
                {
                    string ORMXML = "";
                    ORMXML += SystemDate.ToString("yyyy-MM-dd HH:mm:ss.fff ") + message + Environment.NewLine;
                    System.IO.File.AppendAllText(filePath, ORMXML, System.Text.Encoding.UTF8);
                }
            }
            catch //(Exception ex)
            {

            }
        }



        public DataTable ToDataTable<T>(List<T> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            try
            {
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public class ExcelResult : ActionResult
        {
            public string FileName { get; set; }
            public string Path { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.Buffer = true;
                context.HttpContext.Response.Clear();
                context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
                context.HttpContext.Response.ContentType = "application/vnd.ms-excel";
                context.HttpContext.Response.WriteFile(context.HttpContext.Server.MapPath(Path));
            }
        }
        public bool CheckExtensionFile(string str)
        {
            // if (!CheckExtensionFile(Path.GetExtension(flUpPath.FileName)))
            bool results = false;
            try
            {
                switch (str.ToLower())
                {


                    case "xls": results = true; break;
                    case "xlsx": results = true; break;
                    case "doc": results = true; break;
                    case "docx": results = true; break;
                    case "jpg": results = true; break;
                    case "pdf": results = true; break;
                    case "zip": results = true; break;

                        //   .xls, .xlsx, .doc, .docx, .jpg, .zip  และ .pdf
                }


                return results;
            }
            catch
            {
                throw;
            }
            finally
            {

            }


        }

        public bool CheckExcekFile(string str)
        {
            // if (!CheckExtensionFile(Path.GetExtension(flUpPath.FileName)))
            bool results = false;
            try
            {
                switch (str.ToLower())
                {


                    case "xls": results = true; break;
                    case "xlsx": results = true; break;


                        //   .xls, .xlsx, .doc, .docx, .jpg, .zip  และ .pdf
                }


                return results;
            }
            catch
            {
                throw;
            }
            finally
            {

            }


        }

        #endregion

        public class PayInModel
        {

            public string ContractNo { get; set; }
            public string BarCodeBBL { get; set; }
            public string BarCodeCITI { get; set; }
            public string StrDueDate { get; set; }
            public decimal OVDAmt { get; set; }
            public string OVDTermStart { get; set; }
            public string CustName { get; set; }
            public string Asset { get; set; }
            public string Plate { get; set; }
            public string DealerType { get; set; }
        }

        public class ddlValuse
        {
            public string CODE { get; set; }
            public string TEXT { get; set; }
        }

        #region Calculate Interest
        public void GetDifference(DateTime? date1, DateTime? date2, ref int Years,
             ref int Months, ref int Weeks, ref int Days)
        {
            //assumes date2 is the bigger date for simplicity

            //years
            TimeSpan diff = date2.Value - date1.Value;
            Years = diff.Days / 366;
            DateTime workingDate = date1.Value.AddYears(Years);

            while (workingDate.AddYears(1) <= date2)
            {
                workingDate = workingDate.AddYears(1);
                Years++;
            }

            //months
            diff = date2.Value - workingDate;
            Months = diff.Days / 31;
            workingDate = workingDate.AddMonths(Months);

            while (workingDate.AddMonths(1) <= date2)
            {
                workingDate = workingDate.AddMonths(1);
                Months++;
            }

            //weeks and days
            diff = date2.Value - workingDate;
            Weeks = diff.Days / 7; //weeks always have 7 days
            Days = diff.Days % 7;
        }
        public decimal CalculateInterest(decimal amount, DateTime? dtStartDate, DateTime? dtEndDate, decimal rate)
        {
            decimal interest = 0;
            int days = 0;
            try
            {
                if (!IsNullOrEmpty(dtStartDate) && !IsNullOrEmpty(dtEndDate))
                {
                    days = (int)(dtEndDate - dtStartDate).Value.TotalDays;
                    interest = ((amount * (rate / 100)) / 360) * days;
                }



                return interest;
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateMonth(decimal amount, DateTime? dtStartDate, DateTime? dtEndDate, int avg)
        {
            decimal total = 0;
            int year = 0;
            int month = 0;
            int week = 0;
            int days = 0;

            try
            {
                if (!IsNullOrEmpty(dtStartDate) && !IsNullOrEmpty(dtEndDate))
                {
                    GetDifference(dtStartDate, dtEndDate, ref year, ref month, ref week, ref days);
                    month = year * 12 + month;
                    days = week * 7 + days;
                    //  month = (dtEndDate.Value.Day + dtEndDate.Value.Month + dtEndDate.Value.Year * 12) - (dtStartDate.Value.Day + dtStartDate.Value.Month + dtStartDate.Value.Year * 12);

                    //dtStartDate = dtStartDate.Value.AddMonths(month);
                    //   days = (int)(dtEndDate - dtStartDate).Value.TotalDays;

                    //   if (days < 0)
                    //       days = (int)(dtStartDate - dtEndDate).Value.TotalDays;

                    total = (amount * month) + (days * (amount / avg));
                }

                return total;
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateInterest(decimal? paymentAmount, decimal? interestRate, int numOfDays)
        {
            decimal interest = 0;
            decimal decPaymentAmount, decInterestRate;
            if (paymentAmount == null)
                decPaymentAmount = default(decimal);
            else
                decPaymentAmount = paymentAmount.Value;

            if (interestRate == null)
                decInterestRate = default(decimal);
            else
                decInterestRate = interestRate.Value;

            try
            {
                interest = ((decPaymentAmount * (decInterestRate / 100)) / 360) * numOfDays;
                return interest;
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateTotalAmount(decimal? paymentAmount, decimal interest)
        {
            decimal TotalAmount = 0;
            decimal dobPaymentAmount;

            try
            {
                if (paymentAmount == null)
                    dobPaymentAmount = default(decimal);
                else
                    dobPaymentAmount = paymentAmount.Value;


                TotalAmount = dobPaymentAmount + interest;
                return TotalAmount;
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateTotalAmount(decimal? paymentAmount, DateTime? startDate, DateTime? endDate, string MonthFlag, string InterestFlag, decimal? InterestRate, int NumOfday)
        {
            decimal TotalAmount = 0;
            decimal dobPaymentAmount;

            decimal monthValue = 0;
            decimal interestValue = 0;

            var sd = new DateTime?();
            var ed = new DateTime?();

            decimal dobInterestRate;

            try
            {
                if (paymentAmount == null)
                {
                    dobPaymentAmount = default(decimal);
                }
                else
                {
                    dobPaymentAmount = paymentAmount.Value;
                }

                if (startDate.HasValue)
                {
                    sd = startDate;
                }
                else
                {
                    sd = SystemDate;
                }

                if (endDate.HasValue)
                {
                    ed = endDate;
                }
                else
                {
                    ed = SystemDate;
                }

                if (InterestRate == null)
                {
                    dobInterestRate = default(decimal);
                }
                else
                {
                    dobInterestRate = InterestRate.Value;
                }

                if (Constants.YesNo.Yes.Equals(MonthFlag))
                {
                    monthValue = CalculateMonth(dobPaymentAmount, sd, ed, int.Parse(GetParameterByCode(Constants.ParaCode.ParaX22)));
                }

                if (Constants.YesNo.Yes.Equals(InterestFlag))
                {
                    interestValue = CalculateInterest(dobPaymentAmount, dobInterestRate, NumOfday);
                }

                TotalAmount = dobPaymentAmount + monthValue + interestValue;
                return TotalAmount;
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateTotalAmount(DateTime? startDate, DateTime? endDate, decimal? paymentAmount, string interestFlag, decimal interest, string monthFlag, int month)
        {
            decimal TotalAmount = 0;
            decimal dobPaymentAmount;

            try
            {
                if (paymentAmount == null)
                    dobPaymentAmount = default(decimal);
                else
                    dobPaymentAmount = paymentAmount.Value;


                TotalAmount = dobPaymentAmount + interest;
                return TotalAmount;
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateOverLoss(decimal? amount, decimal? paymentAmount)
        {
            decimal TotalAmount = 0;
            decimal dobAmount, dobPaymentAmount;

            try
            {
                if (amount == null)
                    dobAmount = default(decimal);
                else
                    dobAmount = amount.Value;

                if (paymentAmount == null)
                    dobPaymentAmount = default(decimal);
                else
                    dobPaymentAmount = paymentAmount.Value;

                TotalAmount = dobPaymentAmount - dobAmount;
                return TotalAmount;
            }
            catch
            {
                return 0;
            }
        }

        public int CalculateNumOfDay(DateTime? startDate, DateTime? endDate)
        {
            int numOfDays = 0;
            try
            {
                if (startDate.HasValue)
                {
                    if (endDate.HasValue)
                    {
                        numOfDays = (int)((endDate - startDate).Value.TotalDays);
                    }
                    else
                    {
                        numOfDays = (int)((SystemDate - startDate).Value.TotalDays);
                    }
                }

                return numOfDays;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int CalculateNumOfDay(string intersetStep, int? days, int? month,
                                        DateTime? interestStartDate, DateTime? interestEndDate, string interestEndDateFlag)
        {
            int numOfDays = 0;
            try
            {
                if (Constants.InterestStep.Period.Equals(intersetStep))
                {
                    var endDateFlag = interestEndDateFlag;

                    if (endDateFlag != null)
                    {

                        if (endDateFlag.Equals(1))
                        {

                            if (interestStartDate.Value != null)
                            {
                                numOfDays = (int)((SystemDate - interestStartDate).Value.TotalDays);
                            }
                            else
                            {
                                numOfDays = 0;
                            }

                        }
                        else
                        {

                            if (interestStartDate.Value != null && interestEndDate.Value != null)
                            {
                                numOfDays = (int)((interestEndDate - interestStartDate).Value.TotalDays);
                            }
                            else
                            {
                                numOfDays = 0;
                            }

                        }
                    }
                    else
                    {

                        if (interestStartDate.Value != null && interestEndDate.Value != null)
                        {
                            numOfDays = (int)((interestEndDate - interestStartDate).Value.TotalDays);
                        }
                        else
                        {
                            numOfDays = 0;
                        }

                    }
                }
                else if (Constants.InterestStep.Months.Equals(intersetStep))
                {
                    if (interestStartDate.Value != null && month.Value != null)
                    {
                        var endDate = interestStartDate.Value.AddMonths(month.Value);
                        numOfDays = (int)((endDate - interestStartDate).Value.TotalDays);
                    }
                    else
                    {
                        numOfDays = 0;
                    }
                }
                else if (Constants.InterestStep.Days.Equals(intersetStep))
                {
                    numOfDays = days.Value;
                }
                return numOfDays;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int CalculateNumOfDayToNow(string intersetStep, int? days, int? month,
                                      DateTime? interestStartDate, DateTime? interestEndDate, string interestEndDateFlag)
        {
            int numOfDays = 0;
            try
            {
                if (Constants.InterestStep.Period.Equals(intersetStep))
                {
                    var endDateFlag = interestEndDateFlag;

                    if (endDateFlag != null)
                    {

                        if (endDateFlag.Equals(1))
                        {

                            if (interestStartDate.Value != null)
                            {
                                numOfDays = (int)((SystemDate - interestStartDate).Value.TotalDays);
                            }
                            else
                            {
                                numOfDays = 0;
                            }

                        }
                        else
                        {

                            if (interestStartDate.Value != null && interestEndDate.Value != null)
                            {
                                numOfDays = (int)((interestEndDate - interestStartDate).Value.TotalDays);
                            }
                            else
                            {
                                numOfDays = 0;
                            }

                        }
                    }
                    else
                    {

                        if (interestStartDate.Value != null && interestEndDate.Value != null)
                        {
                            numOfDays = (int)((interestEndDate - interestStartDate).Value.TotalDays);
                        }
                        else
                        {
                            numOfDays = 0;
                        }

                    }
                }
                else if (Constants.InterestStep.Months.Equals(intersetStep))
                {
                    if (interestStartDate.Value != null && month.Value != null)
                    {
                        var endDate = interestStartDate.Value.AddMonths(month.Value);
                        numOfDays = (int)((endDate - interestStartDate).Value.TotalDays);
                    }
                    else
                    {
                        numOfDays = 0;
                    }
                }
                else if (Constants.InterestStep.Days.Equals(intersetStep))
                {
                    numOfDays = days.Value;
                }
                return numOfDays;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion


        public string GetUserName(string userLogin)
        {
            var db = new NCLSEntities();
            try
            {
                var displayName = db.M_USER
                    .Where(x => x.USER_LOGIN == userLogin)
                    .Select(x => x.USER_FIRST_NAME + " " + x.USER_LAST_NAME).FirstOrDefault();
                if (displayName == null) displayName = "";
                return displayName;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetTransactionNameTH(string code)
        {
            var db = new NCLSEntities();
            try
            {
                var Name = db.M_TRANSACTION
                    .Where(x => x.TRANS_CODE == code)
                    .Select(x => x.TRANS_NAME_TH).FirstOrDefault();
                if (Name == null) Name = "";
                return Name;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //public decimal GetVat(decimal? Amount, DateTime? date)
        //{
        //    var db = new NCLSEntities();
        //    try
        //    {
        //        decimal rateVat = 0;
        //        rateVat = UnDecimalNull(db.SP_GET_VAT_RATE(date).FirstOrDefault());
        //        decimal numVat = UnDecimalNull((Amount * rateVat / (100 + rateVat)));
        //        return numVat;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}
        public List<M_TAX_CONFIG> GetListTax(string OAType)
        {
            try
            {

                var MTax = db.M_TAX_CONFIG.Where(x => x.TAX_TYPE == OAType).ToList();

                return MTax;

            }
            catch (Exception)
            {
                return null;
            }

        }


    }
}
