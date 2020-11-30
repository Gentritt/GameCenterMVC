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
            List<Roles> roles = rolesDAL.GetALL().ToList();
            ViewBag.Roles = roles;
            return View(roles);
        }
    }
}