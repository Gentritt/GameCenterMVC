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
        BillsDAL billsDAL = new BillsDAL();
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
            

            StaticCLass.ComputerID = id;
            
           
            if (StaticCLass.ComputerID == 0)
            {
                return HttpNotFound();

            }

            return PartialView("Details", ComputerDAL.getPcByID(id));
        }
        
    }
}