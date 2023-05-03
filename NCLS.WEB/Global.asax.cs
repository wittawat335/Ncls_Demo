using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NCLS.WEB.App_Start;
using NCLS.WEB.Controllers;
using NCLS.WEB.Utility;

namespace NCLS.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CustomModelBindersConfig.RegisterCustomModelBinders();
            ModelBinders.Binders.Add(typeof(decimal), new App_Start.CustomConfig.DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new App_Start.CustomConfig.NullableDecimalBinder());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Enter - Application_Error");

            var httpContext = ((MvcApplication)sender).Context;

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            string ErrorController = " ";
            string ErrorAction = " ";
            string ErrorCode = "500";
            string ErrorMsg = "CustomError";
            Common cm = new Common();
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    ErrorController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    ErrorAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();

            if (ex != null)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    System.Diagnostics.Trace.WriteLine(ex.InnerException);
                    System.Diagnostics.Trace.WriteLine(ex.InnerException.Message);
                }
            }

            var controller = new ErrorController();
            var routeData = new RouteData();


            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                ErrorCode = httpEx.GetHttpCode().ToString();

                switch (ErrorCode)
                {
                    case "400":
                        ErrorMsg = "BadRequest";
                        break;

                    case "401":
                        ErrorMsg = "Unauthorized";
                        break;

                    case "403":
                        ErrorMsg = "Forbidden";
                        break;

                    case "404":
                        ErrorMsg = "PageNotFound";
                        break;

                    case "500":
                        ErrorMsg = "CustomError";
                        break;

                    default:
                        ErrorMsg = "CustomError";
                        break;
                }
            }
            else if (ex is AuthenticationException)
            {
                ErrorMsg = "Forbidden";
                ErrorCode = "403";
            }
            ErrorMsg = ErrorMsg + " " + ex.Message.ToString();
            httpContext.ClearError();
            httpContext.Response.Clear();

            // string url = string.Format("~/Error/Error?ErrorPage={0}&ErrorCode={1}&ErrorMsg={2}", ErrorController, ErrorCode, ErrorMsg);
            string url = string.Format("~/Error/Error");
            cm.ErrorMsg = ErrorMsg;
            cm.ErrorPage = ErrorController;
            url = cm.EncryptValueInUrl(url);
            httpContext.Response.Redirect(url);
        }
    }
}
