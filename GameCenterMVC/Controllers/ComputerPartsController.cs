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
        // GET: ComputerParts
        ComputerPartsDAL computerPartsDAL = new ComputerPartsDAL();
        public ActionResult Index()
        {
            List<ComputerParts> pcParts = computerPartsDAL.GetALL().ToList();
            ViewBag.ComputerParts = pcParts;
            return View(pcParts);
        }
        // GET: ComputerParts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerParts/Create
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
    }
    
}