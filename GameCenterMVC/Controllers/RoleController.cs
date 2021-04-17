using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        RolesDAL rolesDAL = new RolesDAL();
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Index()
        {
            List<Roles> roles = RolesDAL.GetALL().ToList();
            ViewBag.Roles = roles;
            return View(roles);
        }
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Roles roles)
        {
            ValidationsExists validationsExists = new ValidationsExists();
            try
            {
                if (validationsExists.ExitsRole(roles.Name))
                    ModelState.AddModelError("", "This Role Exits");
                if (ModelState.IsValid)
                {
                    rolesDAL.ADD(roles);
                    return RedirectToAction("Index");

                }
                return View();

            }
            catch (Exception)
            {

                return View();
            }
        }
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Update(int id)
		{
            return View(RolesDAL.GetByID(id));
		}
        [HttpPost]
        public ActionResult Update(int id, Roles roles) 
        {
			try
			{
				if (ModelState.IsValid)
				{
                    rolesDAL.Modify(roles);
                    return RedirectToAction("Index");
				}
                return View();

			}
			catch (Exception)
			{

                return View();
			}
        
        }
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Remove(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    rolesDAL.Remove(id);
                    return RedirectToAction("Index");
                        
				}
                return View();
			}
			catch (Exception)
			{

                return View();
			}

		}
    }
}