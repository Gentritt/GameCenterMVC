using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class BaseController : Controller
    {
		// GET: Base
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if(filterContext.HttpContext.Session != null)
			{
				if (this.Session["Username"] == null)
				{
					filterContext.Result = RedirectToAction("Login", "Account");
					return;

				}
			}
			base.OnActionExecuting(filterContext);
		}


	}
}