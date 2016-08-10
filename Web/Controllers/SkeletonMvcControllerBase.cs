using System.Web.Mvc;
using JetBrains.Annotations;
using Web.ViewModels.Error;

namespace Web.Controllers
{
    public class SkeletonMvcControllerBase : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            var viewName = "~/Views/Error/OnException.cshtml";
            var model = new ErrorOnExceptionModel()
            {
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                Action = filterContext.RouteData.Values["action"].ToString(),

                ExceptionType = filterContext.Exception.GetType().Name,
                ExceptionMessage = filterContext.Exception.Message,
                Stacktrace = filterContext.Exception.StackTrace
            };

            OnException(filterContext, viewName, model);
        }

        private void OnException<T>(ExceptionContext filterContext, [AspMvcView] string viewName, [AspMvcModelType] T model)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = viewName,
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}