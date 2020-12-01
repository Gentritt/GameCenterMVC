using GameCenterMVC.DAL;
using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductDAL productDAL = new ProductDAL();
        public ActionResult Index()
        {
            List<Products> products = productDAL.GetALL().ToList();
            ViewBag.Products = products;
            return View(products);
        }
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products product)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    productDAL.ADD(product);
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