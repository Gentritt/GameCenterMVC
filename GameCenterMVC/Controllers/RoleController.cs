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
        public ActionResult Index()
        {
            List<Roles> roles = RolesDAL.GetALL().ToList();
            ViewBag.Roles = roles;
            return View(roles);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Roles roles)
        {
            
            try
            {
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
    }
}