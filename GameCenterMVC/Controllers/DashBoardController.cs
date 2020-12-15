using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class DashBoardController : Controller
    {
        
        public ActionResult Index()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }
    }
}