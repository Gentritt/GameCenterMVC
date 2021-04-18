using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using GameCenterMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class EmployeController : Controller
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Index()
        {
            EmployeeDAL employee = new EmployeeDAL();
            List<Employee> employees = employee.GetALL().ToList();
            ViewBag.Employee = employees;
            return View(employees);
        }

        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employe)
        {
            ValidationsExists validations = new ValidationsExists();
            EmployeeDAL employeeDAL = new EmployeeDAL();

           
            if (validations.ExitsEmployee(employe.UserName))
                ModelState.AddModelError("UserName", "Please Try Another Username, this one Exists !");
            try
			{
				if (ModelState.IsValid)
				{
                    employe.InsertDate = DateTime.Now;
                
                    employeeDAL.ADD(employe);  
                    return RedirectToAction("Index");

				}
                return View();

            }
			catch (Exception)
			{

                return View();
			}
        }
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Edit(int id)
        {
            return View(EmployeeDAL.GetByID(id));
        }

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
        [AuthorizedUsers(RolesName.Admin)]
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
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Details(int id)
		{

            Employee employee = EmployeeDAL.GetByID(id);
            return PartialView("Details", employee);
		}
    }

}
