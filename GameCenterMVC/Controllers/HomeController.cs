﻿using GameCenterMVC.DAL;
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
            Computer pc = new Computer();
            pc.ComputerID = bill.ComputerID;
            pc.IsActive = true;
            computerDAL.IsActive(pc);
            try
            {
                if (ModelState.IsValid)
                {
                    if (bill.EndTime == null)
                        return View("PrintBill", bill);

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
            Computer pc = new Computer();
            pc.ComputerID = bill.ComputerID;
            pc.IsActive = false;
            computerDAL.IsActive(pc);
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
      
        public ActionResult UpdateBills(int id, Bill bill)
        {
            Computer computer = new Computer();
            var starttime = bill.StartTime;
            bill.EndTime = DateTime.Parse(DateTime.Now.ToLongTimeString());
            double minutes = (bill.EndTime - starttime).TotalHours;
            var cost = 1;
            if (minutes < 1)
                bill.Total = Convert.ToDouble(cost);
            else
                bill.Total = Convert.ToDouble(cost + Math.Round(minutes - 1));
            //bill.Total = 1;     
            billsDAL.Update(id, bill);
            //bill = BillsDAL.Get(id);
            return PartialView("ShowBill",bill);
		}

        public ActionResult ShowBill(int id)
		{
            Bill bill = BillsDAL.Get(id);
            return PartialView();
		}
    }
}