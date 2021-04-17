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
        ComputerDAL computerDAL = new ComputerDAL();
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Index()
        {
            List<Computer> computers = computerDAL.GetALL().ToList();
            ViewBag.Computer = computers;
            return View(computers);

        }
        [AuthorizedUsers(RolesName.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Computer/Create
        [HttpPost]
        public ActionResult Create(Computer computer)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    computerDAL.ADD(computer);
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
        public ActionResult Update(int id)
		{
            return View(ComputerDAL.getPcByID(id));
		}
        [HttpPost]
        public ActionResult Update(int id, Computer computer)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    computerDAL.Modify(computer);
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
        public ActionResult Remove(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    computerDAL.Remove(id);
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
        public ActionResult Details(int id)
		{
            Computer computer = ComputerDAL.getPcByID(id);
            if(computer == null)
			{
                return HttpNotFound();

			}
            return PartialView("Details", computer);
			
		}
    }
}