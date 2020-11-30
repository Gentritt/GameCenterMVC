using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class ComputerController : Controller
    {
        // GET: Computer
        public ActionResult Index()
        {
            List<Computer> computers = ComputerDAL.GetAll().ToList();
            ViewBag.Computer = computers;
            return View(computers);

            
        }
    }
}