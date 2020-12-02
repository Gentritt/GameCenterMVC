using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GameCenterMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login ()
		{
            return View();
		}
        [HttpPost]
        public ActionResult Login(Login objLogin)
		{
            ServiceHelper validateUser = new ServiceHelper();
			if (ModelState.IsValid)
			{

                if(validateUser.ValidateUsers(objLogin.Username, objLogin.Password))
				{
                    FormsAuthentication.SetAuthCookie(objLogin.Username, false);
                    Session["Username"] = objLogin.Username;    
                    return RedirectToAction("Index", "DashBoard");
				}
                 ModelState.AddModelError("Error", "Invalid Username Or Password");
				
			}
            return View();
		}

        public ActionResult LogOut()
		{
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
                
		}
    }
}