using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class ClientController : SecureController
    {
        ClientDAL clientDAL = new ClientDAL();
        //[AuthorizedUsers("admin")]
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

        [HttpPost]
        public ActionResult Create(Client client)
        {
            ValidationsExists validations = new ValidationsExists();
            try
            {
                if (validations.ExitsMember(client.Username))
                    ModelState.AddModelError("", "Please Try Another Username");
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

        public ActionResult Update(int id)
		{

            return View(ClientDAL.GetByID(id));
		}

        [HttpPost]
        public ActionResult Update(int id, Client client)
		{
            ValidationsExists validationsExists = new ValidationsExists();
			try
			{
                if (validationsExists.ExitsMember(client.Username))
                    ModelState.AddModelError("", "The username Already Exists");
				if (ModelState.IsValid)
				{
                    clientDAL.Modify(client);
                    return RedirectToAction("Index");
                   
				}
                return View();
			}
			catch (Exception)
			{
                return View();
            }
		}
        public ActionResult Remove(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    clientDAL.Remove(id);
                    return RedirectToAction("Index");
                }
                return View();


			}
			catch (Exception)
			{

                return View();
			}
		}
        public ActionResult Details(int id)
		{
            Client client = ClientDAL.GetByID(id);
            return PartialView("Details", client);
		}
    }
}