﻿using GameCenterMVC.DAL;
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
        public ActionResult Index()
        {
            List<Computer> computers = computerDAL.GetALL().ToList();
            ViewBag.Computer = computers;
            return View(computers);

        }
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
    }
}