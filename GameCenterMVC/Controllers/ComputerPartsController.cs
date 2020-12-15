using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class ComputerPartsController : Controller
    {
        ComputerPartsDAL computerPartsDAL = new ComputerPartsDAL();
        [AuthorizedUsers("admin", "manager")]
        public ActionResult Index()
        {
            List<ComputerParts> pcParts = ComputerPartsDAL.GetALL().ToList();
            ViewBag.ComputerParts = pcParts;
            return View(pcParts);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ComputerParts pcParts)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    computerPartsDAL.ADD(pcParts);
                    return RedirectToAction("Index");

                }
                return View();

            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Update(int id)
		{
            return View(ComputerPartsDAL.GetByID(id));
		}
         [HttpPost]
         public ActionResult Update(ComputerParts parts)
		 {
			try
			{
				if (ModelState.IsValid)
				{
                    computerPartsDAL.Modify(parts);
                    return RedirectToAction("Index");

				}
                return View();
			}
			catch (Exception)
			{

                return View();
			}
		}
        public ActionResult Remove(int ID)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    computerPartsDAL.Remove(ID);
                    return RedirectToAction("Index");
				}
                return View();
			}
			catch (Exception e)
			{

                return View();
			}
		}

        public ActionResult Details(int id)
		{
            ComputerParts parts = ComputerPartsDAL.GetByID(id);
            return PartialView("Details", parts);
		}
    }
    
}