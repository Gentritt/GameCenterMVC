using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class SecureController : Controller
    {
		// GET: Secure
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (Session["Username"] != null)
			{
				base.OnActionExecuting(filterContext);
			}
			else
				filterContext.Result = RedirectToAction("Login", "Account");
		}
	}
}