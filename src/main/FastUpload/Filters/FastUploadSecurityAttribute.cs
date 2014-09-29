using System.Web.Mvc;

namespace FastUpload.Filters
{
    public class FastUploadSecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Request["Token"]))
            {
                filterContext.Result = new HttpUnauthorizedResult("Token not informed");
                return;
            }

            if (!FastUploadSettings.Tokens.Contains(filterContext.HttpContext.Request["Token"]))
            {
                filterContext.Result = new HttpUnauthorizedResult("Token invalid");
                return;
            }

            if (filterContext.HttpContext.Request.UrlReferrer != null && !filterContext.HttpContext.Request.UrlReferrer.Host.Equals(filterContext.HttpContext.Request.Url.Host) 
                && !FastUploadSettings.Domains.Contains(filterContext.HttpContext.Request.UrlReferrer.Host))
            {
                filterContext.Result = new HttpUnauthorizedResult("Domain not allowed");
                return;                
            }

            base.OnActionExecuting(filterContext);
        }
    }
}