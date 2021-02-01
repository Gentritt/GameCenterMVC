using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(string lngName)
		{
            if(lngName != null)
			{

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lngName);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lngName);

			}

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lngName;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");

		}
    }
}