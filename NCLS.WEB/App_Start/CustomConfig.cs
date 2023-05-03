using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NCLS.WEB.Utility;

namespace NCLS.WEB.App_Start
{
    public class CustomConfig : Controller
    {


        public class CultureAwareControllerActivator : IControllerActivator
        {
            public IController Create(RequestContext requestContext, Type controllerType)
            {
                //Get the {language} parameter in the RouteData
                string language = requestContext.RouteData.Values["language"] == null ?
                    Constants.Config.UICulture : requestContext.RouteData.Values["language"].ToString();

                //Get the culture info of the language code
                CultureInfo culture = CultureInfo.GetCultureInfo(language);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                return DependencyResolver.Current.GetService(controllerType) as IController;
            }
        }

        public class DecimalModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext,
                                            ModelBindingContext bindingContext)
            {
                ValueProviderResult valueResult = bindingContext.ValueProvider
                    .GetValue(bindingContext.ModelName);
                ModelState modelState = new ModelState { Value = valueResult };
                object actualValue = null;
                try
                {
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue,
                        CultureInfo.CurrentCulture);
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }

                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                return actualValue;
            }
        }

        public class NullableDecimalBinder : IModelBinder
        {

            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                ModelState modelState = new ModelState { Value = valueResult };
                object result = null;

                if (valueResult != null)
                {
                    if (valueResult.AttemptedValue.Length > 0)
                    {
                        try
                        {
                            // Bonus points: This will bind using the user's current culture.
                            result = Convert.ToDecimal(valueResult.AttemptedValue, System.Globalization.CultureInfo.CurrentCulture);
                        }
                        catch (FormatException e)
                        {
                            modelState.Errors.Add(e);
                        }
                        catch (InvalidOperationException e)
                        {
                            modelState.Errors.Add(e);
                        }
                    }
                }


                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                return result;
            }
        }

    }
}