using System.Web.Mvc;
using Tekno.MODEL.Entity;

namespace Tekno.UI.Filters
{
    public class AuthenticationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["login"] == null)
            {
                filterContext.Result = new RedirectResult("~/AppUser/Login");
            }
            else
            {
                var user = filterContext.HttpContext.Session["login"] as AppUser;
                if (user.Role == Role.admin)
                {
                    filterContext.Result = new RedirectResult("~/Admin/Home/Index");
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Home/Index");
                }
            }
        }
    }
}