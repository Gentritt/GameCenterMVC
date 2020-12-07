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
        Products products = new Products();
        // GET: Product
        ProductDAL productDAL = new ProductDAL();
        public ActionResult Index()
        {
		
          List<Products> products = productDAL.GetALL().ToList();
          return View(products);

			//ViewBag.Products = products;
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

        public ActionResult Update(int id)
		{
            return View(ProductDAL.getByID(id));
		}
        [HttpPost]
        public ActionResult Update(int id, Products products)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    productDAL.Modify(products);
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
                    productDAL.Remove(id);
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