using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLInfo.Web.Controllers
{
    public class IsLoginAttribute : ActionFilterAttribute  
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserInfo"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/home/Login");
            }
        }  
    }
}