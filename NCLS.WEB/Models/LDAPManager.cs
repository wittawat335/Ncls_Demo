using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using NCLS.WEB.Utility;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;

namespace NCLS.WEB.Models
{
    public class LDAPManager
    {
        private string _ldapUrl, _ldapUsername, _ldapPassword, _ldapDomain, _ldapOuSite, _errorDesc;
        bool _isError = true;
        private DirectoryEntry objDirectoryEntry;
        Common cm = new Common();
        public string LdapUrl
        {
            get
            {
                return _ldapUrl;
            }
            set
            {
                _ldapUrl = value;
            }
        }

        public string LdapUsername
        {
            get
            {
                return _ldapUsername;
            }
            set
            {
                _ldapUsername = value;
            }
        }

        public string LdapPassword
        {
            get
            {
                return _ldapPassword;
            }
            set
            {
                _ldapPassword = value;
            }
        }

        public string LdapDomain
        {
            get
            {
                return _ldapDomain;
            }
            set
            {
                _ldapDomain = value;
            }
        }

        public string LdapOuSite
        {
            get
            {
                return _ldapOuSite;
            }
            set
            {
                _ldapOuSite = value;
            }
        }

        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
            }
        }
        public string ErrorDesc
        {
            get
            {
                return _errorDesc;
            }
            set
            {
                _errorDesc = value;
            }
        }

        public LDAPManager(string domain, string userName, string pwd)
        {
            try
            {
                _isError = true;
                LdapConnection connection = new LdapConnection(domain);
                NetworkCredential credential = new NetworkCredential(userName, pwd);
                connection.Credential = credential;
                connection.Bind();


            }
            catch (Exception ex)
            {
                _isError = false;
                _errorDesc = ex.Message.ToString();
                //  _errorDesc = ex.ErrorCode.ToString() + " || " + ex.ExtendedError.ToString() + " || " + ex.ExtendedErrorMessage.ToString();
            }

        }


        public LDAPManager(string ldapUrl, string ldapDomian, string ldapUserName, string ldapPassword, string ldapOuSite)
        {
            try
            {
                _isError = true;
                _errorDesc = "";

                _ldapUrl = ldapUrl;
                _ldapDomain = ldapDomian;
                _ldapUsername = ldapUserName;
                _ldapPassword = ldapPassword;
                _ldapOuSite = ldapOuSite;
                objDirectoryEntry = new DirectoryEntry(_ldapUrl, _ldapUsername, _ldapPassword);

                objDirectoryEntry.AuthenticationType = AuthenticationTypes.Secure;
                objDirectoryEntry.Path = string.Format("LDAP://OU={0},{1}", _ldapOuSite, ldapDomian);
                //        int xx = (int)objDirectoryEntry.Properties["useraccountcontrol"].Value;
            }
            catch (Exception ex)
            {
                _isError = false;
                _errorDesc = ex.Message.ToString();
                //  _errorDesc = ex.ErrorCode.ToString() + " || " + ex.ExtendedError.ToString() + " || " + ex.ExtendedErrorMessage.ToString();
            }
        }



        public List<UserResult> SearchUserAll()
        {
            List<UserResult> UserAD = new List<UserResult>();
            int i = 0;
            try
            {
                _isError = true;
                _errorDesc = "";
                DirectorySearcher searcher = new DirectorySearcher();
                searcher.SearchRoot = objDirectoryEntry;
                searcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user))");
                foreach (SearchResult result in searcher.FindAll())
                {
                    UserResult objUser = new UserResult();


                    if (!cm.IsNullOrEmpty(result.Properties["givenName"][i]))
                        objUser.givenname = result.Properties["givenName"][i].ToString();

                    if (!cm.IsNullOrEmpty(result.Properties["displayname"][i]))
                        objUser.displayname = result.Properties["displayname"][i].ToString();

                    if (!cm.IsNullOrEmpty(result.Properties["sAMAccountName"][i]))
                        objUser.samaccountname = result.Properties["sAMAccountName"][i].ToString();

                    UserAD.Add(objUser);
                }

                return UserAD;
            }
            catch (Exception ex)
            {
                _isError = false;
                _errorDesc = ex.Message.ToString();
                // _errorDesc = ex.ErrorCode.ToString() + " || " + ex.ExtendedError.ToString() + " || " + ex.ExtendedErrorMessage.ToString();
                return UserAD;
            }
        }
        public UserResult SearchUser(string userName)
        {
            UserResult objUser = null;
            try
            {
                _isError = true;
                _errorDesc = "";
                DirectorySearcher searcher = new DirectorySearcher();
                searcher.SearchRoot = objDirectoryEntry;
                searcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", userName);

                foreach (SearchResult result in searcher.FindAll())
                {
                    objUser = new UserResult();

                    if (result.Properties["msds-supportedencryptiontypes"].Count > 0)
                        objUser.msds_supportedencryptiontypes = result.Properties["msds-supportedencryptiontypes"][0].ToString();

                    if (result.Properties["givenname"].Count > 0)
                        objUser.givenname = result.Properties["givenname"][0].ToString();

                    if (result.Properties["samaccountname"].Count > 0)
                        objUser.samaccountname = result.Properties["samaccountname"][0].ToString();

                    if (result.Properties["cn"].Count > 0)
                        objUser.cn = result.Properties["cn"][0].ToString();

                    if (result.Properties["pwdlastset"].Count > 0)
                        objUser.pwdlastset = result.Properties["pwdlastset"][0].ToString();

                    if (result.Properties["whencreated"].Count > 0)
                        objUser.whencreated = result.Properties["whencreated"][0].ToString();

                    if (result.Properties["badpwdcount"].Count > 0)
                        objUser.badpwdcount = result.Properties["badpwdcount"][0].ToString();

                    if (result.Properties["displayname"].Count > 0)
                        objUser.displayname = result.Properties["displayname"][0].ToString();

                    if (result.Properties["lastlogon"].Count > 0)
                        objUser.lastlogon = result.Properties["lastlogon"][0].ToString();

                    if (result.Properties["samaccounttype"].Count > 0)
                        objUser.samaccounttype = result.Properties["samaccounttype"][0].ToString();

                    if (result.Properties["countrycode"].Count > 0)
                        objUser.countrycode = result.Properties["countrycode"][0].ToString();

                    if (result.Properties["objectguid"].Count > 0)
                        objUser.objectguid = result.Properties["objectguid"][0].ToString();

                    if (result.Properties["lastlogontimestamp"].Count > 0)
                        objUser.lastlogontimestamp = result.Properties["lastlogontimestamp"][0].ToString();

                    if (result.Properties["usnchanged"].Count > 0)
                        objUser.usnchanged = result.Properties["usnchanged"][0].ToString();

                    if (result.Properties["whenchanged"].Count > 0)
                        objUser.whenchanged = result.Properties["whenchanged"][0].ToString();

                    if (result.Properties["name"].Count > 0)
                        objUser.name = result.Properties["name"][0].ToString();

                    if (result.Properties["objectsid"].Count > 0)
                        objUser.objectsid = result.Properties["objectsid"][0].ToString();

                    if (result.Properties["lastlogoff"].Count > 0)
                        objUser.lastlogoff = result.Properties["lastlogoff"][0].ToString();

                    if (result.Properties["lockouttime"].Count > 0)
                        objUser.lockouttime = result.Properties["lockouttime"][0].ToString();

                    if (result.Properties["badpasswordtime"].Count > 0)
                        objUser.badpasswordtime = result.Properties["badpasswordtime"][0].ToString();

                    if (result.Properties["instancetype"].Count > 0)
                        objUser.instancetype = result.Properties["instancetype"][0].ToString();

                    if (result.Properties["primarygroupid"].Count > 0)
                        objUser.primarygroupid = result.Properties["primarygroupid"][0].ToString();

                    if (result.Properties["objectcategory"].Count > 0)
                        objUser.objectcategory = result.Properties["objectcategory"][0].ToString();

                    if (result.Properties["logoncount"].Count > 0)
                        objUser.logoncount = result.Properties["logoncount"][0].ToString();

                    if (result.Properties["useraccountcontrol"].Count > 0)
                    {

                        objUser.useraccountcontrol = result.Properties["useraccountcontrol"][0].ToString();
                        //   int xx = (int)objDirectoryEntry.Properties["useraccountcontrol"].Value;
                    }
                    if (result.Properties["admincount"].Count > 0)
                        objUser.admincount = result.Properties["admincount"][0].ToString();

                    if (result.Properties["dscorepropagationdata"].Count > 0)
                        objUser.dscorepropagationdata = result.Properties["dscorepropagationdata"][0].ToString();

                    if (result.Properties["distinguishedname"].Count > 0)
                        objUser.distinguishedname = result.Properties["distinguishedname"][0].ToString();

                    if (result.Properties["objectclass"].Count > 0)
                        objUser.objectclass = result.Properties["objectclass"][0].ToString();

                    if (result.Properties["adspath"].Count > 0)
                        objUser.adspath = result.Properties["adspath"][0].ToString();

                    if (result.Properties["usncreated"].Count > 0)
                        objUser.usncreated = result.Properties["usncreated"][0].ToString();

                    if (result.Properties["memberof"].Count > 0)
                        objUser.memberof = result.Properties["memberof"][0].ToString();

                    if (result.Properties["userprincipalname"].Count > 0)
                        objUser.userprincipalname = result.Properties["userprincipalname"][0].ToString();

                    if (result.Properties["accountexpires"].Count > 0)
                        objUser.accountexpires = result.Properties["accountexpires"][0].ToString();

                    if (result.Properties["description"].Count > 0)
                        objUser.description = result.Properties["description"][0].ToString();

                    if (result.Properties["codepage"].Count > 0)
                        objUser.codepage = result.Properties["codepage"][0].ToString();

                    if (result.Properties["sn"].Count > 0)
                        objUser.sn = result.Properties["sn"][0].ToString();

                    if (result.Properties["puid"].Count > 0)
                        objUser.sn = result.Properties["puid"][0].ToString();


                    //  objUser.isDisable = IsActiveUser(userName);
                    break;
                }

                return objUser;
            }
            catch (Exception ex)
            {
                _isError = false;
                _errorDesc = ex.Message.ToString();
                //_errorDesc = ex.ErrorCode.ToString() + " || " + ex.ExtendedError.ToString() + " || " + ex.ExtendedErrorMessage.ToString();
                return objUser;
            }
        }

        public string SearchUser(string userName, int i)
        {

            SearchResult result;
            try
            {
                _isError = true;
                _errorDesc = "";
                DirectorySearcher searcher = new DirectorySearcher();
                searcher.SearchRoot = objDirectoryEntry;
                searcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", userName);

                result = searcher.FindOne();



                return _errorDesc;
            }
            catch (Exception ex)
            {
                _isError = false;
                _errorDesc = ex.Message.ToString(); ;

                //  _errorDesc = ex.ErrorCode.ToString() + " || " + ex.ExtendedError.ToString() + " || " + ex.ExtendedErrorMessage.ToString();
                return _errorDesc;
            }


        }

        public bool IsActiveUser(string userName)
        {
            try
            {
                _isError = true;
                _errorDesc = "";
                DirectorySearcher searcher = new DirectorySearcher();
                searcher.SearchRoot = objDirectoryEntry;
                searcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                searcher.Filter = "(&(objectClass=User)(userAccountControl:1.2.840.113556.1.4.803:=2))";

                foreach (SearchResult result in searcher.FindAll())
                {
                    ResultPropertyValueCollection objResultValSearch = result.Properties["sAMAccountName"];
                    if (objResultValSearch.Count > 0)
                    {
                        foreach (string value in objResultValSearch)
                        {
                            if (value != null && value.Equals(userName))
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorDesc = ex.Message.ToString();
                throw;
            }
        }



    }
    public class UserResult
    {

        public string msds_supportedencryptiontypes { get; set; }
        public string givenname { get; set; }
        public string samaccountname { get; set; }
        public string cn { get; set; }
        public string pwdlastset { get; set; }
        public string whencreated { get; set; }
        public string badpwdcount { get; set; }
        public string displayname { get; set; }
        public string lastlogon { get; set; }
        public string samaccounttype { get; set; }
        public string countrycode { get; set; }
        public string objectguid { get; set; }
        public string lastlogontimestamp { get; set; }
        public string usnchanged { get; set; }
        public string whenchanged { get; set; }
        public string name { get; set; }
        public string objectsid { get; set; }
        public string lastlogoff { get; set; }
        public string lockouttime { get; set; }
        public string badpasswordtime { get; set; }
        public string instancetype { get; set; }
        public string primarygroupid { get; set; }
        public string objectcategory { get; set; }
        public string logoncount { get; set; }
        public string useraccountcontrol { get; set; }
        public string admincount { get; set; }
        public string dscorepropagationdata { get; set; }
        public string distinguishedname { get; set; }
        public string objectclass { get; set; }
        public string adspath { get; set; }
        public string usncreated { get; set; }
        public string memberof { get; set; }
        public string userprincipalname { get; set; }
        public string accountexpires { get; set; }
        public string description { get; set; }
        public string codepage { get; set; }
        public string sn { get; set; }
    }
}