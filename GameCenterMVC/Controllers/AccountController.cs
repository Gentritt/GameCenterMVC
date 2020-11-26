using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            Login login = new Login();
            return View(login);
		}
        [HttpPost]
        public ActionResult Login(Login objLogin)
		{

            ValidateUser validateUser = new ValidateUser();
			if (ModelState.IsValid)
			{

                if(validateUser.ValidateUsers(objLogin.Username, objLogin.Password))
				{
                    Session["Username"] = objLogin.Username;
                    return RedirectToAction("Index", "Account");
				}
                 ModelState.AddModelError("Error", "Invalid Email and Password");
				
			}
            return View();
		}
    }
}