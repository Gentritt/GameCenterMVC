using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class HomeController : Controller
    {
        ComputerDAL computerDAL = new ComputerDAL();
        // GET: Main
        public ActionResult Index()
        {
            List<Computer> computers = computerDAL.GetALL().ToList();
            ViewBag.Computer = computers;
            return View(computers);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Computer computer = ComputerDAL.getPcByID(id);
            if (computer == null)
            {
                return HttpNotFound();

            }
            return PartialView("Details", computer);
        }
        
    }
}