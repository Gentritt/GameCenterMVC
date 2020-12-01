using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        ClientDAL clientDAL = new ClientDAL();
        public ActionResult Index()
        {
            List<Client> clients = clientDAL.GetALL().ToList();
            ViewBag.Client = clients;
            return View(clients);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    clientDAL.ADD(client);
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