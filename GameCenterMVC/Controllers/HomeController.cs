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
        public ActionResult BillsHistory()
		{
            List<Bill> bills = billsDAL.Getall().ToList();
            ViewBag.Bills = bills;
            return View(bills);

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
        [HttpGet]
        public ActionResult BillDetails(int id)
        {
            Bill bill = BillsDAL.GetByID(id);
            return PartialView("BillDetails", bill);

        }
        [HttpGet]
        public ActionResult PrintBill(int id)
		{
            Bill bill = BillsDAL.Get(id); //Merr Bill e fundit per qdo ID te kompjuterit.
            return PartialView("PrintBill", bill);
		}
        public ActionResult Remove(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    billsDAL.Remove(id);
                    return RedirectToAction("BillsHistory");
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