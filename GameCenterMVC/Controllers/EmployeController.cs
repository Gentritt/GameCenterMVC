using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            List<Employee> employees = EmployeeDAL.GetAll().ToList();
            ViewBag.Employee = employees;
            return View(employees);
        }
        public ActionResult IndexTest()
		{
            List<Employee> employees = EmployeeDAL.GetAll().ToList();
            ViewBag.Employee = employees;
            return View(employees);

        }
        // GET: Employe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        [HttpPost]
        public ActionResult Create(EmployeeDAL employee)
        {

			try
			{
				if (EmployeeDAL.ADD(employee))
				{
                    return RedirectToAction("Index");

				}
                return View();

            }
			catch (Exception)
			{

                return View();
			}
        }

        // GET: Employe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

  //      public ActionResult getdata()
		//{
  //          //return Json(new { data = data }, JsonRequestBehavior.AllowGet);
		//}
    }
}
