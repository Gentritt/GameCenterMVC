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
        EmployeeDAL employeeDAL = new EmployeeDAL();
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

            employeeDAL.GetByUser(Session["Username"].ToString());


            if (StaticCLass.ComputerID == 0)
            {
                return HttpNotFound();

            }
            //Te gjendet Bill duke u bazuar ne id e kompjuterit te cilen e pranojm si argument dhe ti dergohet partial Views
            return PartialView("Details", BillsDAL.GetBillById(id));
        }
        [HttpPost]
        public ActionResult Add(Bill bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    billsDAL.ADD(bill);
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