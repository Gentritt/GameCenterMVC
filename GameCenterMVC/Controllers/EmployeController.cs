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
        EmployeeDAL employeeDAL = new EmployeeDAL();
        //[AuthorizedUsers("manager")]
        public ActionResult Index()
        {
            EmployeeDAL employee = new EmployeeDAL();
            List<Employee> employees = employee.GetALL().ToList();
            ViewBag.Employee = employees;
            return View(employees);
        }
		//public ActionResult IndexTest()
		//{
		//	List<Employee> employees = EmployeeDAL.GetAll().ToList();
		//	ViewBag.Employee = employees;
		//	return View(employees);

		//}
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
        public ActionResult Create(Employee employee)
        {
            ValidationsExists validations = new ValidationsExists();
            EmployeeDAL employeeDAL = new EmployeeDAL();
            if (validations.ExitsEmployee(employee.UserName))
                ModelState.AddModelError("UserName", "Please Try Another Username, this one Exists !");
            try
			{
				if (ModelState.IsValid)
				{
                    employeeDAL.ADD(employee);
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
            return View(EmployeeDAL.GetByID(id));
        }

        // POST: Employe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    employeeDAL.Modify(collection);
                    return RedirectToAction("Index");

                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Employe/Delete/5



        public ActionResult Delete(int id)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    employeeDAL.Remove(id);
                    return RedirectToAction("Index");
                }

                return View();
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
